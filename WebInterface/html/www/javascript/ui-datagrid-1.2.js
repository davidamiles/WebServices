//
// 1.2 CHANGES:
//      added function getRecords() which returns indexed records, values can be modified and when combined
//          with update() function allows you to update table without clearing and readding an updated record set
//          which maintains state sort order and any selected records
//      added function update() which refreshes table with exisitng record set
//      added event onRowUnSelected
//      added function AddRecord(record) add a single record to the datagrid
//      added function GetCellValue(row, column);
//      added function SetCellColor(row, column, "#000000");
//      added event onTableSorted
//
// 1.1 CHANGES:
//      fixed bug with delete and the wrong record being selected
//      selectedRow was returning 0 index value while SetSelectedRow was using 1 index, reconciled the differences so both are 0 indexed
//
// 1.0 CHANGES:
//      support for nested function fields
//      custom css class names for unique styling per instance
//      show footer option true/false
//      manually set the selected row, good for initializing a master/detail layout by selecting the first result
//      
//  
// TODO:
//      max record count so we can go to the end of the dataset
//      Styles a parameter
//      Column Data as Links (maybe that should be part of the datamodel????)
//      Search/Filter (this maybe all backend DataModel stuff)
//      Insert Row
//      Edit Row (inline)
//      Caption title
//      preserve sorting when page and page count changes
//      sort icon for sortable columns
//      return sort order to default after user cycles through ASC->DESC->back to Original
//
//
// USAGE:
// subscribe to datagrid events
//      document.documentElement.addEventListener(DataGrid.EVENT_TYPE_PAGE_CHANGED, pageChanged);
//      document.documentElement.addEventListener(DataGrid.EVENT_TYPE_PAGE_COUNT_CHANGED, pageCountChanged);
//      document.documentElement.addEventListener(DataGrid.EVENT_TYPE_ROW_SELECTED, rowSelected);
//      document.documentElement.addEventListener(DataGrid.EVENT_TYPE_ROW_DELETED, rowDeleted);
//
//
// example event handler's
//
//    function pageChanged(e)
//    {
//        var pageNumber = e.detail.DataGrid.GetPageNumber();
//    }
//
//    function rowSelected(e)
//    {
//        var record = e.detail.SelectedRecord;
//        var row = e.detail.SelectedRow;
//        var name = e.detail.DataGrid.GetGridName();
//    }
//
//    function rowDeleted(e)
//    {
//        var record = e.detail.SelectedRecord;
//        var row = e.detail.SelectedRow;
//        var isMultiDelete = e.detail.IsMultiDelete;
//    }
//
//
//
// set the table header and field names so the DataGrid knows what
// the data model looks like
// var columns = [];
// columns.push(new DataGridColumn(DisplayName, FieldName, sortable, editable));
// columns.push(new DataGridColumn("Name", "name", true, false));
//
// create an instance and call init() pasing the container div element, headers, unique name
// var deviceGrid = new DataGrid(false, false, false);
// deviceGrid.Init(document.getElementById("datagridContainerDiv"), columns, "myDataGrid");
// deviceGrid.AddRecords(records);
//



function DataGrid(showDelete, showMultiDelete, isMultiSelectEnabled, showFooter) {
    var _self = this;
    var _divTableContainer = null;
    var _pageNumber = 1;
    var _table = document.createElement("table");
    var _name = null;
    var _columns = null;
    var _styles = null;
    var _divPageNumber = null;
    var _pageCountValues = [10, 20, 30, 40, 50, 100];
    var _pageCount = 10;
    var _records = [];
    var _indexedRecords = [];
    var _selectedRows = [];
    var _selectedRowNumber = -1;
    var _sortASC = "ASC";
    var _sortDESC = "DESC";
    var _sortedHeader = null;
    var _isDeleteEnabled = showDelete;
    var _isMultiDeleteEnabled = showMultiDelete;
    var _isMultiSelectEnabled = isMultiSelectEnabled;
    var _isFooterVisible = showFooter;
    var _classTable = "Table";
    var _classTableRow = "TableRow";
    var _classTableAlternatingRow = "TableAlternatingRow";
    var _classTableSelectButton = "TableSelectButton";
    var _classTableSelectedRow = "TableSelectedRow";
    var _classTableDeleteButton = "TableDeleteButton";
    var _classTableHeaderRow = "TableHeaderRow";
    var _classTableFooterRow = "TableFooterRow";
    var _classTableHeaderCell = "TableHeaderCell";
    var _classTableHeaderCellSorted = "TableHeaderCellSorted";


    var onPageChangedEvent = document.createEvent("CustomEvent");
    onPageChangedEvent.initCustomEvent(DataGrid.EVENT_TYPE_PAGE_CHANGED, false, false, DataGridEventData);

    var onPageCountChangedEvent = document.createEvent("CustomEvent");
    onPageCountChangedEvent.initCustomEvent(DataGrid.EVENT_TYPE_PAGE_COUNT_CHANGED, false, false, DataGridEventData);

    var onRowSelectedEvent = document.createEvent("CustomEvent");
    onRowSelectedEvent.initCustomEvent(DataGrid.EVENT_TYPE_ROW_SELECTED, false, false, DataGridEventData);

    var onRowUnSelectedEvent = document.createEvent("CustomEvent");
    onRowUnSelectedEvent.initCustomEvent(DataGrid.EVENT_TYPE_ROW_UNSELECTED, false, false, DataGridEventData);

    var onRowEditedEvent = document.createEvent("CustomEvent");
    onRowEditedEvent.initCustomEvent(DataGrid.EVENT_TYPE_ROW_EDITED, false, false, DataGridEventData);

    var onRowDeletedEvent = document.createEvent("CustomEvent");
    onRowDeletedEvent.initCustomEvent(DataGrid.EVENT_TYPE_ROW_DELETED, false, false, DataGridEventData);

    var onTableSorted = document.createEvent("CustomEvent");
    onTableSorted.initCustomEvent(DataGrid.EVENT_TYPE_TABLE_SORTED, false, false, DataGridEventData);



    this.SetClassNames = function (table, row, alternatingRow, selectedRow, headerRow, footerRow, headerCell, headerCellSorted, deleteButton, selectButton) {
        _classTable = table;
        _classTableRow = row;
        _classTableAlternatingRow = alternatingRow;
        _classTableSelectedRow = selectedRow;
        _classTableHeaderRow = headerRow;
        _classTableFooterRow = footerRow;
        _classTableHeaderCell = headerCell;
        _classTableHeaderCellSorted = headerCellSorted;
        _classTableDeleteButton = deleteButton;
        _classTableSelectButton = selectButton;
    }

    this.Init = function (divContainer, columns, gridName) {
        _divTableContainer = divContainer;
        _name = gridName;
        _columns = columns;
        _table.setAttribute("class", _classTable);

        setHeaderRow();
        setFooterRow();

        _divTableContainer.appendChild(_table);
    }

    this.SetSelectedRow = function (rowNumber) {
        _selectedRowNumber = rowNumber; // our hash and array's are zero indexed so row 1 is actually row 0

        //
        // add 1 to the rowNumber to account for the header row in our HTML table
        _table.rows[rowNumber + 1].setAttribute("class", _classTableSelectedRow);

        onRowSelectedEvent.detail = new DataGridEventData();
        onRowSelectedEvent.detail.DataGrid = _self;
        onRowSelectedEvent.detail.SelectedRecord = _indexedRecords[_selectedRowNumber];
        onRowSelectedEvent.detail.SelectedRow = rowNumber;

        _selectedRows[_selectedRowNumber] = _records[_selectedRowNumber];

        document.documentElement.dispatchEvent(onRowSelectedEvent)
    }

    this.ClearGrid = function () {
        var rowCount = _table.rows.length;

        if (_isFooterVisible) {
            rowCount -= 1; //don't remove the footer row
        }

        for (var i = rowCount; i > 1; i--) {
            _table.deleteRow(i - 1);
        }

        _selectedRows = [];
    }

    this.AddRecord = function (record) {
        _records.push(record);

        _self.ClearGrid();

        addRows();
    }

    this.AddRecords = function (records) {
        _records = records;

        _self.ClearGrid();

        addRows();
    }

    this.DeleteRecord = function (rowNumber) {
        _records.splice(rowNumber, 1);

        _self.ClearGrid();

        addRows();
    }

    this.DeleteSelectedRecords = function () {
        var reversedKeys = Object.keys(_selectedRows).reverse();

        reversedKeys.forEach(function (rowNumber) {
            _records.splice(rowNumber, 1);
        });

        _selectedRows = [];

        _self.ClearGrid();

        addRows();
    }

    this.GetPageNumber = function () {
        return _pageNumber;
    }

    this.GetGridName = function () {
        return _name;
    }

    this.GetPageCount = function () {
        return _pageCount;
    }

    this.SetCellColor = function (row, cell, color) {
        var cell = _table.rows[row].cells[cell];
        cell.style.backgroundColor = color;
    }

    this.GetCellValue = function (row, cell) {
        return _table.rows[row].cells[cell].innerHTML;
    }

    this.GetRecords = function () {
        return _records;
    }

    this.Update = function () {
        var count = 1; // start at 1 to skip the header row

        _indexedRecords.forEach(function (record) {
            var row = _table.rows[count];

            var columnCounter = 1; // skip past the select column

            _columns.forEach(function (column) {
                var v = null;

                if (column.FieldName.indexOf(".") > 0) {
                    v = deep_value(record, column.FieldName);
                }
                else {
                    v = record[column.FieldName];
                }

                var cell = row.cells[columnCounter];
                cell.innerHTML = v;

                columnCounter++;
            });

            count++;
        });
    }



    // 
    // private members
    //
    function addRows() {
        if (_records == null || _records == undefined) {
            return;
        }

        var rowCounter = _records.length - 1;

        _records.forEach(function (record) {
            _indexedRecords[rowCounter] = record;

            var row = _table.insertRow(1);

            if (rowCounter % 2 == 0) {
                row.setAttribute("class", _classTableRow);
            }
            else {
                row.setAttribute("class", _classTableAlternatingRow);
            }

            var selectionButton = document.createElement("input");
            selectionButton.setAttribute("style", "width: 5px");
            selectionButton.className = _classTableSelectButton;
            selectionButton.id = rowCounter + "_";
            selectionButton.type = "button";
            selectionButton.onclick = function (event) {
                var button = event.target;
                var rowNumber = getRowNumberFromButtonId(button.id);
                var selected = _selectedRows[rowNumber];// was this row already selected or did the just unselect the row


                //
                // if we are not doing multiple selects and there is a row already selected
                // reset the style back to unselected and remove it from the selectedRows hash
                //
                if (!_isMultiSelectEnabled && _selectedRows.length > 0) {
                    delete _selectedRows[_selectedRowNumber];

                    var r = _selectedRowNumber + 1;  // plus 1 for the header row

                    if (_selectedRowNumber % 2 == 0) {
                        _table.rows[r].setAttribute("class", _classTableRow);
                    }
                    else {
                        _table.rows[r].setAttribute("class", _classTableAlternatingRow);
                    }
                }

                _selectedRowNumber = rowNumber;

                if (selected == null || selected == undefined) {
                    row.setAttribute("class", _classTableSelectedRow);

                    _selectedRows[rowNumber] = _records[rowNumber];

                    onRowSelectedEvent.detail = new DataGridEventData();
                    onRowSelectedEvent.detail.DataGrid = _self;
                    onRowSelectedEvent.detail.SelectedRecord = _indexedRecords[rowNumber];
                    onRowSelectedEvent.detail.SelectedRow = rowNumber;

                    document.documentElement.dispatchEvent(onRowSelectedEvent)
                }
                else {
                    delete _selectedRows[rowNumber];

                    if (rowNumber % 2 == 0) {
                        row.setAttribute("class", _classTableRow);
                    }
                    else {
                        row.setAttribute("class", _classTableAlternatingRow);
                    }

                    onRowUnSelectedEvent.detail = new DataGridEventData();
                    onRowUnSelectedEvent.detail.DataGrid = _self;

                    document.documentElement.dispatchEvent(onRowUnSelectedEvent);
                }
            };

            var selectionCell = row.insertCell(0);
            selectionCell.setAttribute("style", "padding: 0px");
            selectionCell.appendChild(selectionButton);

            if (_isDeleteEnabled) {
                var deleteButton = document.createElement("input");
                deleteButton.setAttribute("style", "width: 5px");
                deleteButton.className = _classTableDeleteButton;
                deleteButton.id = rowCounter + "_"
                deleteButton.type = "button";
                deleteButton.onclick = function (event) {
                    var button = event.target;
                    var rowNumber = getRowNumberFromButtonId(button.id);

                    onRowDeletedEvent.detail = new DataGridEventData();
                    onRowDeletedEvent.detail.DataGrid = _self;
                    onRowDeletedEvent.detail.SelectedRecord = _indexedRecords[rowNumber];
                    onRowDeletedEvent.detail.SelectedRow = rowNumber;
                    onRowDeletedEvent.detail.IsMultiDelete = false;

                    document.documentElement.dispatchEvent(onRowDeletedEvent);
                };

                var deletionCell = row.insertCell(1);
                deletionCell.setAttribute("style", "padding: 0px");
                deletionCell.appendChild(deleteButton);
            }

            var counter = 2;  // init at 2, the selection and delete cells are 0 and 1

            if (!_isDeleteEnabled) {
                counter = 1;
            }

            _columns.forEach(function (column) {
                var v = null;

                if (column.FieldName.indexOf(".") > 0) {
                    v = deep_value(record, column.FieldName);
                }
                else {
                    v = record[column.FieldName];
                }

                var cell = row.insertCell(counter);
                cell.innerHTML = v;

                counter += 1;
            });


            rowCounter--;
        });
    }

    function setHeaderRow() {
        var header = _table.createTHead();
        var row = header.insertRow(0);
        row.setAttribute("class", _classTableHeaderRow)

        //
        // so our header cells will line up with data cells in our rows
        //
        row.appendChild(document.createElement("th")); // the select button

        if (_isDeleteEnabled) {
            row.appendChild(document.createElement("th")); // the delete button
        }


        _columns.forEach(function (column) {
            var e = document.createElement("th");
            e.innerHTML = column.DisplayName;
            e.className = _classTableHeaderCell;

            if (column.Sortable) {
                e.title = "Click to sort";
                e.setAttribute("style", "cursor: pointer");
                e.onclick = function () {

                    if (_sortedHeader != null && _sortedHeader.innerHTML != column.DisplayName) {
                        //
                        // the user selected a different column to sort by
                        // reset the style for the old header
                        //
                        _sortedHeader.className = _classTableHeaderCell;

                        e.className = _classTableHeaderCellSorted;
                        _sortedHeader = e;
                        column.SortOrder = null;
                    }
                    else if (_sortedHeader == null) {
                        e.className = _classTableHeaderCellSorted;
                        _sortedHeader = e;
                        column.SortOrder = null;
                    }
                    else if (_sortedHeader != null && column.SortOrder == _sortDESC) // turn off sorting ASC, DESC, NULL, ASC, DESC, NULL, etc....
                    {
                        e.className = _classTableHeaderCell;
                        _sortedHeader = null;
                    }

                    sort(column);

                    document.documentElement.dispatchEvent(onTableSorted);
                };
            }

            row.appendChild(e);
        })
    }

    function setFooterRow() {
        if (!_isFooterVisible) {
            return;
        }

        var footer = _table.createTFoot();
        var row = footer.insertRow(0);
        row.setAttribute("class", _classTableFooterRow);

        var totalNumberOfCells = _columns.length;
        totalNumberOfCells += 2; // to account for our delete and selection buttons

        var cell = row.insertCell(0);
        cell.setAttribute("colspan", totalNumberOfCells);

        if (_isDeleteEnabled && _isMultiSelectEnabled && _isMultiDeleteEnabled) {
            var div = document.createElement("div");
            div.innerHTML = "Multi Delete";
            div.setAttribute("style", "cursor: pointer; display: inline; margin-right: 30px");
            div.onclick = multiDelete;
            cell.appendChild(div)
        }


        var select = document.createElement("select");
        select.setAttribute("style", "display: inline");
        var option;

        _pageCountValues.forEach(function (value) {
            option = document.createElement("option");
            option.text = value.toString();
            option.value = value;
            select.add(option);
        });

        select.onchange = pageCountChanged;
        cell.appendChild(select);

        div = document.createElement("div");
        div.onclick = pageOne;
        div.innerHTML = "<<";
        div.setAttribute("style", "cursor: pointer; display: inline; margin-left: 20px");
        cell.appendChild(div);

        div = document.createElement("div");
        div.onclick = pageBackward;
        div.innerHTML = "<";
        div.setAttribute("style", "cursor: pointer; display: inline; margin-left: 20px");
        cell.appendChild(div);

        _divPageNumber = document.createElement("div");
        _divPageNumber.innerHTML = _pageNumber;
        _divPageNumber.setAttribute("style", "display: inline; margin-left: 20px");
        cell.appendChild(_divPageNumber);

        div = document.createElement("div");
        div.onclick = pageForward;
        div.innerHTML = ">";
        div.setAttribute("style", "cursor: pointer; display: inline; margin-left: 20px");
        cell.appendChild(div);
    }

    function pageForward() {
        _pageNumber += 1;

        _divPageNumber.innerHTML = _pageNumber;

        onPageChangedEvent.detail = new DataGridEventData();
        onPageChangedEvent.detail.DataGrid = _self;

        document.documentElement.dispatchEvent(onPageChangedEvent);
    }

    function pageOne() {
        if (_pageNumber == 1) {
            return;
        }

        _pageNumber = 1;

        _divPageNumber.innerHTML = _pageNumber;

        onPageChangedEvent.detail = new DataGridEventData();
        onPageChangedEvent.detail.DataGrid = _self;

        document.documentElement.dispatchEvent(onPageChangedEvent);
    }

    function pageBackward(value) {
        if (_pageNumber == 1) {
            return;
        }

        _pageNumber -= 1;

        _divPageNumber.innerHTML = _pageNumber;

        onPageChangedEvent.detail = new DataGridEventData();
        onPageChangedEvent.detail.DataGrid = _self;

        document.documentElement.dispatchEvent(onPageChangedEvent);
    }

    function pageCountChanged(event) {
        var index = event.target.selectedIndex;
        _pageCount = _pageCountValues[index];

        onPageCountChangedEvent.detail = new DataGridEventData();
        onPageCountChangedEvent.detail.DataGrid = _self;

        document.documentElement.dispatchEvent(onPageCountChangedEvent);
    }

    function sort(header) {
        if (header.SortOrder == null) {
            header.SortOrder = _sortASC;
        }
        else if (header.SortOrder == _sortASC) {
            header.SortOrder = _sortDESC;
        }
        else {
            header.SortOrder = null;
        }


        if (header.SortOrder != null) {
            _records.sort(function (a, b) {

                var f1 = a[header.FieldName];
                var f2 = b[header.FieldName];

                if (f1 > f2) {
                    if (header.SortOrder == _sortASC) {
                        return -1;
                    }
                    else {
                        return 1;
                    }
                }
                else if (f1 < f2) {
                    if (header.SortOrder == _sortASC) {
                        return 1;
                    }
                    else {
                        return -1;
                    }
                }

                return 0;
            });

            _self.ClearGrid();
            addRows();
        }


    }

    function getRowNumberFromButtonId(buttonId) {
        var id = buttonId.substring(0, buttonId.indexOf("_"));
        var rowNumber = parseInt(id);
        return rowNumber;
    }

    function multiDelete(event) {
        onRowDeletedEvent.detail = new DataGridEventData();
        onRowDeletedEvent.detail.DataGrid = _self;
        onRowDeletedEvent.detail.IsMultiDelete = true;
        onRowDeletedEvent.detail.SelectedRecords = _selectedRows;

        document.documentElement.dispatchEvent(onRowDeletedEvent);
    }

    var deep_value = function (obj, path) {
        for (var i = 0, path = path.split('.'), len = path.length; i < len; i++) {
            obj = obj[path[i]];
        };
        return obj;
    };
}

function DataGridEventData() {
    this.DataGrid = null;
    this.SelectedRow = 0;
    this.SelectedRecord = null;
    this.IsMultiDelete = false;
    this.SelectedRecords = [];
}

function DataGridColumn(headerName, fieldName, sortable, editable) {
    this.DisplayName = headerName;
    this.FieldName = fieldName;
    this.Sortable = sortable;
    this.Editable = editable;
    this.SortOrder = null;
}

DataGrid.EVENT_TYPE_PAGE_CHANGED = "onPageChanged";
DataGrid.EVENT_TYPE_PAGE_COUNT_CHANGED = "onPageCountChanged";
DataGrid.EVENT_TYPE_ROW_SELECTED = "onRowSelected"
DataGrid.EVENT_TYPE_ROW_UNSELECTED = "onRowUnSelected";
DataGrid.EVENT_TYPE_ROW_EDITED = "onRowEdited";
DataGrid.EVENT_TYPE_ROW_DELETED = "onRowDeleted";
DataGrid.EVENT_TYPE_TABLE_SORTED = "onTableSorted";



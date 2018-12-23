function Jobs()
{
    var _jobs = [];
    var _table = document.createElement("table");    

    this.GetJobs = function GetJobs()
    {
        var restClient = new RestClient(_constants.JobsWebSvcPath);
        restClient.SelectJobs(0, 10, function (restCallbackObj)
        {
            _jobs = restCallbackObj.ResponseJSON;
            bind();
        });
    }

    function bind()
    {
        $("#grid").igGrid({        
            primaryKey: "Id",
            //caption: "<span> <img src=\"//www.infragistics.com/media/441501/horz_logo.png\" alt=\"Infragistics\"></span>",
            width: '100%',
            columns: [
                { headerText: "Id", key: "Id", dataType: "number", width: "15%", hidden: true },
                { headerText: "CustomerName", key: "CustomerName", dataType: "string", width: "15%", hidden: false },
                { headerText: "City", key: "City", dataType: "string", width: "25%" },
                { headerText: "Zipcode", key: "Zipcode", dataType: "string", width: "25%" },
                { headerText: "Email", key: "Email", dataType: "string", width: "25%" },
                { headerText: "Assignedto", key: "Assignedto", dataType: "string", width: "25%" }
            ],
            autofitLastColumn: false,
            autoGenerateColumns: false,
            dataSource: _constants.JobsWebSvcPath,
            responseDataKey: "results",
            autoCommit: true,
            features: [
                //{
                //    name: "Sorting",
                //    sortingDialogContainment: "window"
                //},
                //{
                //    name: "Filtering",
                //    type: "local",
                //    columnSettings: [
                //        {
                //            columnKey: "ImageUrl",
                //            allowFiltering: false
                //        },
                //        {
                //            columnKey: "InStock",
                //            condition: "greaterThan"
                //        }
                //    ]
                //},
                //{
                //    name: "GroupBy",
                //    columnSettings: [
                //        {
                //            columnKey: "CustomerName",
                //            isGroupBy: true
                //        }
                //    ]
                //},
                {
                    name: "Selection"
                },
                {
                    name: "Paging", type: "remote", pageSize: 10
                },
                {
                    name: "Resizing"
                },
                {
                    name: "Updating",
                    editMode: "dialog",
                    enableAddRow: false,
                    columnSettings: [
                        {
                            columnKey: "ImageUrl",
                            readOnly: false
                        }
                    ]
                }
            ]
        });
    }

}
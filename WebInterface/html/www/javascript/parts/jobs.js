function Jobs()
{
    this.InitGrid = function InitGrid()
    {
        init();

        $("#grid").on("iggridupdatingrowdeleting", onDelete);
        $("#grid").on("iggridupdatingeditrowending", onUpdate);
        $("#grid").on("iggridupdatingrowadding", onInsert);        
    }


    
    function onInsert(evt, ui)
    {
        console.log("onInsert ");
        var restClient = new RestClient(_constants.JobsWebSvcPath);
        restClient.InsertJob(ui.values, function (restCallbackObj)
        {
            if (restCallbackObj.StatusCode != 200)
            {
                //
                // show the user an error message
                //
            }
        });
    }

    function onUpdate(evt, ui)
    {
        if (ui.update)
        {
            console.log("onUpdate " + ui.rowID);

            var restClient = new RestClient(_constants.JobsWebSvcPath);
            restClient.UpdateJob(ui.values, function (restCallbackObj)
            {
                if (restCallbackObj.StatusCode != 200)
                {
                    //
                    // show an error to the user
                    //
                }
            });
        }
    }

    function onDelete(evt, ui)
    {        
        console.log("onDelete " + ui.rowID);

        var restClient = new RestClient(_constants.JobsWebSvcPath);
        restClient.DeleteJob(ui.rowID, function (restCallbackObj)
        {
            if (restCallbackObj.StatusCode != 200)
            {
                //
                // show an error to the user
                //
            }
        });


        //var s = ui.owner.grid.dataSource._data.forEach(function (record)
        //{
        //    var r = record.Id;
        //});
    }

    function init()
    {
        $("#grid").igGrid({        
            primaryKey: "Id",
            //caption: "<span> <img src=\"//www.infragistics.com/media/441501/horz_logo.png\" alt=\"Infragistics\"></span>",
            width: '100%',
            columns: [
                { headerText: "Id", key: "Id", dataType: "number", width: "15%", hidden: true },
                { headerText: "ClientId", key: "ClientId", dataType: "number", width: "15%", hidden: true },
                { headerText: "LeadId", key: "LeadId", dataType: "number", width: "15%", hidden: true },
                { headerText: "CustomerName", key: "CustomerName", dataType: "string", width: "15%", hidden: false },
                { headerText: "Create Date", key: "CreateDate", dataType: "string", width: "25%" },
                { headerText: "Last Activity", key: "LastActivity", dataType: "string", width: "25%" },
                { headerText: "Status", key: "Status", dataType: "string", width: "25%" },
                { headerText: "Phone Number", key: "PhoneNum", dataType: "string", width: "25%" },
                { headerText: "City", key: "City", dataType: "string", width: "25%" },
                { headerText: "Zipcode", key: "Zipcode", dataType: "string", width: "25%" },
                { headerText: "Email", key: "Email", dataType: "string", width: "25%" },
                { headerText: "Assignedto", key: "Assignedto", dataType: "string", width: "25%", hidden: true },
                { headerText: "ShipTo", key: "ShipToAddress", dataType: "string", width: "25%", hidden: true  },
                { headerText: "JobType", key: "JobType", dataType: "string", width: "25%", hidden: true  },
                { headerText: "IsActive", key: "IsActive", dataType: "string", width: "25%", hidden: true  },
                { headerText: "InsuranceEmail", key: "InsuranceEmail", dataType: "string", width: "25%", hidden: true  },
                { headerText: "InsuranceFax", key: "InsuranceFax", dataType: "string", width: "25%", hidden: true  },
                { headerText: "PaymentType", key: "PaymentType", dataType: "string", width: "25%", hidden: true  },
                { headerText: "GrossProfit", key: "GrossProfit", dataType: "string", width: "25%", hidden: true  },
                { headerText: "OverheadCosts", key: "OverheadCosts", dataType: "string", width: "25%", hidden: true  },
                { headerText: "Commission", key: "Commission", dataType: "string", width: "25%", hidden: true  },
                { headerText: "IsTruedUp", key: "IsTruedUp", dataType: "string", width: "25%", hidden: true  },
                { headerText: "LastTruedDate", key: "LastTruedUpDate", dataType: "string", width: "25%", hidden: true },
                { headerText: "LastTruedUpPersion", key: "LastTruedUpPersion", dataType: "string", width: "25%", hidden: true },
                { headerText: "CommissionBalance", key: "CommissionBalance", dataType: "string", width: "25%", hidden: true },
                { headerText: "ContractAmount", key: "ContractAmount", dataType: "string", width: "25%", hidden: true },
                { headerText: "PaymentNotes", key: "", dataType: "string", width: "25%", hidden: true },
                { headerText: "CommissionPercentage", key: "CommisionPercentage", dataType: "string", width: "25%", hidden: true },
                { headerText: "CoClient", key: "CoClient", dataType: "string", width: "25%", hidden: true },
                { headerText: "Permit Number", key: "PermitNumber", dataType: "string", width: "25%", hidden: true },
            ],
            autofitLastColumn: false,
            autoGenerateColumns: false,
            dataSource: _constants.JobsWebSvcPath,
            responseDataKey: "Records",
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
                    name: "Paging", type: "remote", pageSize: 10, pageSizeUrlKey: "take", pageIndexUrlKey: "page", recordCountKey: "TotalRecordsCount"
                },
                {
                    name: "Resizing"
                },
                {
                    name: "Updating",
                    editMode: "dialog",
                    enableAddRow: true,
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
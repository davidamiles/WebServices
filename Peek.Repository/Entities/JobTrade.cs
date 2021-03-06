//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Peek.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobTrade
    {
        public int Id { get; set; }
        public int JobID { get; set; }
        public Nullable<int> TradePO { get; set; }
        public string TradeStatus { get; set; }
        public Nullable<System.DateTime> DateToStart { get; set; }
        public Nullable<double> AmountContracted { get; set; }
        public string EstimatorName { get; set; }
        public string TradeNotes { get; set; }
        public Nullable<int> ContactID { get; set; }
        public Nullable<System.DateTime> DateToEnd { get; set; }
        public Nullable<double> TotalHours { get; set; }
        public string TradeSubType { get; set; }
        public string BrandType { get; set; }
        public string ColorStyle { get; set; }
        public Nullable<int> LeadID { get; set; }
        public Nullable<bool> LeadToJob { get; set; }
    }
}

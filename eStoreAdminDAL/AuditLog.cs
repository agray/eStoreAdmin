//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eStoreAdminDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuditLog
    {
        public int ID { get; set; }
        public int ErrorNum { get; set; }
        public string StoreName { get; set; }
        public int TypeID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
        public string Data4 { get; set; }
        public string Status { get; set; }
        public string LongData { get; set; }
    }
}
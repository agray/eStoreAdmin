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
    
    public partial class SavedSearch
    {
        public int ID { get; set; }
        public System.Guid UserID { get; set; }
        public string Name { get; set; }
        public string Criteria { get; set; }
    }
}
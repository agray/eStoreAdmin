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
    
    public partial class SocialNetworking
    {
        public int ID { get; set; }
        public int DepID { get; set; }
        public int CatID { get; set; }
        public int ProdID { get; set; }
        public int HasSocialNetworking { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Department Department { get; set; }
        public virtual Product Product { get; set; }
    }
}

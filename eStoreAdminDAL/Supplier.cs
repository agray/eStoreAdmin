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
    
    public partial class Supplier
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string BusinessPhone { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string CitySuburb { get; set; }
        public string StateProvinceRegion { get; set; }
        public int ZipPostcode { get; set; }
        public string Country { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}

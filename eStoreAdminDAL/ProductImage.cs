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
    
    public partial class ProductImage
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public int IsDefault { get; set; }
        public string imgPath { get; set; }
        public string imgName { get; set; }
    
        public virtual Product Product { get; set; }
    }
}

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
    
    public partial class ShipToMode
    {
        public ShipToMode()
        {
            this.Orders = new HashSet<Order>();
            this.ShipCosts = new HashSet<ShipCost>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShipCost> ShipCosts { get; set; }
    }
}
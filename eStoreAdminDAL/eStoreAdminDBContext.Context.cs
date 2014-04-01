﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class eStoreAdminEntities : DbContext
    {
        public eStoreAdminEntities()
            : base("name=eStoreAdminEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<BadWord> BadWords { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CCExpiryMonth> CCExpiryMonths { get; set; }
        public DbSet<CCExpiryYear> CCExpiryYears { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<SavedSearch> SavedSearches { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<ShipCost> ShipCosts { get; set; }
        public DbSet<ShipToCountry> ShipToCountries { get; set; }
        public DbSet<ShipToMode> ShipToModes { get; set; }
        public DbSet<SocialNetworking> SocialNetworkings { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Zone> Zones { get; set; }
    }
}

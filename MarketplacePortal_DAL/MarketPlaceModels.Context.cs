﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarketplacePortal_DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JooleEntities : DbContext
    {
        public JooleEntities()
            : base("name=JooleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblDepartment> tblDepartments { get; set; }
        public virtual DbSet<tblManufacturer> tblManufacturers { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProperty> tblProperties { get; set; }
        public virtual DbSet<tblPropertyValue> tblPropertyValues { get; set; }
        public virtual DbSet<tblSubcategory> tblSubcategories { get; set; }
        public virtual DbSet<tblTechSpecsFilter> tblTechSpecsFilters { get; set; }
        public virtual DbSet<tblTypeFilter> tblTypeFilters { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    }
}

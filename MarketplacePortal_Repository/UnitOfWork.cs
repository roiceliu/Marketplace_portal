﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplacePortal_DAL;

namespace MarketplacePortal_Repository
{   public class UnitOfWork : IDisposable
    {
        private JooleEntities context;

        private GenericRepository<tblDepartment> departmentRepository;
        private GenericRepository<tblManufacturer> manufacturerRepository;
        private GenericRepository<tblProduct> productRepository;
        private GenericRepository<tblProperty> propertyRepository;
        private GenericRepository<tblPropertyValue> properyValueRepository;
        private GenericRepository<tblSubcategory> subcategoryRepository;
        private GenericRepository<tblTechSpecsFilter> techSpecsFilterRepository;
        private GenericRepository<tblTypeFilter> typeFilterRepository;
        private GenericRepository<tblUser> userRepository;
        
        public UnitOfWork(JooleEntities context)
        {
            this.context = context;

            this.departmentRepository = new GenericRepository<tblDepartment>(context);
            this.manufacturerRepository = new GenericRepository<tblManufacturer>(context);
            this.productRepository = new GenericRepository<tblProduct>(context);
            this.propertyRepository = new GenericRepository<tblProperty>(context);
            this.properyValueRepository = new GenericRepository<tblPropertyValue>(context);
            this.subcategoryRepository = new GenericRepository<tblSubcategory>(context);
            this.techSpecsFilterRepository = new GenericRepository<tblTechSpecsFilter>(context);
            this.typeFilterRepository = new GenericRepository<tblTypeFilter>(context);
            this.userRepository = new GenericRepository<tblUser>(context);
        }

        public GenericRepository<tblDepartment> DepartmentRepository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<tblDepartment>(context);
                }
                return departmentRepository;
            }
        }

        public GenericRepository<tblManufacturer> ManufacturerRepository
        {
            get
            {

                if (this.manufacturerRepository == null)
                {
                    this.manufacturerRepository = new GenericRepository<tblManufacturer>(context);
                }
                return manufacturerRepository;
            }
        }

        public GenericRepository<tblProduct> ProductRepository
        {
            get
            {

                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<tblProduct>(context);
                }
                return productRepository;
            }
        }
        public GenericRepository<tblProperty> PropertyRepository
        {
            get
            {

                if (this.propertyRepository == null)
                {
                    this.propertyRepository = new GenericRepository<tblProperty>(context);
                }
                return propertyRepository;
            }
        }
        public GenericRepository<tblPropertyValue> PropertyValueRepository
        {
            get
            {

                if (this.properyValueRepository == null)
                {
                    this.properyValueRepository = new GenericRepository<tblPropertyValue>(context);
                }
                return properyValueRepository;
            }
        }
        public GenericRepository<tblSubcategory> SubcategoryRepository
        {
            get
            {

                if (this.subcategoryRepository == null)
                {
                    this.subcategoryRepository = new GenericRepository<tblSubcategory>(context);
                }
                return subcategoryRepository;
            }
        }
        public GenericRepository<tblTechSpecsFilter> TechSpecsFilterRepository
        {
            get
            {

                if (this.techSpecsFilterRepository == null)
                {
                    this.techSpecsFilterRepository = new GenericRepository<tblTechSpecsFilter>(context);
                }
                return techSpecsFilterRepository;
            }
        }
        public GenericRepository<tblTypeFilter> TypeFilterRepository
        {
            get
            {

                if (this.typeFilterRepository == null)
                {
                    this.typeFilterRepository = new GenericRepository<tblTypeFilter>(context);
                }
                return typeFilterRepository;
            }
        }
        public GenericRepository<tblUser> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<tblUser>(context);
                }
                return userRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

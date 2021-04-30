using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplacePortal_Repository;
using MarketplacePortal_DAL;

namespace MarketplacePortal_Service
{
    public class Service
    {
        
        UnitOfWork uow = new UnitOfWork();

        public Service() { 

        
        }
        public List<tblDepartment> GetAllDepartments()
        {
            return uow.DepartmentRepository.GetAll();
        }

        public List<tblManufacturer> GetAllManufacturers()
        {
            return uow.ManufacturerRepository.GetAll();
        }

        public List<tblProduct> GetAllProducts()
        {
            return uow.ProductRepository.GetAll();
        }

        public List<tblProperty> GetAllProperties()
        {
            return uow.PropertyRepository.GetAll();
        }



        public void Save() {

            uow.Save();
        }

    }
}

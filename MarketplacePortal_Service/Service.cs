using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplacePortal_Repository;
using MarketplacePortal_DAL;

namespace MarketplacePortal_Service
{
    //work as a place to another class to get data from repository
    public class Service
    {
        
        UnitOfWork uow = new UnitOfWork();

      
        public IEnumerable<tblDepartment> GetAllDepartments()
        {
            return uow.DepartmentRepository.GetAll();
        }

        public IEnumerable<tblManufacturer> GetAllManufacturers()
        {
            return uow.ManufacturerRepository.GetAll();
        }

        public IEnumerable<tblProduct> GetAllProducts()
        {
            return uow.ProductRepository.GetAll();
        }

        public IEnumerable<tblProperty> GetAllProperties()
        {
            return uow.PropertyRepository.GetAll();
        }



        public void Save() {

            uow.Save();
        }

    }
}

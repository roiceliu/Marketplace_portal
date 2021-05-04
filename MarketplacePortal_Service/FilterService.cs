using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplacePortal_Repository;
using MarketplacePortal_DAL;

namespace MarketplacePortal_Service
{
     public class FilterService
    {
        UnitOfWork uow = new UnitOfWork();

        public FilterService()
        {


        }

        public List<tblProduct> GetProductsBetweenModelYear(int min, int max)
        {
            return uow.ProductRepositoryFilter().GetProductsBetweenModelYear(min, max);

        }

        public int GetPropertyIDByName(string propertyName)
        {
            return uow.ProductRepositoryFilter().GetPropertyIDByName(propertyName);
        }


        //get subcategry ID by name
        public List<tblProduct> GetProductsByPropertyName(string propertyName)
        {
            return uow.ProductRepositoryFilter().GetProductsByPropertyName(propertyName);
        }

        //get all table property values
        public IEnumerable<tblProperty> GetAllProperty()
        {
            return uow.PropertyRepository.GetAll();
        }

        //get all table property values
        public IEnumerable<tblPropertyValue> GetAlltblPropertyValues()
        {
            return uow.PropertyValueRepository.GetAll();
        }

        //get all products
        public IEnumerable<tblProduct> GetAllProducts()
        {
            return uow.ProductRepository.GetAll();
        }

        //gets products by subcategory
        public List<tblProduct> GetProductsBySubCategory(string subcategory)
        {
            return uow.ProductRepositoryFilter().GetProductBySubcategory(subcategory);
        }

        //gets products by produc type
        public List<tblProduct> GetProductsByProductType(string productType)
        {
            return uow.ProductRepositoryFilter().GetProductByProductType(productType);
        }        

        //gets products by produc type
        public List<string> GetTypesBySubcategory(string subcategory)
        {
            return uow.ProductRepositoryFilter().GetTypesBySubcategory(subcategory);
        }

        //Get product by product id
        public List<tblProduct> GetProductsByProductID(int productID)
        {
            return uow.CompareRepository().GetProductsByProductID(productID);
        }

        //get manufacturer name from <tblManufacturer> using manufacturer id 

        public string GetManufacturerNameByID(int manufacturerID)
        {
            return uow.CompareRepository().GetManufacturerNameByID(manufacturerID);

        }

        public void Save()
        {

            uow.Save();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplacePortal_Repository;
using MarketplacePortal_DAL;

namespace MarketplacePortal_Service
{
    public class CompareService
    {
        public static readonly JooleEntities context = new JooleEntities();
        UnitOfWork uow = new UnitOfWork();
        public List<ProductRepository> Products { get; set; }

        public CompareService()
        {


        }

        public int GetPropertyIDByName(string propertyName)
        {
            return uow.IProductRepository().GetPropertyIDByName(propertyName);
        }

        //get all table properties
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

        //gets products by producID
        public List<tblProduct> GetProductsByProductID(string productID)
        {
            return uow.IProductRepository().GetProductByProductID(productID);
        }


   
        public void Save()
            {

                uow.Save();
            }

        }
    }




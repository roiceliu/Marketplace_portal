using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketplacePortal_Service
{
    public interface IProductService
    {
        IEnumerable<tblProduct> GetAllTblProduct();
        tblProduct GetByID(int id);
        object GetProductDetails(int id);
    }

    public class ProductService : IProductService
    {
        UnitOfWork uow = new UnitOfWork();

        
        public IEnumerable<tblProduct> GetAllTblProduct()
        {
            IRepository<tblProduct> productRepo = uow.ProductRepository;
            return productRepo.GetAll();
        }


        public tblProduct GetByID(int id)
        {
            return uow.ProductRepository.GetByID(id);
        } 


        //format all the product info according to Controller from UOW and get it compiled well

        //TODO:

        public object GetProductDetails(int id)
        {
            tblProduct product = GetByID(id);

            //getting propertyID regular way is to use for loop on getting all property out, but here I only get some sample: so hardcode to get id out 

            //1. Get property name by propertyid: 1, 5,6

            //get a property value of all products
            var productProps = from property in uow.PropertyValueRepository.GetAll()
                               where property.ProductID == id
                               select property;

         
            return productProps;
        }

        public void Save()
        {
            uow.Save();
        }
    }
}

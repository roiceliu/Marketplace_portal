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
        tblProduct GetAll();

        }
        class ProductService : IProductService
    {
            UnitOfWork uow = new UnitOfWork();

        /*
         
        public List<tblProduct> GetAllProducts()
        {
            return uow.ProductRepository.GetAll();
        }*/
        public IEnumerable<tblProduct> GetAllTblProduct()
            {
                IRepository<tblProduct> productRepo = uow.ProductRepository;
                return productRepo.GetAll();
            }

        public tblProduct GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

            uow.Save();
        }
    }
}

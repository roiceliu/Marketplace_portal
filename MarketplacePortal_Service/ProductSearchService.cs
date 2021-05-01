using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketplacePortal_Service
{

    //public interface IProductSearchService
    //{
    //    IEnumerable<tblTechSpecsFilter> GetAllTblTechSpecsFilter();
    //    tblProduct GetAll();

    //}

    public class ProductSearchService
    {
        readonly UnitOfWork uow = new UnitOfWork();

        public IEnumerable<tblProduct> getProducts()
        {
            IRepository<tblProduct> productRepository = uow.ProductRepository;
            return productRepository.GetAll();
        }

        public String[] getProductNames()
        {
            tblProduct[] products = (tblProduct[]) getProducts().ToArray();
            string[] productNames = new string[products.Length];
            for(var i = 0; i < products.Length; i++)
            {
                productNames[i] = products[i].ProductName;
            }
            return productNames;
        }

        //public List<tblProduct> getProducts()
        //{
        //    return (List<tblProduct>) uow.PropertyRepository.GetAll();
        //}
    }
}

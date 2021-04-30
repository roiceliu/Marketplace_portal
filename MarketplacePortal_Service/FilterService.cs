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

        public List<tblProduct> GetProductsBySubCategory(string subcategory)
        {
            return uow.ProductRepositoryFilter().GetProductBySubcategory(subcategory);
        }

        public List<tblProduct> GetProductsByProductType(string productType)
        {
            return uow.ProductRepositoryFilter().GetProductByProductType(productType);
        }

        public void Save()
        {

            uow.Save();
        }
    }
}

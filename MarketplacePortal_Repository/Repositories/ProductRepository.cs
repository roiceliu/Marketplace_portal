using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplacePortal_DAL;

namespace MarketplacePortal_Repository
{
    public class ProductRepository:GenericRepository<tblProduct>
    {
        
        public ProductRepository(JooleEntities context) : base(context) {
            
        }

        //get products by the subcategories
        public List<tblProduct> GetProductBySubcategory(string subcategoryname) {

            var query = from tblSubcategory in context.Set<tblSubcategory>()
                        join tblProduct in context.Set<tblProduct>()
                            on new { Id = (int?)tblSubcategory.SubcategoryID, tblSubcategory.SubcategoryName }
                            equals new { Id = tblProduct.SubcategoryID, SubcategoryName = subcategoryname }
                        select new{tblProduct};

            List<tblProduct> products = new List<tblProduct>();

            foreach (var item in query)
            {
                products.Add(item.tblProduct);
            }
            return products;
        }


        //get Products by the product type
        public List<tblProduct> GetProductByProductType(string productType)
        {
            var query = from tblPropertyValue in context.Set<tblPropertyValue>()
                        join tblProduct in context.Set<tblProduct>()
                            on new { Id = (int?)tblPropertyValue.ProductID, tblPropertyValue.Value }
                            equals new { Id = (int?)tblProduct.ProductID, Value = productType }
                        select new { tblProduct };

            List<tblProduct> products = new List<tblProduct>();

            foreach (var item in query)
            {
                products.Add(item.tblProduct);
            }
            return products;
        }
    }
}

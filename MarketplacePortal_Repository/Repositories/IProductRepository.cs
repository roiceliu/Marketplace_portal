using MarketplacePortal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplacePortal_Repository
{
    public class IProductRepository : GenericRepository<tblProduct>
    {

        public IProductRepository(JooleEntities context) : base(context)
        {

        }

        
        //get Products by the manufacturerName
        public List<tblProduct> GetProductDetailsByProductID(int productID)
        {       /*
            var prquery = from tblPropertyValue in context.Set<tblPropertyValue>()
                          join tblProduct in context.Set<tblProduct>()
                           on new { Id = (int?)tblPropertyValue.ProductID, tblPropertyValue.Value }
                           equals new { Id = (int?)tblProduct.ProductID, Value = productID }
                        select new { tblProduct };*/

            List<tblProduct> products = new List<tblProduct>();
            /*
            foreach (var item in prquery)
            {
                products.Add(item.tblProduct);
            }*/
            return products;
        }
    
        /*
        public List<tblProperty> GetPropertyByPropertyID(string propertyID)
        {
            throw new NotImplementedException();
        }

        public List<tblProperty> GetPropertyValueByPropertyValue(string propertyValue)
        {
            throw new NotImplementedException();
        }
    */

        /*
        var prQuery = from tblProduct in context.Set<tblProduct>()
                      join tblManufacturer in context.Set<tblManufacturer>() on tblManufacturer.ManufacturerID equals tblProduct.ManufacturerID
                      join tblProperty in context.Set<tblProperty>() on tblProduct.ProductID equals tblProperty.ProductID
                      join tblPropertyValue in context.Set<tblPropertyValue>() on tblProperty.PropertyID equals tblPropertyValue.PropertyID
                      join tblTypeFilter in context.Set<tblTypeFilter>() on tblPropertyValue.PropertyID equals tblTypeFilter.PropertyID
                      join tblTechSpecsFilter in context.Set<tblTechSpecsFilter>() on tblPropertyValue.PropertyID equals tblTechSpecsFilter.PropertyID
                      where 1 == 1

                      select new { tblProduct };*/
    }
}


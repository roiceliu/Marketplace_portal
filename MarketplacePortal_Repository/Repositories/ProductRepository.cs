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

        public List<tblProduct> GetProductsBetweenModelYear(int min, int max)
        {

            var query = from product in context.Set<tblProduct>()
                         select product;

            List<tblProduct> products = new List<tblProduct>();
            List<tblProduct> productsFilter = new List<tblProduct>();

            foreach (var item in query)
            {
                products.Add(item);
            }
            foreach (tblProduct product in products) {
                if (int.Parse(product.ModelYear) >= min && int.Parse(product.ModelYear) <= max) {
                    productsFilter.Add(product);
                }

            }
            return productsFilter;


        }

        public int GetPropertyIDByName(string propertyName)
        {
            var query = from property in context.Set<tblProperty>()
                        where property.PropertyName == propertyName
                        select property;
            int id =-1;

            foreach (var item in query)
            {
                id = item.PropertyID;
            }
            return id;

        }

            //get products by the subcategories
        public List<tblProduct> GetProductsByPropertyName(string propertyName)
        {

            var query = from property in context.Set<tblProperty>()
                                       where property.PropertyName == propertyName
                                       select property;
            int id = -1;
            foreach (var item in query)
            {
                id = item.PropertyID;
            }
            

            var query2 = from tblPropertyValue in context.Set<tblPropertyValue>()
                        join tblProduct in context.Set<tblProduct>()
                            on new { Id = (int?)tblPropertyValue.ProductID, tblPropertyValue.PropertyID }
                            equals new { Id = (int?)tblProduct.ProductID, PropertyID = id }
                        select new { tblProduct };

            List<tblProduct> products = new List<tblProduct>();

            foreach (var item in query2)
            {
                products.Add(item.tblProduct);
            }

            return products;

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

        
        public List<string> GetTypesBySubcategory(string subcategory)
        {

            var query = from tblSubcategory in context.Set<tblSubcategory>()
                        join tblTypeFilter in context.Set<tblTypeFilter>()
                            on new { Id = (int?)tblSubcategory.SubcategoryID, tblSubcategory.SubcategoryName }
                            equals new { Id = (int?)tblTypeFilter.SubcategoryID, SubcategoryName = subcategory }
                        select new { tblTypeFilter};

            /*IEnumerable<tblTypeFilter> result = new List<tblTypeFilter>();
             

            foreach (var item in query)
            {
                result.ToList().Add(item.tblTypeFilter);
            }

            List<string> types = result.Select(o => o.TypeValue).Distinct().ToList();


            return types;*/

            List<string> result = new List<string>();
            foreach (var item in query)
            {
                result.Add(item.tblTypeFilter.TypeValue);
            }
            return result;


        }

        //Get product by product id from tblProduct
        public List<tblProduct> GetProductsByProductID(int productID)
        {
            var query = from product in context.Set<tblProduct>()
                        where product.ProductID == productID
                        select product;
                        

            List<tblProduct> productInfo = new List<tblProduct>();

            foreach (var product in query)
            {
                productInfo.Add(product);
            }

            return productInfo;
        }

        //get manufacturer name from <tblManufacturer> using manufacturer id 
        public string GetManufacturerNameByID(int manufacturerID)
        {
            var query = from manufacturer in context.Set<tblManufacturer>()
                        where manufacturer.ManufacturerID == manufacturerID
                        select manufacturer;

            string name = "";

            foreach (var item in query)
            {
                name = item.ManufacturerName;
            }
            return name;

        }


    }
}

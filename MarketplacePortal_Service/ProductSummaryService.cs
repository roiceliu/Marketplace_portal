using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplacePortal_Service
{
    public class ProductSummaryService
    {
        readonly UnitOfWork uow = new UnitOfWork();

        //Need this to get DESCRIPTION
        public IEnumerable<tblProduct> getProducts()
        {
            IRepository<tblProduct> propertyRepository = uow.ProductRepository;
            return propertyRepository.GetAll();
        }

        public IEnumerable<tblProperty> getProperties()
        {
            IRepository<tblProperty> propertyRepository = uow.PropertyRepository;
            return propertyRepository.GetAll();
        }

        public IEnumerable<tblPropertyValue> getPropertyValues()
        {
            IRepository<tblPropertyValue> propertyValueRepository = uow.PropertyValueRepository;
            return propertyValueRepository.GetAll();
        }

        public string[] getDescription(int productID) //WIP
        {
            List<tblProduct> products = getProducts().ToList();
            //for(int i = 0; i < products.Count(); i++)
            //{
            //    if(products[i].ProductID.Equals(productID))
            //    {
            //        return new string[] {products[i].ManufacturerID}
            //    }
            //}

            string[] blah = new string[0];
            return blah;
        }


        //WARNING: DOES NOT RETRIEVE THE DESCRIPTION, WHICH IS FOUND IN THE TBLPRODUCT ITSELF
        public List<string[]> getProperties(int productID)
        {
            //Key: prouctID, Value: [propertyID, isType]
            Dictionary<int, string[]> propertiesDict = getProperties().ToDictionary(x => x.PropertyID, x => new string[] { x.PropertyName, x.IsType.ToString() });
            List<tblPropertyValue> propertyValues = getPropertyValues().ToList();
            List<string[]> properties = new List<string[]>();

            //String array of [PropertyName, IsType, Value, HasMinMax, Max, Min]
            //If a value is null, we set it to "NULL"
            for (int i = 0; i < propertyValues.Count(); i++)
            {
                if (propertyValues[i].ProductID.Equals(productID)) {
                    string[] propertyInfo = new string[6];
                    propertyInfo[0] = propertiesDict[propertyValues[i].PropertyID][0];
                    propertyInfo[1] = propertiesDict[propertyValues[i].PropertyID][1];
                    propertyInfo[2] = propertyValues[i].Value == null ? "NULL" : propertyValues[i].Value;
                    propertyInfo[3] = propertyValues[i].HasMinMax.ToString();
                    propertyInfo[4] = propertyValues[i].Max == null ? "NULL" : propertyValues[i].Max.ToString();
                    propertyInfo[5] = propertyValues[i].Min == null ? "NULL" : propertyValues[i].Min.ToString();

                    properties.Add(propertyInfo);
                }
            }
            return properties;
        }
    }
}

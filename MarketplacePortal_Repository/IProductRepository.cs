using MarketplacePortal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplacePortal_Repository
{
        public interface IProductRepository : IDisposable
        {
            IEnumerable<tblProduct> GetStudents();
           tblProduct GetProductByID(int ProductID);
            void InsertProduct(tblProduct product);
            void DeleteProduct(int ProductID);
            void UpdateProduct(tblProduct product);
            void Save();
        }
    }


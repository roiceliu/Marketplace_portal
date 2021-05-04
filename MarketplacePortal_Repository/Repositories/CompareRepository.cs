using MarketplacePortal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplacePortal_Repository.Repositories
{
    public class CompareRepository
    {
        public class ProductRepository : GenericRepository<tblProduct>
        {

            public ProductRepository(JooleEntities context) : base(context)
            {

            }



        }
    }
}

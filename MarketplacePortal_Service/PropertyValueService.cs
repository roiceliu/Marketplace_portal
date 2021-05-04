using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketplacePortal_Service
{
    public interface IPropertyValueService
    {
        IEnumerable<tblPropertyValue> GetAllTblPropertyValue();
        tblPropertyValue GetAll();

    }
    public class PropertyValueService : IPropertyValueService
    {
        UnitOfWork uow = new UnitOfWork();

        public IEnumerable<tblPropertyValue> GetAllTblPropertyValue()
        {
            IRepository<tblPropertyValue> pvRepo = uow.PropertyValueRepository;
            return pvRepo.GetAll();
        }

        public tblPropertyValue GetAll()
        {
            throw new NotImplementedException();
        }
        public void Save()
        {

            uow.Save();
        }
    }
}

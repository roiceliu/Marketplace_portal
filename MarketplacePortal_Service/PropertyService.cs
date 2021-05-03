using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketplacePortal_Service
{
    public interface IPropertyService
    {
        IEnumerable<tblProperty> GetAllTblProperty();
        tblProperty GetAll();

    }
    class PropertyService : IPropertyService
    {
        UnitOfWork uow = new UnitOfWork();


        public IEnumerable<tblProperty> GetAllTblProperty()
        {
            IRepository<tblProperty> propertyRepo = uow.PropertyRepository;
            return propertyRepo.GetAll();
        }

        public tblProperty GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

            uow.Save();
        }
    }
}

using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketplacePortal_Service
{
    public interface ITypeFilterService
    {
        IEnumerable<tblTypeFilter> GetAllTblTypeFilter();
        tblTypeFilter GetAll();

    }
    class typeFilterService : ITypeFilterService
    {
        UnitOfWork uow = new UnitOfWork();


        public IEnumerable<tblTypeFilter> GetAllTblTypeFilter()
        {
            IRepository<tblTypeFilter> tfRepo = uow.TypeFilterRepository;
            return tfRepo.GetAll();
        }

        public tblTypeFilter GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

            uow.Save();
        }
    }
}

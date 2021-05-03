using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketplacePortal_Service
{
    public interface ITechSpecsFilterService
    {
        IEnumerable<tblTechSpecsFilter> GetAllTblTechSpecsFilter();
        tblTechSpecsFilter GetAll();

    }
    class techSpecsFilterService : ITechSpecsFilterService
    {
        UnitOfWork uow = new UnitOfWork();


        public IEnumerable<tblTechSpecsFilter> GetAllTblTechSpecsFilter()
        {
            IRepository<tblTechSpecsFilter> tsRepo = uow.TechSpecsRepository;
            return tsRepo.GetAll();
        }

        public tblTechSpecsFilter GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

            uow.Save();
        }
    }
}

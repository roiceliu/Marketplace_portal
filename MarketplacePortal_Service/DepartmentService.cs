using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketplacePortal_Service
{
    public interface IDepartmentService
    {
        IEnumerable<tblDepartment> GetAllDepartments();
        tblDepartment GetAll();

    }
    class DepartmentService : IDepartmentService
    {
        UnitOfWork uow = new UnitOfWork();

        /*
         
        public List<tblDepartment> GetAllDepartments()
        {
            return uow.DepartmentRepository.GetAll();
        }*/
        public IEnumerable<tblDepartment> GetAllDepartments()
        {
            IRepository<tblDepartment> deptRepo = uow.DepartmentRepository;
            return deptRepo.GetAll();
        }

        public tblDepartment GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

            uow.Save();
        }
    }
}

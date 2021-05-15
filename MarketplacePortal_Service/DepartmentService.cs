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
      
      

    }
   public class DepartmentService : IDepartmentService
    {
        private UnitOfWork uow = new UnitOfWork();

 
        public IEnumerable<tblDepartment> GetAllDepartments()
        {
            IRepository<tblDepartment> deptRepo = uow.DepartmentRepository;
            return deptRepo.GetAll();
        }




      

    }
}

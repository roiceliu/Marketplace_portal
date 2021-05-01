using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketplacePortal_Service
{

    //public interface IProductSearchService
    //{
    //    IEnumerable<tblTechSpecsFilter> GetAllTblTechSpecsFilter();
    //    tblProduct GetAll();

    //}

    public class ProductSearchService
    {
        readonly UnitOfWork uow = new UnitOfWork();

        public IEnumerable<tblProduct> getProducts()
        {
            IRepository<tblProduct> productRepository = uow.ProductRepository;
            return productRepository.GetAll();
        }

        public String[] getProductNames()
        {
            tblProduct[] products = (tblProduct[]) getProducts().ToArray();
            string[] productNames = new string[products.Length];
            for(var i = 0; i < products.Length; i++)
            {
                productNames[i] = products[i].ProductName;
            }
            return productNames;
        }

        public int[] getProductIDs()
        {
            tblProduct[] products = (tblProduct[])getProducts().ToArray();
            int[] productIDs = new int[products.Length];
            for (var i = 0; i < products.Length; i++)
            {
                productIDs[i] = products[i].ProductID;
            }
            return productIDs;
        }


        public IEnumerable<tblDepartment> getDepartments()
        {
            IRepository<tblDepartment> departmentRepository = uow.DepartmentRepository;
            return departmentRepository.GetAll();
        }

        public String[] getDepartmentNames()
        {
            tblDepartment[] departments = (tblDepartment[])getDepartments().ToArray();
            string[] productNames = new string[departments.Length];
            for (var i = 0; i < departments.Length; i++)
            {
                productNames[i] = departments[i].DepartmentName;
            }
            return productNames;
        }

        //public List<tblProduct> getProducts()
        //{
        //    return (List<tblProduct>) uow.PropertyRepository.GetAll();
        //}
    }
}

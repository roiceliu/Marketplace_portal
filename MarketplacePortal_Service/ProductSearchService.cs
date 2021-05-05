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
            tblProduct[] products = (tblProduct[])getProducts().ToArray();
            string[] productNames = new string[products.Length];
            for (var i = 0; i < products.Length; i++)
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

        public int[] getProductSubcategoryIDs()
        {
            tblProduct[] products = (tblProduct[])getProducts().ToArray();
            int[] productSubcategoryIDs = new int[products.Length];
            for (var i = 0; i < products.Length; i++)
            {
                productSubcategoryIDs[i] = products[i].SubcategoryID.Value;
            }
            return productSubcategoryIDs;
        }

        public IEnumerable<tblSubcategory> getSubcategories()
        {
            IRepository<tblSubcategory> subcategoryRepository = uow.SubcategoryRepository;
            return subcategoryRepository.GetAll();
        }
        public IEnumerable<tblDepartment> getDepartments()
        {
            IRepository<tblDepartment> departmentRepository = uow.DepartmentRepository;
            return departmentRepository.GetAll();
        }

        public String[] getDepartmentNames()
        {
            tblDepartment[] departments = (tblDepartment[])getDepartments().ToArray();
            string[] departmentNames = new string[departments.Length];
            for (var i = 0; i < departments.Length; i++)
            {
                departmentNames[i] = departments[i].DepartmentName;
            }
            return departmentNames;
        }



        //The Key is SubcategoryID and the Value is DepartmentName
        //SubcategoryID is a string because jQuery doesn't allow conversions when the Key is not a string
        public Dictionary<string, string> getSubcategoryDepartmentDict()
        {
            Dictionary<string, string> subCategoryDepartmentDict = new Dictionary<string, string>();

            tblSubcategory[] subcategories = (tblSubcategory[])getSubcategories().ToArray();
            Dictionary<int, string> departmentsDict = getDepartments().ToDictionary(x => x.DepartmentID, x => x.DepartmentName);

            for (int i = 0; i < subcategories.Length; i++)
            {
                if (!subCategoryDepartmentDict.ContainsKey(subcategories[i].SubcategoryID.ToString()))
                {
                    //DepartmentID is a nullable int, so we append .Value to the end. We should change this in our
                    //database so it can't be null. Since if it ever is, this'll default to 0 and we'll get unexpected behavior
                    subCategoryDepartmentDict.Add(subcategories[i].SubcategoryID.ToString(), departmentsDict[subcategories[i].DepartmentID.Value]);
                }
            }

            //tblProduct[] products = (tblProduct[])getProducts().ToArray();

            return subCategoryDepartmentDict;
        }
    }
}

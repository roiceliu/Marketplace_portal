using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using MarketplacePortal_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketplace_portal.Models;
using System.Reflection;

namespace Marketplace_portal.Controllers
{
    public class CompareController : Controller
    {
        public ActionResult Test()
        {
            List<int> productIdList = new List<int>();
            productIdList.Add(1);
            productIdList.Add(2);
            productIdList.Add(3);

            //convert ids to CompareList
            IProductService ps = new ProductService();
            IPropertyValueService pval = new PropertyValueService();
            CompareList list = new CompareList();

            foreach (int id in productIdList)
            {
                ProductDetails product = new ProductDetails();
                //info product's properties
                var query = from property in pval.GetAllTblPropertyValue()
                            where property.ProductID == id
                            select property;
               
                
                //Get Product property first
                product.Manufacturer = new ManufacturerService().GetByID(id).ManufacturerName;

                //Optimize: see if we can use foreach loop
                
                

                return RedirectToAction("TestCompare");
            }

        }
        public ActionResult Compare(CompareList list)
        {
            





            

            return View();
        }
    }
}
    /*
         public CompareController()
         {
             this.IProductRepository = new IProductRepository(new SchoolContext());
         }

         public StudentController(IStudentRepository studentRepository)
         {
             this.studentRepository = studentRepository;
         }

         //
         // GET: /Student/

         public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
         {
             ViewBag.CurrentSort = sortOrder;
             ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
             ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

             if (searchString != null)
             {
                 page = 1;
             }
             else
             {
                 searchString = currentFilter;
             }
             ViewBag.CurrentFilter = searchString;

             var students = from s in studentRepository.GetStudents()
                            select s;
             if (!String.IsNullOrEmpty(searchString))
             {
                 students = students.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                                        || s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
             }
             switch (sortOrder)
             {
                 case "name_desc":
                     students = students.OrderByDescending(s => s.LastName);
                     break;
                 case "Date":
                     students = students.OrderBy(s => s.EnrollmentDate);
                     break;
                 case "date_desc":
                     students = students.OrderByDescending(s => s.EnrollmentDate);
                     break;
                 default:  // Name ascending 
                     students = students.OrderBy(s => s.LastName);
                     break;
             }

             int pageSize = 3;
             int pageNumber = (page ?? 1);
             return View(students.ToPagedList(pageNumber, pageSize));
         }

         //
         // GET: /Student/Details/5

         public ViewResult Details(int id)
         {
             tblProduct product = IproductRepository.GetProductByID(id);
             return View(product);
         }
    }
    }*/
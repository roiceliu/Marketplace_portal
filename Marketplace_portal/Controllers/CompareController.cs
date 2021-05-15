//using MarketplacePortal_DAL;
//using MarketplacePortal_Repository;
//using MarketplacePortal_Service;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Marketplace_portal.Controllers
//{
//    public class CompareController : Controller
//    {
//        // GET: Compare
            
//            private readonly IProductService productService;
//            private readonly IPropertyService propertyService;
//            private readonly IPropertyValueService propertyValueService;
//            private readonly IManufacturerService ManufacturerService;
//            private readonly ITypeFilterService typeFilterService;
//            private readonly ITechSpecsFilterService techSpecsFilterService;



//        public CompareController(IProductService productService, IPropertyService propertyService, IPropertyValueService propertyValueService, IManufacturerService ManufacturerService, ITypeFilterService typeFilterService, ITechSpecsFilterService techSpecsFilterService)
//            {
//                this.productService = productService;
//                this.propertyService = propertyService; 
//                this.propertyValueService = propertyValueService;
//                this.ManufacturerService = ManufacturerService;
//                this.typeFilterService = typeFilterService;
//                this.techSpecsFilterService = techSpecsFilterService;


//        }
//    }
//    }
//    /*
//         public CompareController()
//         {
//             this.IProductRepository = new IProductRepository(new SchoolContext());
//         }

//         public StudentController(IStudentRepository studentRepository)
//         {
//             this.studentRepository = studentRepository;
//         }

//         //
//         // GET: /Student/

//         public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
//         {
//             ViewBag.CurrentSort = sortOrder;
//             ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
//             ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

//             if (searchString != null)
//             {
//                 page = 1;
//             }
//             else
//             {
//                 searchString = currentFilter;
//             }
//             ViewBag.CurrentFilter = searchString;

//             var students = from s in studentRepository.GetStudents()
//                            select s;
//             if (!String.IsNullOrEmpty(searchString))
//             {
//                 students = students.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
//                                        || s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
//             }
//             switch (sortOrder)
//             {
//                 case "name_desc":
//                     students = students.OrderByDescending(s => s.LastName);
//                     break;
//                 case "Date":
//                     students = students.OrderBy(s => s.EnrollmentDate);
//                     break;
//                 case "date_desc":
//                     students = students.OrderByDescending(s => s.EnrollmentDate);
//                     break;
//                 default:  // Name ascending 
//                     students = students.OrderBy(s => s.LastName);
//                     break;
//             }

//             int pageSize = 3;
//             int pageNumber = (page ?? 1);
//             return View(students.ToPagedList(pageNumber, pageSize));
//         }

//         //
//         // GET: /Student/Details/5

//         public ViewResult Details(int id)
//         {
//             tblProduct product = IproductRepository.GetProductByID(id);
//             return View(product);
//         }
//    }
//    }*/
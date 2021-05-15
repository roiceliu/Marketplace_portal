using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketplace_portal.Models;
using MarketplacePortal_Service;


namespace Marketplace_portal.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            
            SearchDepartment model = new SearchDepartment();
            model.departments = GetSelectList();
            return PartialView("Search", model);
        }

        private static IEnumerable<SelectListItem> GetSelectList()
        {
            IDepartmentService service = new DepartmentService();
            var list = service.GetAllDepartments();
            //converting the department list into drop down list items
            var DropDownList = list.Select(item => new SelectListItem { Value = item.DepartmentID.ToString(), Text = item.DepartmentName });

            return DropDownList;
        }

    }
}
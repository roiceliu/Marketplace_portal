using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MarketplacePortal_Repository;
using MarketplacePortal_DAL;

namespace Marketplace_portal.Controllers
{
    public class TestController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new JooleEntity());

        public ViewResult Index()
        {
            var Products = unitOfWork.ProductRepository.Get(includeProperties: "DepartmentName");

            return View(Products.ToList());
        }
    }
}
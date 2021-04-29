using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MarketplacePortal_Repository;

using MarketplacePortal_DAL;

//Delete this later
namespace MarketplacePortal_Service
{
    class TestController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new JooleEntities());

        public ViewResult Index()
        {
            var Products = unitOfWork.ProductRepository.Get(includeProperties: "DepartmentName");

            return View(Products.ToList());
        }
    }
}

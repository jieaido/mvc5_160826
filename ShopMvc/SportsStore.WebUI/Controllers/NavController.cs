using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public PartialViewResult Menu(string category=null)
        {
            ViewBag.selectedCategory = category;
            var categories =
                from product in repository.Products
                orderby product.Category
                select product.Category;
            return PartialView(categories.Distinct());

        }
    }
}
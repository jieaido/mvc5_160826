using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository iProductRepository;

        public AdminController(IProductRepository iProductRepository)
        {
            this.iProductRepository = iProductRepository;
        }

        // GET: Admin
        public ActionResult Index(string category=null)
        {
            var categorys = from product in iProductRepository.Products
                orderby product.Category
                select product.Category;
            var result=new ProductCategoryViewModel()
            {
                Products =category==null?iProductRepository.Products:iProductRepository.Products.Where(x=>x.Category==category),
                Categorys = categorys.Distinct()


        };
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            return View(iProductRepository.Products.FirstOrDefault(x=>x.ProductID==id));
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                iProductRepository.SaveProduct(product);
                TempData["Message"] = "成功添加一条数据";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
           
        }

        public ActionResult Create()
        {
            return View("Edit", new Product());
        }

        public ActionResult Delete(int id)
        {
            var result=iProductRepository.DeleteProduct(id);
            if (result!=null)
            {
                TempData["Message"] = "成功删除一条信息";
            }
            return RedirectToAction("Index");
        }
       
    }
}
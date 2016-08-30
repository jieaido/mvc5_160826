using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private int pagesize = 4;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        public ViewResult List(string category, int page=1)
        {
            var Productresult= productRepository.Products.OrderBy(p => p.ProductID).
                Where(p=>category==null||p.Category==category).Skip((page - 1)*pagesize).Take(pagesize);
            var pageinfo=new PageingInfo()
            {
                currentPage = page,
                itemPerPage = pagesize,
                Totalitem = productRepository.Products.Count(),
                
                
            };
            var result = new ProductListViewModel()
            {
                PageingInfo = pageinfo,
                Products = Productresult,
                CurrentCategory = category
            };
            return View(result);
        }
    }
}
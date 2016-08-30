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
    public class CartController : Controller
    {
        private IProductRepository repository;

        public CartController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(string returnurl)
        {
            return View(new CartIndexViewModel()
            {
                Cart = GetCart(),
                ReturnUrl = returnurl
            });
        }
        public RedirectToRouteResult AddToCart(int productid, string returnurl)
        {
            var product = repository.Products.Where(p => p.ProductID == productid).FirstOrDefault();
            if (product!=null)
            {
                GetCart().AddItem(product,1);
            }
            return RedirectToAction("Index", new {returnurl});
        }

        public RedirectToRouteResult RemoveFromCart(int productid, string returnurl)
        {
            var product = repository.Products.Where(p => p.ProductID == productid).FirstOrDefault();
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnurl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart) Session["Cart"];
            if (cart==null)
            {
                cart=new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        // GET: Cart
        
    }
}
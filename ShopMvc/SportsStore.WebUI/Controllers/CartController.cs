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

        public ViewResult Index(Cart cart, string returnurl)
        {
            return View(new CartIndexViewModel()
            {
                Cart = cart,
                ReturnUrl = returnurl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int productid, string returnurl)
        {
            var product = repository.Products.Where(p => p.ProductID == productid).FirstOrDefault();
            if (product!=null)
            {
                cart.AddItem(product,1);
            }
            return RedirectToAction("Index", new {returnurl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productid, string returnurl)
        {
            var product = repository.Products.Where(p => p.ProductID == productid).FirstOrDefault();
            if (product != null)
            {
                cart.RemoveLine(product);
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

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        // GET: Cart
        public ViewResult CheckOut()
        {
            return View();
        }
    }
}
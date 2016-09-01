using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure
{
    public class CartModelBinder : IModelBinder
    {
        private const string SessionKey = "Cart";

       
        object IModelBinder.BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null;
            if (controllerContext.HttpContext.Session!=null)
            {
                cart = (Cart) controllerContext.HttpContext.Session[SessionKey];
            }
            if (cart==null)
            {
                cart=new Cart();
                if (controllerContext.HttpContext.Session!=null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = cart;
                }
            }
            return cart;
        }
    }
}
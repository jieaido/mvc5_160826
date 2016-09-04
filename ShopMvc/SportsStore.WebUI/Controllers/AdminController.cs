﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

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
        public ActionResult Index()
        {
            return View(iProductRepository.Products);
        }
    }
}
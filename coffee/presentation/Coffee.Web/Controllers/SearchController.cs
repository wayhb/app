﻿using Microsoft.AspNetCore.Mvc;
using Сoffee;

namespace Coffee.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ProductService productService;
        public SearchController(ProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index(string query)
        {
            var products = productService.GetAllByQuery(query);
            return View("Index", products);
        }
    }
}

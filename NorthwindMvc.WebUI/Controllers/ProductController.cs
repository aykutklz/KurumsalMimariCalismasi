﻿using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using NorthwindMvc.WebUI.Models;

namespace NorthwindMvc.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int page=1, int category=0)
        {
            int pageSize = 10;
            var products = _productService.GetByCategory(category);
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page - 1)*pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count/(double)pageSize),
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page,
            };
            return View(model);
        }
    }
}

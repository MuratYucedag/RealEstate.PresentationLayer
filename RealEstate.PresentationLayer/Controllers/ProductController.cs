﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        public ProductController(IProductService productService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _productService.TGetProductByCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in _categoryService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p.AppUserID = values.Id;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _productService.TInsert(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetByID(id);
            _productService.TDelete(values);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> values = (from x in _categoryService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            var values2 = _productService.TGetByID(id);

            return View(values2);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            _productService.TUpdate(p);
            return RedirectToAction("Index");
        }

    }
}

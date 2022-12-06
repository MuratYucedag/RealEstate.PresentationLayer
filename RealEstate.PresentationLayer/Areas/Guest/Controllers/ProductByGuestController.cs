using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class ProductByGuestController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public ProductByGuestController(IProductService productService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
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
        public async Task<IActionResult> Index(Product p)
        {
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p.AppUserID = values.Id;
            _productService.TInsert(p);
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> ProductListByGuest()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var productValues = _productService.TGetProductByGuest(values.Id);
            return View(productValues);
        }

        public IActionResult DeleteProductByGuest(int id)
        {
            var values = _productService.TGetByID(id);
            _productService.TDelete(values);
            return RedirectToAction("ProductListByGuest");
        }

        [HttpGet]
        public IActionResult UpdateProductByGuest(int id)
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
        public IActionResult UpdateProductByGuest(Product p)
        {
            _productService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}

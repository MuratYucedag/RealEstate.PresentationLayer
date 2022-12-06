using Microsoft.AspNetCore.Mvc;
using RealEstate.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RealEstate.PresentationLayer.ViewComponents.Adverts
{
    public class _AdvertListPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _AdvertListPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _productService.TGetProductByCategory();
            return View(values);
        }    }
}

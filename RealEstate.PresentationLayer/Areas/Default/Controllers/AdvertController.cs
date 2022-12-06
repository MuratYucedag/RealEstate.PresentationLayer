using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.DataAccessLayer.Concrete;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Areas.Default.Controllers
{
    [Area("Default")]
    [AllowAnonymous]
    [Route("Default/Advert")]
    public class AdvertController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("AdvertDetails/{id}")]
        public IActionResult AdvertDetails(int id)
        {
            ViewBag.i = id;
            return View();
        }

        [HttpPost]
        public IActionResult AdvertDetails(string a)
        {
            return View();
        }

        public PartialViewResult CommentByAdvert(int id)
        {
            Context context = new Context();
            var values = context.Comments.Where(x => x.ProductID == id).ToList();
            return PartialView(values);
        }

        [HttpGet]
        [Route("")]
        [Route("PartialAddComment")]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        [Route("")]
        [Route("PartialAddComment")]
        public IActionResult PartialAddComment(Comment p)
        {
            Context context = new Context();
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ProductID = 1;
            context.Comments.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using RealEstate.EntityLayer.Concrete;
using RealEstate.PresentationLayer.Areas.Guest.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class GuestProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public GuestProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel user = new UserEditViewModel();
            user.Name= values.Name;
            user.Surname=values.Surname;
            user.PhoneNumber=values.PhoneNumber;
            user.Mail=values.Email;
            user.Gender=values.Gender;


            //ViewBag.v = values.Name + " " + values.Surname;
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image!=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension=Path.GetExtension(p.Image.FileName); //uzantı
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource+"/wwwroot/Image/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                values.ImageUrl=imageName;
            }
            values.Name = p.Name;
            values.Surname = p.Surname;
            values.PhoneNumber = p.PhoneNumber;
            values.Email = p.Mail;
            values.Gender = p.Gender;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);
            var result = await _userManager.UpdateAsync(values);


            return View();
            
        }
    }
}

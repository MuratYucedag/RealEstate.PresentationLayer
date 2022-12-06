using System.ComponentModel.DataAnnotations;

namespace RealEstate.PresentationLayer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "ad alanı boş geçilemez")]
        public string name { get; set; }



        [Required(ErrorMessage = "soyad alanı boş geçilemez")]
        public string surname { get; set; }



        [Required(ErrorMessage = "kullanıcı adı alanı boş geçilemez")]
        public string username { get; set; }


        [MaxLength(20,ErrorMessage ="mail en fazla 20 karakter olabilir")]
        [Required(ErrorMessage = "mail alanı boş geçilemez")]
        public string mail { get; set; }



        [Required(ErrorMessage = "şifre alanı boş geçilemez")]
        public string password { get; set; }



        [Required(ErrorMessage = "şifre tekrar alanı boş geçilemez")]
        [Compare("password", ErrorMessage = "şifreler birbiriyle uyuşmuyor")]
        public string confirmpassword { get; set; }
    }
}
/*
 Solid Prensipleri
Single Responsibility Principle
 */
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using RealEstate.PresentationLayer.Models;

namespace RealEstate.PresentationLayer.Controllers
{
    public class MailController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(MailRequest p)
        {
            MimeMessage mimeMessage = new MimeMessage();


            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin RealEstate", "enesozcanturksat@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);



            MailboxAddress mailboxAddressTo = new MailboxAddress("User", p.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);



            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = p.Content;
            mimeMessage.Body = bodybuilder.ToMessageBody();
            mimeMessage.Subject = p.Subject;



            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("enesozcanturksat@gmail.com", "dmaihrkzkzfahoqp");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return View();
        }
    }
}

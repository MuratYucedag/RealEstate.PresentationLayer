using System.ComponentModel.DataAnnotations;

namespace RealEstate.PresentationLayer.Models
{
    public class MailRequest
    {
        [Required(ErrorMessage = "Adınızı boş geçemezsiniz")]
        public string Name { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}

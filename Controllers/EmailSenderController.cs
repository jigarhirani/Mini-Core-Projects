using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace MiniCoreProjects.Controllers
{
    public class EmailSenderController : Controller
    {
        #region Method TO Send Email
        public IActionResult SendEmail(string Email, string Subject, string Message)
        {
            try
            {
                var emailToSend = new MimeMessage();
                emailToSend.From.Add(MailboxAddress.Parse("blind.basic@gmail.com"));
                emailToSend.To.Add(MailboxAddress.Parse(Email));
                emailToSend.Subject = Subject;
                emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = Message };
                using (var emailClient = new SmtpClient())
                {
                    emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    emailClient.Authenticate("blind.basic@gmail.com", "iysftklggldpdbrh");
                    emailClient.Send(emailToSend);
                    emailClient.Disconnect(true);
                }
                TempData["successMessage"] = "Mail Sended Successfully";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["successMessage"] = "Some error has occurred";
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FindYourPrimeAuthentication.Services
{
    public class EmailSender : IEmailSender
    {
        public const string ApplicationName = "FindYourPrime";
        public const string ApplicationEmail = "";
        public const string ApplicationEmailPassword = "";
        public const string GmailSmtp = "";
        public const int Port = 465;

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var client = new SmtpClient(GmailSmtp, Port)) // netstat -l/a ... for checking available ports
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential(ApplicationEmail, ApplicationEmailPassword);

                var mailMessage = new MailMessage();
                mailMessage.To.Add(email);
                mailMessage.From = new MailAddress(ApplicationEmail, ApplicationName);
                mailMessage.Subject = subject;
                mailMessage.Body = htmlMessage;
                mailMessage.IsBodyHtml = false;

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}

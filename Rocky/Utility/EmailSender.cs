using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Rocky.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly MailConfig _mailConfig;
        public EmailSender( IConfiguration config)
        {
            _mailConfig = config.GetSection("MailConfig").Get<MailConfig>();
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailAddress from = new MailAddress("wania-0806@tut.by", "Palasja _Rocky");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Body = htmlMessage;
            SmtpClient smtp = new SmtpClient(_mailConfig.Host, _mailConfig.Port);
            smtp.Credentials = new NetworkCredential(_mailConfig.Email, _mailConfig.Password);
            smtp.EnableSsl = true;
            
            await smtp.SendMailAsync(m);
        }
    }
}

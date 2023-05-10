using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public static class SendEmail
    {
        public static void Send(string email) 
        {
            MailMessage mailMessage = new MailMessage();
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 60 * 60;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("luanaanalist@gmail.com", "ewxjoizhprqzwuof");

                mailMessage.From = new MailAddress("renatacometti2@gmail.com", "Olá, Seja bem vindo ao nosso Ecommerce");
                mailMessage.Body = "Seja bem vindo ao Sistema Ecommerce Customer"; // corpo do email
                mailMessage.Subject = "Seja bem vindo"; // titulo do email
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.Normal;
                mailMessage.To.Add(email);

                smtpClient.Send(mailMessage);


            }
            catch (Exception ex)
            {

                throw;
            }
        
        }
    }
}

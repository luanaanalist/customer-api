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
        public static void Send(Cliente cliente) 
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
                mailMessage.IsBodyHtml = true;


                string body =
             $"<p> Seja bem vindo ao Ecommerce {cliente.Nome} </p>" +
                      "<p>Segue abaixo os dados de acesso que você cadastrou:</p>" +
               "<table>" +
                  "<tr>" +
                    "<th>Login</th>" +
                    $"<td>{cliente.Email}</td>" +
                  "</tr>" +
                  "<tr>" +
                    "<th>Senha</th>" +
                    $"<td>{cliente.Senha}</td>" +
                  "</tr>" +
                "</table>";


                body = body.Replace("{cliente.Nome}", "cliente.Nome");
                body = body.Replace("{cliente.Emai}", "cliente.Emai");
                body = body.Replace("{cliente.Senha}", "cliente.Senha");

               
                mailMessage.Body = body;
                mailMessage.Subject = "Seja bem vindo"; // titulo do email
                mailMessage.Priority = MailPriority.Normal;
                mailMessage.To.Add(cliente.Email);

                smtpClient.Send(mailMessage);


            }
            catch (Exception ex)
            {

                throw;
            }
        
        }
    }
}

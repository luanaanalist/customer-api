using Domain.Entities;
using Domain.Repository;
using Microsoft.Extensions.Configuration;
using Repository.Context;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Repository.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private IConfiguration _configuration;
        public ClienteRepository(AppDbContext appDbContext, IConfiguration configuration) : base(appDbContext)
        {
            _configuration = configuration;
        }

        public User ValidaCliente(string email, string senha) 
        {

            var user = _context.Cliente.Where(c => c.Email == email && c.Senha == senha)
                .Select(user => new User() { Email = user.Email, Senha = user.Senha }).SingleOrDefault();

            return user;

        }

        public bool CustomerExist(string cpf, string email) 
        {
            var customerExist =  _context.Cliente.Where(c => c.Email == email || c.Cpf == cpf).FirstOrDefault();
            if(customerExist != null)
                return true;

            return false;
        }



        //public void Incluir(Cliente cliente)
        //{
        //      cliente.Update_Date = DateTime.Now;
        //      cliente.Create_Date = DateTime.Now;
        //      _context.Cliente.Add(cliente);
        //       bool teste = _context.SaveChanges() > 0;
        //}

        public void EnviarEmail(Cliente cliente) 
        {


            CultureInfo cult = new CultureInfo("pt-BR");

            SmtpClient client = new SmtpClient();
            client.Host = _configuration["Email:Host"];
            client.Port = int.Parse(_configuration["Email:Port"]);
            client.EnableSsl = bool.Parse(_configuration["Email:EnableSsl"]);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_configuration["Email:SenderEmail"], _configuration["Email:SenderPassword"]);
         

            MailAddress de = new MailAddress(_configuration["Email:SenderEmail"]);
            string emailpara = cliente.Email;
            MailAddress para = new MailAddress(emailpara); //email que peguei no site email 10 mint
            MailMessage email = new MailMessage(de, para);

            email.IsBodyHtml = true;
            email.Subject = "Seja bem vindo " + cliente.Nome; // titulo do email

            var caminho = Environment.CurrentDirectory.ToString() + _configuration.GetValue<string>("TemplatePath") + "EmailBoasVindas.cshtml";
            using (StreamReader objReader = new StreamReader(caminho, Encoding.GetEncoding("iso-8859-1")))
            {
                var strMail = objReader.ReadToEnd();


                strMail = strMail.Replace("[Nome]", cliente.Nome);
                strMail = strMail.Replace("[Email]", cliente.Email);
                strMail = strMail.Replace("[Senha]", cliente.Senha);

                email.BodyEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                email.Body = strMail;
                
            }
            try
            {
                client.Send(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + client.Port + client.Host +  _configuration["Email:SenderEmail"] + _configuration["Email:SenderPassword"]);
            }






            //CultureInfo cult = new CultureInfo("pt-BR");
            //MailMessage mailMessage = new MailMessage();
            //var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            //smtpClient.EnableSsl = true;
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = new NetworkCredential("luanaanalist@gmail.com", "ewxjoizhprqzwuof");

            //mailMessage.From = new MailAddress("renatacometti2@gmail.com", "Olá, Seja bem vindo ao nosso Ecommerce");
            //mailMessage.IsBodyHtml = true;

            //var caminho = Environment.CurrentDirectory.ToString() + _configuration.GetValue<string>("TemplatePath") + "EmailBoasVindas.cshtml";
            //using (StreamReader objReader = new StreamReader(caminho, Encoding.GetEncoding("iso-8859-1")))
            //{
            //    var strMail = objReader.ReadToEnd();


            //    strMail = strMail.Replace("[Nome]", cliente.Nome);
            //    strMail = strMail.Replace("[Email]", cliente.Email);
            //    strMail = strMail.Replace("[Senha]", cliente.Senha);

            //    mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            //    mailMessage.Body = strMail;
            //}

            //mailMessage.Subject = "Seja bem vindo " + cliente.Nome; // titulo do email
            //mailMessage.To.Add(cliente.Email); // email de envio

            //try
            //{
            //    smtpClient.Send(mailMessage);
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception(ex.Message);
            //}
        }

    }
}

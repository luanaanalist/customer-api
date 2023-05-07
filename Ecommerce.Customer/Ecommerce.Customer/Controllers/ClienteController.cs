using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Ecommerce.Customer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var response = this._clienteService.GetAll();
            return Ok(response);

        }

        //[AllowAnonymous]
        //[HttpGet]
        //public ActionResult Loging(string email, string senha)
        //{

        //    var response = _clienteService.ValidaCliente(email, senha);
        //    return Ok(response);


        //}
    }
}

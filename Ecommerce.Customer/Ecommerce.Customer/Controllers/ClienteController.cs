using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.ViewModel;

namespace Ecommerce.Customer.Controllers
{
    //[ApiController]
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

        [HttpPost]
        [Route("Created/{senha}")]
        public IActionResult Created([FromBody] Cliente cliente, [FromRoute] string senha)
        {
            var response = this._clienteService.Created(cliente, senha);
            return Ok(response);

        }



    }
}

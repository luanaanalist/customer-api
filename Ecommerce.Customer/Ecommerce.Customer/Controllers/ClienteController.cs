using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.ViewModel;

namespace Ecommerce.Customer.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var response = this._clienteService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {

                return TratarExcecao(ControllerContext, "Ocorreu um erro ao tentar recuperar os clientes", ex);
            }
            

        }

        //[HttpPost]
        //[Route("Created/{senha}")]
        //public IActionResult Created([FromBody] Cliente cliente, [FromRoute] string senha)
        //{
        //    try
        //    {

        //        var response = this._clienteService.Created(cliente, senha);
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return TratarExcecao(ControllerContext, "Ocorreu um erro ao tentar cadastrar um cliente.", ex);
        //    }


        //}
        [HttpPost]
        [Route("Created/{senha}")]
        public async Task<IActionResult> Created([FromBody] Cliente cliente, [FromRoute] string senha)
        {
            try
            {
                if (!await this._clienteService.Created(cliente, senha))
                    return Conflict(this._clienteService.RetornaErros());

                    return Ok();
            }
            catch (Exception ex)
            {
                return TratarExcecao(ControllerContext, "Ocorreu um erro ao tentar cadastrar um cliente.", ex);
            }

        }

    }
}

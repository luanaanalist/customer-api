using Domain.DTO;
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

     
        [HttpGet("GetbyId/{idCliente}")]
        public IActionResult GetbyId([FromRoute] int idCliente)
        {
            try
            {
                var response = this._clienteService.GetById(idCliente);
                return Ok(response);

            }
            catch (Exception ex)
            {

                return TratarExcecao(ControllerContext, "Ocorreu um erro ao tentar recuperar os clientes", ex);
            }


        }

        [HttpDelete("{idCliente}")]
        public async Task<IActionResult> Delete([FromRoute] int idCliente)
        {
   
            try
            {
                if (!await this._clienteService.Delete(idCliente))
                    return Conflict(this._clienteService.RetornaErros());
                else
                    return Ok();

            }
            catch (Exception ex)
            {
                return TratarExcecao(ControllerContext, "Ocorreu um erro ao tentar excluir o Cliente", ex);
            }


        }


        [HttpPost]
        [Route("Created/{senha}")]
        public async Task<IActionResult> Created([FromBody] Cliente cliente, [FromRoute] string senha)
        {
            try
            {
                if (!await this._clienteService.Created(cliente, senha))
                    return Conflict(this._clienteService.RetornaErros());
                else
                     return Ok();
            }
            catch (Exception ex)
            {
                return TratarExcecao(ControllerContext, "Ocorreu um erro ao tentar cadastrar um cliente.", ex);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cliente cliente)
        {
            try
            {
                if (!await this._clienteService.Update(cliente))
                    return Conflict(this._clienteService.RetornaErros());
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                return TratarExcecao(ControllerContext, "Ocorreu um erro ao tentar altera um cliente.", ex);
            }

        }

    }
}

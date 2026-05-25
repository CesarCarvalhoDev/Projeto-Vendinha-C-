using Microsoft.AspNetCore.Mvc;
using VendinhaAPI.DTOs;
using VendinhaAPI.Models;
using VendinhaAPI.Services;

namespace VendinhaAPI.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> ListarClientes()
        {
            var clientes = _clienteService.ListarClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> BuscarPorId(int id)
        {
            try
            {
                var cliente = _clienteService.BuscarPorId(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Cliente> Criar([FromBody] CreateClienteDto dto)
        {
            try
            {
                var cliente = _clienteService.Criar(dto);

                return CreatedAtAction(
                    nameof(BuscarPorId),
                    new { id = cliente.Id },
                    cliente
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] CreateClienteDto dto)
        {
            return Ok("Endpoint de atualização ainda não implementado");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _clienteService.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
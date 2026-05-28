using System.Diagnostics;
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
        public ActionResult<dynamic> ListarClientes([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            if (page < 1) page = 1;
            if (size < 1) size = 10;

            var clientes = _clienteService.ListarClientes();
            if (clientes != null)
            {
                var clientesPaginados = clientes.Skip((page - 1) * size).Take(size).ToList();
                return Ok(clientesPaginados);
            }
            else
            {
                return BadRequest();
            }
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

        [HttpPut("{id}/atualizar")]
        public IActionResult Atualizar(int id, [FromBody] UpdateClienteDto dto)
        {
            var cliente = _clienteService.BuscarPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(dto.NomeCompleto))
            {
                cliente.NomeCompleto = dto.NomeCompleto;
            }
            if (!string.IsNullOrEmpty(dto.Email))
            {
                cliente.Email = dto.Email;
            }
            if (!string.IsNullOrEmpty(dto.CPF))
            {
                cliente.CPF = dto.CPF;
            }
            if (_clienteService.AtualizarCliente(cliente))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

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
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VendinhaAPI.DTOs;
using VendinhaAPI.Models;
using VendinhaAPI.Services;

namespace VendinhaAPI.Controllers
{
    [ApiController]
    [Route("dividas")]
    public class DividaController : ControllerBase
    {

        private readonly ContaService _contaService;
        private readonly PagamentoService _pagamentoService;

        public DividaController(
            ContaService contaService,
            PagamentoService pagamentoService
        )
        {
            _contaService = contaService;
            _pagamentoService = pagamentoService;
        }


        [HttpGet]
        public ActionResult<List<Divida>> ListarDividas()
        {
            var dividas = _contaService.ListarDividas();
            return Ok(dividas);
        }

        [HttpGet("cliente/{clienteId}")]
        public ActionResult<List<Divida>> BuscarDividasPorCliente(int clienteId)
        {
            var dividas = _contaService.BuscarDividasPorCliente(clienteId);

            return Ok(dividas);
        }

        [HttpPost]
        public ActionResult<Divida> Criar([FromBody] CreateDividaDto dto)
        {
            try
            {
                var divida = _contaService.AbrirDivida(dto);

                return CreatedAtAction(
                    nameof(BuscarDividasPorCliente),
                    new { clienteId = divida.ClienteId },
                    divida
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/pagar")]
        public ActionResult<Divida> PagarDivida(int id)
        {
            try
            {
                var divida = _pagamentoService.RegistrarPagamento(id);

                return Ok(divida);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
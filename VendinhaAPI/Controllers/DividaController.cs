using System.Runtime.CompilerServices;
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
            if (dividas != null)
            {
                return Ok(dividas);
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpGet("cliente/{clienteId}")]
        public ActionResult<List<Divida>> BuscarDividasPorCliente(int clienteId)
        {
            var dividas = _contaService.BuscarDividasPorCliente(clienteId);
            if(dividas != null){
                return Ok(dividas);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<Divida> Criar([FromBody] CreateDividaDto dto)
        {
            try
            {
                var divida = _contaService.AbrirDivida(dto);
                return Created("", divida);
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
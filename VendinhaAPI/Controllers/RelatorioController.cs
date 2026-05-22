using Microsoft.AspNetCore.Mvc;
using VendinhaAPI.DTOs;
using VendinhaAPI.Models;
using VendinhaAPI.Services;

namespace VendinhaAPI.Controllers
{
    public class RelatorioController : ControllerBase
    {
        private readonly ContaService _contaService;
        private readonly PagamentoService _pagamentoService;

        public RelatorioController(
            ContaService contaService,
            PagamentoService pagamentoService
        )
        {
            _contaService = contaService;
            _pagamentoService = pagamentoService;
        }

        [HttpGet]
        [Route("relatorios/contas-abertas")]
        public ActionResult<List<Divida>> ListarContasAbertas()
        {
            var contasAbertas = _contaService.ListarContasAbertas();
            return Ok(contasAbertas);
        }

        [HttpPost]
        [Route("relatorios/contas")]

        [HttpGet]
        [Route("relatorios/inadimplentes")]
        public ActionResult<List<ClienteComDividaDto>> ListarInadimplentes()
        {
            var inadimplentes = _contaService.ListarClienteComDivida();

            return Ok(inadimplentes);
        }

        [HttpGet]
        [Route("relatorios/total-recebidos")]
        public ActionResult<decimal> CalcularTotalRecebido()
        {
            var totalPago = _contaService.CalcularSaldoTotalPago();
            return Ok(totalPago);
        }
    }
}
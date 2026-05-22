using VendinhaAPI.Models;

namespace VendinhaAPI.Services
{
    public class PagamentoService
    {
        private readonly ContaService _contaService;

        public PagamentoService(ContaService contaService)
        {
            _contaService = contaService;
        }

        public Divida RegistrarPagamento(int id)
        {
            var divida = _contaService.BuscarDivida(id);

            if (divida is null)
            {
                throw new Exception($"Não foi encontrado nenhuma divida com esse ID: {id}");
            }
            if (divida.Situacao == "Paga")
            {
                throw new Exception($"A divida com {id} já foi paga");
            }
            divida.Situacao = "Pago";
            divida.DataPagamento = DateTime.Now;
            return divida;
        }
    }
}

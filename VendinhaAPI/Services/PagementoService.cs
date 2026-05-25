using VendinhaAPI.Data;
using VendinhaAPI.Models;

namespace VendinhaAPI.Services
{
    public class PagamentoService
    {
        private readonly AppDbContext _context;
        private readonly ContaService _contaService;

        public PagamentoService(
            ContaService contaService,
            AppDbContext context)
        {
            _contaService = contaService;
            _context = context;
        }

        public Divida RegistrarPagamento(int id)
        {
            var divida = _contaService.BuscarDivida(id);

            if (divida is null)
            {
                throw new Exception($"Não foi encontrado nenhuma divida com esse ID: {id}");
            }
            if (divida.Situacao == "Pago")
            {
                throw new Exception($"A divida com {id} já foi paga");
            }
            divida.Situacao = "Pago";
            divida.DataPagamento = DateTime.Now;

            _context.SaveChanges();

            return divida;
        }
    }
}

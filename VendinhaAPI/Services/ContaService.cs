using VendinhaAPI.Data;
using VendinhaAPI.DTOs;
using VendinhaAPI.Models;

namespace VendinhaAPI.Services
{
    public class ContaService
    {
        private readonly AppDbContext _context;
        private readonly ClienteService _clienteService;

        public ContaService(
            AppDbContext context,
            ClienteService clienteService)
        {
            _context = context;
            _clienteService = clienteService;
        }

        public Divida AbrirDivida(CreateDividaDto dto)
        {
            Cliente cliente = _clienteService.BuscarPorId(dto.ClienteId);

            var dividaAberta = _context.Dividas.FirstOrDefault(divida =>
                divida.ClienteId == dto.ClienteId &&
                divida.Situacao == "Pendente"
            );

            if (dividaAberta is not null)
            {
                throw new Exception("O cliente já possui uma dívida aberta");
            }

            Divida divida = new Divida(dto.ClienteId, dto.Valor)
            {
                ClienteId = dto.ClienteId,
                Valor = dto.Valor,
                Situacao = "Pendente"
            };

            _context.Dividas.Add(divida);
            _context.SaveChanges();

            return divida;
        }

        public List<Divida> ListarDividas()
        {
            return _context.Dividas.ToList();
        }

        public List<Divida> ListarContasAbertas()
        {
            return _context.Dividas.Where(divida => divida.Situacao == "Pendente").ToList();
        }

        public List<ClienteComDividaDto> ListarClienteComDivida()
        {
            List<ClienteComDividaDto> relatorio = new List<ClienteComDividaDto>();

            foreach (var divida in _context.Dividas)
            {
                if (divida.Situacao == "Pendente")
                {
                    Cliente cliente = _clienteService.BuscarPorId(divida.ClienteId);

                    ClienteComDividaDto dto = new ClienteComDividaDto
                    {
                        ClienteId = cliente.Id,
                        NomeCompleto = cliente.NomeCompleto,
                        Email = cliente.Email,
                        CPF = cliente.CPF,
                        ValorDivida = divida.Valor,
                        SituacaoDivida = divida.Situacao
                    };

                    relatorio.Add(dto);
                }
            }

            return relatorio;
        }

        public List<Divida> ListarDividasPagas()
        {
            var dividas = _context.Dividas.Where(dividas => dividas.Situacao == "Pago");
            return dividas.ToList();
        }

        public decimal CalcularSaldoDividas()
        {
            decimal total = 0;

            foreach (var divida in _context.Dividas)
            {
                if (divida.Situacao == "Pendente")
                {
                    total += divida.Valor;
                }
            }

            return total;
        }

        public decimal CalcularSaldoTotalPago()
        {
            decimal totalPago = 0;

            List<Divida> pagamentos = _context.Dividas.Where(pagamentos => pagamentos.Situacao == "Pago").ToList();

            foreach (var pagamento in pagamentos)
            {
                totalPago = totalPago + pagamento.Valor;
            }

            return totalPago;
        }

        public Divida? BuscarDivida(int id)
        {
            Divida? divida = _context.Dividas.FirstOrDefault(divida => divida.Id == id);
            return divida;
        }

        public List<Divida> BuscarDividasPorCliente(int clienteId)
        {
            return _context.Dividas.Where(divida => divida.ClienteId == clienteId).ToList();
        }


    }
}
namespace VendinhaAPI.Services
{
    using VendinhaAPI.DTOs;
    using VendinhaAPI.Models;

    public class ContaService
    {
        private static List<Divida> _bancoDeDados = new List<Divida>();
        private static int _proximoId = 1;

        private readonly ClienteService _clienteService;

        public ContaService(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public Divida AbrirDivida(CreateDividaDto dto)
        {
            Cliente cliente = _clienteService.BuscarPorId(dto.ClienteId);

            var dividaAberta = _bancoDeDados.FirstOrDefault(divida =>
                divida.ClienteId == dto.ClienteId &&
                divida.Situacao == "Pendente"
            );

            if (dividaAberta is not null)
            {
                throw new Exception("O cliente já possui uma dívida aberta");
            }

            Divida divida = new Divida(dto.ClienteId, dto.Valor)
            {
                Id = _proximoId++,
                ClienteId = dto.ClienteId,
                Valor = dto.Valor,
                Situacao = "Pendente"
            };

            _bancoDeDados.Add(divida);

            return divida;
        }

        public List<Divida> ListarDividas()
        {
            return _bancoDeDados.ToList();
        }

        public decimal CalcularSaldo()
        {
            decimal total = 0;

            foreach (var divida in _bancoDeDados)
            {
                if (divida.Situacao == "Pendente")
                {
                    total += divida.Valor;
                }
            }

            return total;
        }

        public void FecharConta(PagamentoDto dto)
        {
            var dividaAberta = _bancoDeDados.FirstOrDefault(divida =>
                divida.Id == dto.DividaId
            );

            if (dividaAberta is null)
            {
                throw new Exception("Dívida não encontrada");
            }

            if (dividaAberta.Situacao == "Paga")
            {
                throw new Exception("A dívida já foi paga");
            }

            dividaAberta.Situacao = "Paga";
            dividaAberta.DataPagamento = DateTime.Now;
        }
    }
}
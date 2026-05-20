namespace VendinhaAPI.Models;
class Divida
{
    private int Id {get; set;}
    private int ClienteId {get; set;}
    public decimal Valor {get; set;}
    public string Situacao {get; set;}
    public DateTime DataCriacao {get; set;}

    public DateTime DataPagamento {get; set;}

    public Divida(int id, int clienteId, decimal valor)
    {
        Id = id;
        ClienteId = clienteId;
        Valor = valor;
        Situacao = "Pendente";
        DataCriacao = DateTime.Now;
    }
}
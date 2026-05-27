namespace VendinhaAPI.Models;
public class Divida
{
    public int Id {get; set;}
    public int ClienteId {get; set;}
    public decimal Valor {get; set;}
    public string Situacao {get; set;}
    public DateTime DataCriacao {get; set;}

    public DateTime DataPagamento {get; set;}
    public Divida()
    {
    }
    public Divida(int clienteId, decimal valor)
    {
        ClienteId = clienteId;
        Valor = valor;
        Situacao = "Pendente";
        DataCriacao = DateTime.Now;
    }
}
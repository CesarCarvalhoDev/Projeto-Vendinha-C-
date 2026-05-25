using System;

namespace VendinhaAPI.DTOs;

public class ClienteComDividaDto
{
    public int ClienteId { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal ValorDivida { get; set; }
    public string SituacaoDivida { get; set; } = string.Empty;
}

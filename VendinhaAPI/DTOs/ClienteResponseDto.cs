using System;

namespace VendinhaAPI.DTOs;

public class ClienteResponseDto
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public int Idade { get; set; }
    public string Email { get; set; } = string.Empty;
    public decimal TotalDividas { get; set; }
}

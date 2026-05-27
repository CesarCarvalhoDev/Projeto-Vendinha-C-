using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace VendinhaAPI.DTOs
{
    public class UpdateClienteDto
    {
        
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string? NomeCompleto { get; set; }

        
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string? Email { get; set; }

        
        [RegularExpression(@"^\d{11}$|^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve ter 11 números ou o formato 000.000.000-00.")]
        public string? CPF { get; set; }
    }
}

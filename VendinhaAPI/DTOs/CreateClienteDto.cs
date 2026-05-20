using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace VendinhaAPI.DTOs
{
    public class CreateClienteDto
    {
        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$|^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve ter 11 números ou o formato 000.000.000-00.")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        public int Idade
        {
            get
            {
                var hoje = DateTime.Today;
                var anos = hoje.Year - DataNascimento.Year;
                var diaAnoNascimento = hoje.AddYears(-anos);
                if (DataNascimento > diaAnoNascimento)
                {
                    anos--;
                }
                return anos;
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace VendinhaAPI.DTOs
{
     public class PagamentoDto
    {
        [Required(ErrorMessage = "Divida id é obrigatória")]
        public int DividaId {get; set;}
        [Required(ErrorMessage = "Valor a pago é um valor obrigatório")]
        public decimal ValorPago {get; set;}
    }
}
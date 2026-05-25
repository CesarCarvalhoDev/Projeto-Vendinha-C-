using System.ComponentModel.DataAnnotations;

namespace VendinhaAPI.DTOs
{
    public class CreateDividaDto
    {
        [Required(ErrorMessage = "O campo dividaId é obrigatório")]
        public int ClienteId {get; set;}

        [Required(ErrorMessage = "O campo valor é obrigatório")]
        public decimal Valor {get; set;}
    }
}


using VendinhaAPI.DTOs;

namespace VendinhaAPI.Models;

class Cliente
{
    public int Id { get; private set; }
    public string NomeCompleto { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }

    public int Idade {get; set;}



    public Cliente(CreateClienteDto dto)
    {
        NomeCompleto = dto.NomeCompleto;
        CPF = dto.CPF;
        DataNascimento = dto.DataNascimento;
        Email = dto.Email;
        Idade = dto.Idade;
    }

}
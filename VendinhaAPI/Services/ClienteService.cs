using System;
using System.Collections.Generic;
using System.Linq;
using VendinhaAPI.DTOs;
using VendinhaAPI.Models;

namespace VendinhaAPI.Services
{
    public class ClienteService
    {
        private static List<Cliente> _bancoDeDados = new List<Cliente>();
        private static int _proximoId = 1;

        public Cliente Criar(CreateClienteDto dto)
        {
            if (_bancoDeDados.Any(p => p.CPF.Equals(dto.CPF, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Já existe um cliente cadastrado com esse CPF");
            }

            Cliente cliente = new Cliente(dto)
            {
                Id = _proximoId++,
                NomeCompleto = dto.NomeCompleto,
                CPF = dto.CPF,
                DataNascimento = dto.DataNascimento,
                Email = dto.Email,
                Idade = dto.Idade
            };

            _bancoDeDados.Add(cliente);
            return cliente;
}

        public Cliente BuscarPorId(int id)
        {
            var cliente = _bancoDeDados.FirstOrDefault(cliente => cliente.Id == id);

            if(cliente == null)
            {
                throw new KeyNotFoundException($"Cliente com ID {id} não foi encontrado");
            }
            return cliente;
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = _bancoDeDados.ToList();
            return clientes;
        }

        public void Deletar(int id)
        {
            var cliente = BuscarPorId(id);
            _bancoDeDados.Remove(cliente);
        }
    }
}
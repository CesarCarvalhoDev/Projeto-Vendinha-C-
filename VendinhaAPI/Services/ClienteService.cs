using System;
using System.Collections.Generic;
using System.Linq;
using VendinhaAPI.Data;
using VendinhaAPI.DTOs;
using VendinhaAPI.Models;

namespace VendinhaAPI.Services
{
    public class ClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }
        public Cliente Criar(CreateClienteDto dto)
        {
            if (_context.Clientes.Any(c => c.CPF.ToLower() == dto.CPF.ToLower()))
            {
                throw new InvalidOperationException("Já existe um cliente cadastrado com esse CPF");
            }

            Cliente cliente = new Cliente(dto)
            {
                NomeCompleto = dto.NomeCompleto,
                CPF = dto.CPF,
                DataNascimento = dto.DataNascimento,
                Email = dto.Email,
                Idade = dto.Idade
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
}

        public Cliente BuscarPorId(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

            if(cliente == null)
            {
                throw new KeyNotFoundException($"Cliente com ID {id} não foi encontrado");
            }
            return cliente;
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = _context.Clientes.ToList();
            return clientes;
        }

        public void Deletar(int id)
        {
            var cliente = BuscarPorId(id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
}
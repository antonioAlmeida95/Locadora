using System;
using System.Collections.Generic;
using System.Linq;
using Graphql.Loja.Model;
using Microsoft.EntityFrameworkCore;

namespace Graphql.Loja.Persistencia
{
    public class LocadoraDAO: IDisposable
    {
        private LocadoraContext _context;

        public LocadoraDAO()
        {
            _context = new LocadoraContext();
        }

        public Cliente AddCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public Carro AddCarro(Carro carro)
        {
            _context.Carros.Add(carro);
            _context.SaveChanges();
            return carro;
        }

        public Cliente GetClienteById(Cliente cliente)
        {
            return _context.Clientes
                .Include(ca => ca.Locados)
                .ThenInclude(c => c.Carro)
                .FirstOrDefault(c => cliente.Id != 0 && cliente.Id == c.Id);
        }

        public IList<Cliente> GetClientes()
        {
            return _context.Clientes
                .Include(ca => ca.Locados)
                .ThenInclude(c => c.Carro)
                .ToList();
        }

        public Carro GetCarroById(Carro carro)
        {
            return _context.Carros
                .Include(cl => cl.Locacoes)
                .ThenInclude(c => c.Cliente)
                .FirstOrDefault(c => carro.Id != 0 && c.Id == carro.Id);
        }

        public IList<Carro> GetCarros()
        {
            return _context.Carros
                .Include(cl => cl.Locacoes)
                .ThenInclude(c => c.Cliente)
                .ToList();
        }

 

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

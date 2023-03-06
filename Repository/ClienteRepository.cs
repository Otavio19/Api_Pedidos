using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Pedidos.Repository
{
    public interface ICliente
    {
        List<Cliente> Read(int id);
        void Create(Cliente cliente);
        Cliente GetById(int id);
        void Update(int id, Cliente cliente);
        void Delete(int id);
    }

    public class ClienteRepository : ICliente
    {
        public readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            _context.Clientes.Entry(cliente!).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Cliente GetById(int id)
        {
            var _cliente = _context.Clientes.Find(id);
            return _cliente!;
        }

        public List<Cliente> Read(int id)
        {
            return _context.Clientes.Where(cliente => cliente.Empresa_Id == id).ToList();
        }

        public void Update(int id, Cliente cliente)
        {
            var _cliente = _context.Clientes.Find(id);
            _cliente!.Nome = cliente.Nome;

            _context.Clientes.Entry(_cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
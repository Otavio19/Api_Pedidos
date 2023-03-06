using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Pedidos.Repository
{
    public interface IPedido
    {
        List<Pedido> Read();
        void Create(Pedido pedido);
        void Delete(int id);
        List<Pedido> GetByCompany(int id);
        Pedido GetById(int id);
    }

    public class PedidoRepository : IPedido
    {
        private readonly DataContext _context;

        public PedidoRepository(DataContext context)
        {
            _context = context;
        }

        public List<Pedido> Read()
        {
            return _context.Pedidos.Include(p => p.product).ToList();
        }

        public List<Pedido> GetByCompany(int id)
        {
            return _context.Pedidos.Where(pedido => pedido.empresa_id == id).Include(p => p.product).ToList();
        }

        public Pedido GetById(int id)
        {
            var _pedido = _context.Pedidos.Include(p => p.product).FirstOrDefault(p => p.id == id);

            return _pedido!;
        }

        public void Create(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var _pedido = _context.Pedidos.Find(id);
            _context.Entry(_pedido!).State = EntityState.Deleted;
            _context.SaveChanges();
        }

    }
}
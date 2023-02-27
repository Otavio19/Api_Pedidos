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
        void Delete(Guid id);
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

        public void Create(Pedido pedido)
        {
            pedido.id = new Guid();
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var _pedido = _context.Pedidos.Find(id);
            _context.Entry(_pedido).State = EntityState.Deleted;
            _context.SaveChanges();
        }

    }
}
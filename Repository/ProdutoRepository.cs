using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Pedidos.Repository
{
    public interface IProduto
    {
        List<Produto> Read();

        void Create(Produto protudo);

        void Delete(Guid id);

        void Update(Guid id, Produto produto);
    }

    public class ProdutoRepository : IProduto
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context){
            _context = context;
        }

        public void Create(Produto produto)
        {
            produto.id = Guid.NewGuid();
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var produto = _context.Produtos.Find(id);

            _context.Entry(produto).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Produto> Read()
        {
            return _context.Produtos.ToList();
        }

        public void Update(Guid id, Produto produto)
        {
            var _produto = _context.Produtos.Find(id);

            _produto.name = produto.name;
            _produto.active = produto.active;
            _produto.amount = produto.amount;
            _produto.price = produto.price;

            _context.Entry(_produto).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
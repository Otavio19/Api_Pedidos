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
        List<Produto> Read(int id);

        void Create(Produto protudo);

        void Delete(int id);

        void Update(int id, Produto produto);

        Produto GetById(int id);
    }

    public class ProdutoRepository : IProduto
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context){
            _context = context;
        }

        public void Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var produto = _context.Produtos.Find(id);

            _context.Entry(produto).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Produto> Read(int id)
        {
            return _context.Produtos.Where(p => p.empresa_id == id).ToList();
        }

        public Produto GetById(int id)
        {
            var _produto = _context.Produtos.Find(id);

            return _produto;
        }

        public void Update(int id, Produto produto)
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
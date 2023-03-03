using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api_Pedidos.Models;

namespace Api_Pedidos.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options):base(options){ }
        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Empresa> Empresa {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
    }
}
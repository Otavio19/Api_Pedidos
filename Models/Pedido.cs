using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Pedidos.Models
{
    public class Pedido
    {
        public Guid id { get; set; }
        public Guid reponsavel_id { get; set; }
        public Guid cliente_id { get; set; }
        public Guid empresa_id { get; set; }
        public int created_at { get; set; }
        public decimal price { get; set; }
        public List<Produto> product { get; set; }
    }
}
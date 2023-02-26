using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pedidos.Models
{
    public class Produto
    {
        public Guid id { get; set; }
        public Guid empresa_id { get; set; }
        public int create_at { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
    }
}
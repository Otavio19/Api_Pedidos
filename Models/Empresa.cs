using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pedidos.Models
{
    public class Empresa
    {
        public Guid id { get; set; }
        public int created_at { get; set; }
        public string Name { get; set; }
    }
}
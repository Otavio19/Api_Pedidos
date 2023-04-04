using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api_Pedidos.Models.ViewModel
{
    public class ProdutoView
    {
        public Guid id { get; set; }
        public int idGuia { get; set;}
        public string name { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
    }
}
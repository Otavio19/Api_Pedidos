using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Api_Pedidos.Models;
using Api_Pedidos.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Api_Pedidos.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int reponsavel_id { get; set; }
        public int cliente_id { get; set; }
        public int empresa_id { get; set; }
        public int created_at { get; set; }
        public decimal price { get; set; }
        public List<ProdutoView> product { get; set; }
    }
}
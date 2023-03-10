using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pedidos.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int empresa_id { get; set; }
        public int create_at { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
    }
}
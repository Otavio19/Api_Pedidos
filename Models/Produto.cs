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
        public int Id { get; set; }
        public int Company_id { get; set; }
        public int Create_at { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = false;
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
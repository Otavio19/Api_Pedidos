using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pedidos.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Empresa_id { get; set; }
        public string Nome { get; set; }
        [EmailAddressAttribute (ErrorMessage = "O endereço de e-mail inserido não está em um formato válido.")]
        public string Email { get; set; }
        [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 digitos.")]
        public string Senha { get; set; }
        public string? Token {get; set;}
    }
}
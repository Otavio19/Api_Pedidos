using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pedidos.Models.ViewModel
{
    public class UsuarioLogin
    {
        [Required(ErrorMessage = "E-mail é obrigatório!")]
        public string Email {get; set;}
        [Required(ErrorMessage = "Senha é obrigatória!")]
        public string Senha { get; set; }
    }
}
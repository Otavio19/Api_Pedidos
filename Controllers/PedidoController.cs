using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pedidos.Repository;
using Microsoft.AspNetCore.Mvc;
using Api_Pedidos.Models;

namespace Api_Pedidos.Controllers
{
    [ApiController]
    [Route("pedido")]
    public class PedidoController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] IPedido pedido)
        {
            var _pedido = pedido.Read();
            return Ok(_pedido);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pedido model, [FromServices] IPedido pedido)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            pedido.Create(model);
            return Ok();
        }
    }
}
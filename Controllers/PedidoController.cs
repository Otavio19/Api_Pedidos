using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pedidos.Repository;
using Microsoft.AspNetCore.Mvc;
using Api_Pedidos.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api_Pedidos.Controllers
{
    [ApiController]
    [Authorize]
    [Route("pedido")]
    public class PedidoController: ControllerBase
    {
        [Route("pedidos")]
        [HttpGet]
        public IActionResult Get([FromServices] IPedido pedido)
        {
            var _pedido = pedido.Read();
            return Ok(_pedido);
        }

        [HttpGet]
        public IActionResult GetByIdCompany([FromServices] IPedido pedido)
        {
            var companyId = int.Parse(User.FindFirst("CompanyId")!.Value);
            var pedidos = pedido.GetByCompany(companyId);

            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id,[FromServices] IPedido pedido)
        {
            var _pedido = pedido.GetById(Int32.Parse(id));

           return Ok(_pedido);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pedido model, [FromServices] IPedido pedido)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var companyId = int.Parse(User.FindFirst("CompanyId")!.Value);
            model.empresa_id = companyId;
            pedido.Create(model);
            return Ok();
        }
    }
}
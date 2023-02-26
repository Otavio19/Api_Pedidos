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
    [Route("produto")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] IProduto produto)
        {
            var _produto = produto.Read();
            return Ok(_produto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto model, [FromServices] IProduto produto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            produto.Create(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Produto model, [FromServices] IProduto produto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            produto.Update(new Guid(id), model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices] IProduto produto)
        {
            produto.Delete(new Guid(id));
            return Ok();
        }
    }
}
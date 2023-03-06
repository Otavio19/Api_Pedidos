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
    [Authorize]
    [ApiController]
    [Route("produto")]
    public class ProdutoController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Get([FromServices] IProduto produto)
        {
            var produtoId = int.Parse(User.FindFirst("CompanyId").Value);

            var _produto = produto.Read(produtoId);
            return Ok(_produto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id, [FromServices] IProduto produto)
        {
            var _produto = produto.GetById(Int32.Parse(id));
            return Ok(_produto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto model, [FromServices] IProduto produto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            model.empresa_id = int.Parse(User.FindFirst("CompanyId").Value);
            produto.Create(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Produto model, [FromServices] IProduto produto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            produto.Update(Int32.Parse(id), model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices] IProduto produto)
        {
            produto.Delete(Int32.Parse(id));
            return Ok();
        }
    }
}
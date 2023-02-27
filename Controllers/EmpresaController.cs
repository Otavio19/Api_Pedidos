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
    [Route("empresa")]
    public class EmpresaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] IEmpresa repository)
        {
            var _empresa = repository.Read();
            return Ok(_empresa);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Empresa empresa, [FromServices] IEmpresa repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            repository.Create(empresa);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Empresa model, [FromServices] IEmpresa repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            repository.Update(new Guid(id), model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices] IEmpresa repository)
        {
            repository.Delete(new Guid(id));
            return Ok();
        }
    }
}
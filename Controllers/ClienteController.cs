using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pedidos.Models;
using Api_Pedidos.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Pedidos.Controllers
{
    [ApiController]
    [Authorize]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll([FromServices] ICliente repository)
        {
            var companyId = int.Parse(User.FindFirst("CompanyId")!.Value);
            var _cliente = repository.Read(companyId);
            return Ok(_cliente);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id, [FromServices] ICliente repository)
        {
            var companyId = int.Parse(User.FindFirst("CompanyId")!.Value);
            var cliente = repository.GetById(Int32.Parse(id));
            if(cliente.Empresa_Id!= companyId)
                return NotFound();
            
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente model, [FromServices] ICliente repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var companyId = int.Parse(User.FindFirst("CompanyId")!.Value);
            model.Empresa_Id = companyId;

            repository.Create(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Cliente model, [FromServices] ICliente repository)
        {
            repository.Update(Int32.Parse(id), model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices] ICliente repository)
        {
            var companyId = int.Parse(User.FindFirst("CompanyId")!.Value);
            var cliente = repository.GetById(Int32.Parse(id));

            if(companyId != cliente.Empresa_Id)
                return NotFound();

            repository.Delete(Int32.Parse(id));
            return Ok("Cliente removido com sucesso.");
        }
    }
}
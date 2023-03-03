using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api_Pedidos.Models;
using Api_Pedidos.Models.ViewModel;
using Api_Pedidos.Repository;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;


namespace Api_Pedidos.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] IUsuario repository)
        {
            return Ok(repository.Read());
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioLogin usuario, [FromServices]IUsuario repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            Usuario _usuario = repository.Login(usuario.Email, usuario.Senha);

            if(_usuario == null)
                return Unauthorized();

            _usuario.Senha = "";
            _usuario.Token = GenerateToken(_usuario);

            return Ok(_usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario, [FromServices] IUsuario repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            repository.Create(usuario);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Usuario usuario, [FromServices] IUsuario repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            repository.Update(Int32.Parse(id), usuario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices] IUsuario repository)
        {
            repository.Delete(Int32.Parse(id));
            return Ok();
        }

        private string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var keyByte = Encoding.ASCII.GetBytes("UmTokenGrandeEDiferente");
            
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, usuario.Id.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyByte), SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
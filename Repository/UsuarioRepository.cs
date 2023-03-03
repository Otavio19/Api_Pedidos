using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Pedidos.Repository
{
    public interface IUsuario
    {
        List<Usuario> Read();
        Usuario Login(string email, string senha);
        void Create(Usuario usuario);
        void Update(int Id, Usuario usuario);
        void Delete(int Id);
    }

    public class UsuarioRepository : IUsuario
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var usuario = _context.Usuarios.Find(Id);
            _context.Entry(usuario).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Usuario> Read()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.SingleOrDefault(
                usuario => usuario.Email == email && usuario.Senha == senha
            );
        }

        public void Update(int Id, Usuario usuario)
        {
            var _usuario = _context.Usuarios.Find(Id);

            _usuario.Nome = usuario.Nome;
            _usuario.Email = usuario.Email;
            _usuario.Senha = usuario.Senha;
            _usuario.Empresa_id = usuario.Empresa_id;

            _context.Entry(_usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
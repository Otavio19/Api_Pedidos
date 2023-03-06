using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Pedidos.Repository
{

    public interface IEmpresa
    {
        List <Empresa> Read();
        void Create(Empresa empresa);
        void Delete(int id);
        void Update(Guid id, Empresa empresa);
    }

    public class EmpresaRepository : IEmpresa
    {
        private readonly DataContext _context;

        public EmpresaRepository(DataContext context)
        {
            _context = context;
        }

        public List<Empresa> Read()
        {
            return _context.Empresa.ToList();
        }

        public void Create(Empresa empresa)
        {
            //empresa.id = new Guid();
            _context.Empresa.Add(empresa);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var empresa = _context.Empresa.Find(id);
            _context.Empresa.Entry(empresa!).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(Guid id, Empresa empresa)
        {
            var _empresa = _context.Empresa.Find(id);
            _empresa!.Name = empresa.Name;
            
            _context.Empresa.Entry(_empresa).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
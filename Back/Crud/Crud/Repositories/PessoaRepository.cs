
using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Crud.Repositories
{
    public class PessoaRepository : IPessoa
    {
        private readonly appDbContext _context;
        public PessoaRepository(appDbContext context)
        {
            _context = context;
        }

        public Pessoa Create(Pessoa entity)
        {
            if (entity == null)  throw new ArgumentNullException(nameof(entity));
          _context.Pessoas.Add(entity);
           _context.SaveChanges();
            return entity;

        }

        public Pessoa Delete(int id)
        {
            var deletado = GetId(id);
            if(deletado is null) throw new ArgumentNullException(nameof(deletado));
            _context.Remove(deletado);
            _context.SaveChanges();
            return deletado;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _context.Pessoas.ToList();
        }

        public Pessoa GetId(int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);
            if(pessoa == null) throw new ArgumentNullException(nameof(pessoa));
            return pessoa;
        }

        public Pessoa Update(Pessoa entity)
        {
            if(entity == null) throw new ArgumentNullException(nameof (entity));
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}

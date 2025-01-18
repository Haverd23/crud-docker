using Crud.Models;

namespace Crud.Repositories
{
    public interface IPessoa
    {
       IEnumerable<Pessoa> GetAll();
        Pessoa GetId (int id);
        Pessoa Create (Pessoa entity);
        Pessoa Update (Pessoa entity);
        Pessoa Delete (int id);
    }
}

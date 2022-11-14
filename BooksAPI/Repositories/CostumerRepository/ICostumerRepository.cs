using BooksAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPI.Repositories.CostumerRepository
{
    public interface ICostumerRepository
    {
        Task<IEnumerable<Costumer>> Get();

        Task<Costumer> Get(int Id);

        Task<Costumer> Create(Costumer book);

        Task Update(Costumer book);

        Task Delete(int Id);
    }
}

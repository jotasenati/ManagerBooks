using BooksAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPI.Repositories.SalesBooksRepository
{
    public interface ISalesBooksRepository
    {
        Task<IEnumerable<SalesBook>> Get();

        Task<SalesBook> Get(int Id);

        Task<SalesBook> Create(SalesBook book);

        Task Update(SalesBook book);

        Task Delete(int Id);
    }
}

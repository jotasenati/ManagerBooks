using BooksAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPI.Repositories.CostumerRepository
{
    public class CostumerRepository : ICostumerRepository
    {
        public readonly BookContext _context;

        public CostumerRepository(BookContext context)
        {
            _context = context;
        }

        //TIPO DO METODO + RETORNO  --> (ENTRADA)
        public async Task<Costumer> Create(Costumer costumer)
        {
            _context.Costumers.Add(costumer);
            await _context.SaveChangesAsync();

            return costumer;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Costumers.FindAsync(id);
            _context.Costumers.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Costumer>> Get()
        {
            return await _context.Costumers.ToListAsync();
        }

        public async Task<Costumer> Get(int id)
        {
            return await _context.Costumers.FindAsync(id);
        }

        public async Task Update(Costumer costumer)
        {
            _context.Entry(costumer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

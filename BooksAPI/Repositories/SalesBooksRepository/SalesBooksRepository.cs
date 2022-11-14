using BooksAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPI.Repositories.SalesBooksRepository
{
    public class SalesBooksRepository : ISalesBooksRepository
    {
        public readonly BookContext _context;

        public SalesBooksRepository(BookContext context)
        {
            _context = context;
        }

        //TIPO DO METODO + RETORNO  --> (ENTRADA)
        
        public async Task<SalesBook> Create(SalesBook salesBook)
        {
            //acessando e inserindo venda no banco de dados.
            _context.SalesBooks.Add(salesBook);
            
            // (await - aguardando) - saveChangesAsync - Salvando alterações no banco de dados.
            await _context.SaveChangesAsync();

            return salesBook;
        }
        
        public async Task Delete(int id)
        {
            //Acessar venda realizada e atráves do ID realizar a remoção da venda selecionada.
            var salesBookToDelete = await _context.SalesBooks.FindAsync(id);
            _context.SalesBooks.Remove(salesBookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalesBook>> Get()
        {
            //listagem dos livros vendidos
            return await _context.SalesBooks.ToListAsync();
        }

        public async Task<SalesBook> Get(int id)
        {
            //busca a venda específica atráves do ID.
            return await _context.SalesBooks.FindAsync(id);
        }

        public async Task Update(SalesBook salesBook)
        {
            // Busca o estado anterior e altera pelo estado novo.
            _context.Entry(salesBook).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

   
}

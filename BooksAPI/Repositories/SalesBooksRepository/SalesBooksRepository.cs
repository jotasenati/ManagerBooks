using BooksAPI.Dto;
using BooksAPI.Model;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<SalesBookDto>> Get()
        {
            var query = (from sb in _context.SalesBooks
                         join b in _context.Books on sb.BookId equals b.Id
                         join c in _context.Costumers on sb.CostumerId equals c.Id
                         select new SalesBookDto
                         {
                             CostumerId = sb.CostumerId,
                             BookId = sb.BookId,
                             SalesBookId = sb.Id,
                             SalesDate = sb.SalesDate,
                             TitleBook = b.Title,
                             PriceBook = b.Price,
                             CustomerName = c.Name,
                             CustomerAddress = c.Address,
                             CustomerZipCode = c.ZipCode,
                         }).ToList();

            return query;
        }

        public async Task<SalesBook> Get(int id)
        {
            //busca a venda específica atráves do ID.
            var query = (from sb in _context.SalesBooks
                         join b in _context.Books on sb.BookId equals b.Id
                         join c in _context.Costumers on sb.CostumerId equals c.Id
                         where sb.Id == id
                         select new SalesBook
                         {
                             CostumerId = sb.CostumerId,
                             BookId = sb.BookId,
                             Id = sb.Id,
                             SalesDate = sb.SalesDate,
                             Book = new Book
                             {
                                 Title = b.Title,
                                 Price = b.Price,
                                 Author = b.Author,
                                 Description = b.Description,
                                 Id = b.Id
                             },
                             Costumer = new Costumer
                             {
                                 Name = c.Name,
                                 Address = c.Address,
                                 Email = c.Email,
                                 Id = c.Id,
                                 ZipCode = c.ZipCode,
                                 NumberRegister = c.NumberRegister
                             }
                         }).FirstOrDefault();

            return query;
        }

        public async Task Update(SalesBook salesBook)
        {
            // Busca o estado anterior e altera pelo estado novo.
            _context.Entry(salesBook).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }


}

using BooksAPI.Model;
using BooksAPI.Repositories.SalesBooksRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesBooksController : Controller
    { 
        //acessando informações do Isalesbooks
        private readonly ISalesBooksRepository _salesBooksRepository;

        public SalesBooksController (ISalesBooksRepository salesBooksRepository)
        {
            _salesBooksRepository = salesBooksRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesBook>>> GetSalesBooks()
        {
            var retorno = await _salesBooksRepository.Get();

            // Validando informações if retornando caso tenha conteúdo, else retornando sem conteúdo caso não tenha.
            if (retorno.Any())
                return Ok(retorno);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesBook>> GetSalesBooks(int id)
        {
            return await _salesBooksRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<SalesBook>> PostSalesBooks([FromBody] SalesBook salesBook)
        {
            var newSalesBook = await _salesBooksRepository.Create(salesBook);
            return CreatedAtAction(nameof(PostSalesBooks), new { id = newSalesBook.Id }, newSalesBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null || id == 0)
                return BadRequest();

            await _salesBooksRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSalesBooks(int id, [FromBody] SalesBook salesBook)
        {
            if (id != salesBook.Id)
                return BadRequest();

            await _salesBooksRepository.Update(salesBook);

            return NoContent();
        }
    }
}

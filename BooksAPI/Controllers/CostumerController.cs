using BooksAPI.Model;
using BooksAPI.Repositories.BookRepository;
using BooksAPI.Repositories.CostumerRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerRepository _costumerRepository;
        public CostumerController(ICostumerRepository costumerRepository)
        {
            _costumerRepository = costumerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Costumer>> GetCostumers()
        {
            var retorno = await _costumerRepository.Get();

            if (retorno.Any())
                return Ok(retorno);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Costumer>> GetCostumers(int id)
        {
            return await _costumerRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Costumer>> PostCostumers([FromBody] Costumer costumer)
        {
            var newCostumer = await _costumerRepository.Create(costumer);
            return CreatedAtAction(nameof(PostCostumers), new { id = newCostumer.Id }, newCostumer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var costumerToDelete = await _costumerRepository.Get(id);

            if (costumerToDelete == null)
                return NotFound();

            await _costumerRepository.Delete(costumerToDelete.Id);
            return NoContent();


        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCostumers(int id, [FromBody] Costumer costumer)
        {
            if (id != costumer.Id)
                return BadRequest();

            await _costumerRepository.Update(costumer);

            return NoContent();
        }
    }
}

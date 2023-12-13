using API.FurnitureStore.Data;
using API.FurnitureStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.FurnitureStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private readonly APIFurnitureStoreContext _context;

        public ClientsController(APIFurnitureStoreContext context)
        {
         
            _context = context;

        }

        [HttpGet]
        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            if (client == null) return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", client.Id, client);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Client cliente)
        {
            if (cliente == null) return NotFound();

            _context.Clients.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

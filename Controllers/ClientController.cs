using BankAPI.Application.DTO;
using BankAPI.Application.Validations;
using BankAPI.Domain;
using BankAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace BankAPI.Controllers
{
    //CRUD - Create, Read, Update, Delete
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly BankContext _context;

        public ClientController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pageSize = 20;
            var pageNumber = 1;

            var clients = await _context.Clients
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.ClientId)
                .ToListAsync();

            return Ok(clients);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClientDTO createClientDTO)
        {
            var createClientDTOValidation = new CreateClientDTOValidation();
            var validator = createClientDTOValidation.Validate(createClientDTO);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors.Select(x => x.ErrorMessage));
            }

            var client = new Client(
                createClientDTO.FirstName,
                createClientDTO.LastName,
                createClientDTO.Birthday,
                createClientDTO.NIF,
                createClientDTO.Address,
                createClientDTO.PostalCode,
                createClientDTO.City,
                createClientDTO.Country,
                createClientDTO.PhoneNumber,
                createClientDTO.Email
            );

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return Ok(client);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateClientDTO updateClientDTO)
        {
            //1ª forma
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }
            client.FirstName = updateClientDTO.FirstName;
            client.LastName = updateClientDTO.LastName;
            client.Address = updateClientDTO.Address;
            client.PostalCode = updateClientDTO.PostalCode;
            client.City = updateClientDTO.City;
            client.Country = updateClientDTO.Country;
            client.PhoneNumber = updateClientDTO.PhoneNumber;
            client.Email = updateClientDTO.Email;

            await _context.SaveChangesAsync();

            /*
            //2ª forma
            await _context.Clients
                .Where(x => x.ClientId == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(x => x.FirstName, u => updateClientDTO.FirstName)
                );
            */

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            //1ª forma - 2 execuções na base de dados
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            /*
            //2ª forma - mais performática - 1 execução na base de dados
            var rowsDeleted = await _context.Clients
                .Where(x => x.ClientId == id)
                .ExecuteDeleteAsync();

            if (rowsDeleted == 0)
                return NotFound();
            */

            return NoContent();
        }
    }
}
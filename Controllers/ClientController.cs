using BankAPI.Application.DTO;
using BankAPI.Application.Validations;
using BankAPI.Domain;
using BankAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Controllers
{
    //CRUD - Create, Read, Update, Delete
    [ApiController]
    [Route("[controller]")]
    public class ClientController: ControllerBase
    {
        private readonly BankContext _context;
        public ClientController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clients = await _context.Clients.ToListAsync();
            return Ok(clients);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
            if(client == null)
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

            if(!validator.IsValid)
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

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return NoContent();
        }
    }
}

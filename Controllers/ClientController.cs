using BankAPI.Application.DTO;
using BankAPI.Application.Validations;
using BankAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController: ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClientDTO createClientDTO)
        {
            var createClientDTOValidation = new CreateClientDTOValidation();
            var validator = createClientDTOValidation.Validate(createClientDTO);

            //Fail Fast validation
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

            return Ok(client);
        }
    }
}

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

            // mapear dados, guardar base de dados
            // de / para

            var anna = new Client(
                createClientDTO.FirstName,
                createClientDTO.LastName,
                new DateOnly(1986, 09, 05),
                "2952225555",
                "Rua de trás",
                "3006-097",
                "Casal",
                "Portugal",
                "987456321",
                "anna@barreto.com"
            );
            
            return Ok(anna);
        }
    }
}

using BankAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Devolve uma lista de contas");
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok("Devolve a conta do banco");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            List<Client> clients = new List<Client>();
            var anna = new Client(
                "Anna",
                "Barreto",
                new DateOnly(1986, 09, 05),
                "2952225555",
                "Rua de trás",
                "3006-097",
                "Casal",
                "Portugal",
                "987456321",
                "anna@barreto.com"
            );
            clients.Add(anna);

            BankAccount bankAccount = new BankAccount(clients);

            return Ok(bankAccount);
        }
    }
}
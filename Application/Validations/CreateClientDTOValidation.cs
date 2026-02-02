using BankAPI.Application.DTO;
using FluentValidation;

namespace BankAPI.Application.Validations
{
    public class CreateClientDTOValidation : AbstractValidator<CreateClientDTO>
    {
        public CreateClientDTOValidation()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(3, 50);
            RuleFor(x => x.LastName).NotNull().NotEmpty().Length(3, 50);
            RuleFor(x => x.Birthday).NotNull().LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now.AddYears(-18)));
            RuleFor(x => x.NIF).NotNull().NotEmpty().Length(9);
            RuleFor(x => x.Address).NotNull().NotEmpty().Length(3, 250);
            RuleFor(x => x.PostalCode).NotNull().NotEmpty().Length(8);
            RuleFor(x => x.City).NotNull().NotEmpty().Length(3, 150);   
            RuleFor(x => x.Country).NotNull().NotEmpty().Length(3, 100);
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().Length(9);
            RuleFor(x => x.Email).NotNull().NotEmpty().Length(7, 200);
        }
    }
}
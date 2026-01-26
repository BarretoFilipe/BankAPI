namespace BankAPI.Domain
{
    public class Client
    {
        public Client(string firstName, string lastName, DateOnly birthday, string nif, string address, string postalCode, string city, string country, string phoneNumber, string email)
        {
            ClientId = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            NIF = nif;
            Address = address;
            PostalCode = postalCode;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public Guid ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public Guid BankAccountId { get; set; }
        public string NIF { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
namespace BankAPI.Domain
{
    public class Client
    {
        protected Client() { }
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

        public Guid ClientId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly Birthday { get; private set; }
        //public Guid BankAccountId { get; private set; }
        public string NIF { get; private set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        //public BankAccount BankAccount { get; private set; }
    }
}
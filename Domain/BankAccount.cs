namespace BankAPI.Domain
{
    public class BankAccount
    {
        protected BankAccount() { }

        /*
        public BankAccount(List<Client> clients)
        {
            BankAccountId = Guid.NewGuid();
            IBAN = $"PT5000350654001{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
            Balance = 0m;

            if (clients.Count == 0)
            {
                throw new ArgumentException("É necessário enviar clientes para criar a conta");
            }
            Clients = clients;
        }

        public Guid BankAccountId { get; private set; }
        public string IBAN { get; private set; }
        public decimal Balance { get; private set; }
        public List<Client> Clients { get; private set; }
        public List<Transaction> Senders { get; private set; }
        public List<Transaction> Receivers { get; private set; }
        */
    }
}
using BankAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAPI.Infrastructure.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(x => x.ClientId);

            builder.Property(x => x.FirstName)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Birthday)
                .IsRequired();

            builder.Property(x => x.NIF)
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(x => x.Address)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.PostalCode)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(x => x.City)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Country)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

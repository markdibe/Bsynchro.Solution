using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bsynchro.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bsynchro.EntityFramework.Seeding
{

    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                new Account
                {
                    AccountId = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    AccountNumber = "1234567890"
                },
                new Account
                {
                    AccountId = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Doe",
                    AccountNumber = "0987654321"
                }
            );
        }
    }

}

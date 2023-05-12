using Bsynchro.Domain;
using Bsynchro.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.EntityFramework.Seeding
{
    public class SeedData
    {
        public static void Seed(RJPDbContext context)
        {
            if (context.Accounts.Any(x => x.AccountNumber.Equals("1234567890")))
            {
                return;
            }
            // Create some accounts
            var account1 = new Account
            {
                FirstName = "John",
                LastName = "Doe",
                AccountNumber = "1234567890"
            };

            var account2 = new Account
            {
                FirstName = "Jane",
                LastName = "Doe",
                AccountNumber = "9876543210"
            };

            context.Accounts.Add(account1);
            context.Accounts.Add(account2);
            context.SaveChanges();

            // Create some transactions
            var transaction1 = new Transaction
            {
                AccountId = account1.AccountId,
                TransactionTime = DateTime.Now,
                Amount = 100m,
            };

            var transaction2 = new Transaction
            {
                AccountId = account1.AccountId,
                TransactionTime = DateTime.Now,
                Amount = -50m,
            };

            var transaction3 = new Transaction
            {
                AccountId = account2.AccountId,
                TransactionTime = DateTime.Now,
                Amount = 100m,
            };

            context.Transactions.Add(transaction1);
            context.Transactions.Add(transaction2);
            context.Transactions.Add(transaction3);
            context.SaveChanges();
        }
    }
}

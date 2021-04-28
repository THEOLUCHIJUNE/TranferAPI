using System;
using TranferAPI.Interface;
using TranferAPI.Models;
using System.Collections.Generic;
using System.Linq;
using TranferAPI.DatabaseContext;

namespace TranferAPI.Service
{
    public class TransferService : ITransferService
    {
        private readonly ApplicationDbContext _context;
        public TransferService(
            ApplicationDbContext context
        )

        {
            _context = context;
        }

        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }
        public Account GetOneAccount(string id)
        {
            return _context.Accounts.FirstOrDefault(PID => PID.Id == id);
        }

        
        public Account AddAccount(Account model)
        {
            if(model is null) throw new ArgumentNullException(message: "Account cannot be null", null);

            var account = new Account
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Balance = model.Balance,
                Amount = model.Amount,
                Description = model.Description,
                AccountNumber = Guid.NewGuid().ToString()
                
                
                   //Random rnd = new Random();
                   // Account.AccountNumber = rnd.Next(12345678, 98765432);

            };

            _context.Accounts.Add(account);
            _context.SaveChanges();

            return account;
                
        }

        public Account UpdatePutAccount(string id, string AccountNumber, Account model)
        {
            var account = GetOneAccount(id);
            

            if (account is null) throw new ArgumentOutOfRangeException(message: "Account cannot be null", null);
            
            
            account.Name = model.Name;
            account.Balance = model.Balance;
            account.Amount = model.Amount;
            account.Description = model.Description;
            

            _context.Accounts.Update(account);
            _context.SaveChanges();

            return account;
                
        }

        public Account UpdatePatchAccount(string id,string AccountNumber, Account model)
        {
            var account = GetOneAccount(id);

            if (account is null) throw new ArgumentOutOfRangeException(message: "No account with this Id found", null);

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                account.Name = model.Name;
            }

            if (!(model.Balance).Equals(null))
            {
                account.Balance = model.Balance;
            }

            if (!(model.Description).Equals(null))
            {
                account.Description = model.Description;
            }

            if (!(model.Amount).Equals(null))
            {
                account.Amount = model.Amount;
            }

            _context.Accounts.Update(account);
            _context.SaveChanges();

            return account;
                
        }

        public Account DeleteAccount(string id)
        {
            var account = GetOneAccount(id);
            
            if (account is null) throw new ArgumentOutOfRangeException(message: "Person cannot be null", null);

            _context.Accounts.Remove(account);
            _context.SaveChanges();

            return account;
                
        }
    }
}
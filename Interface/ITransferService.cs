using System.Collections.Generic;
using TranferAPI.Models;

namespace TranferAPI.Interface
{
    public interface ITransferService
    {
        List<Account> GetAllAccounts();

        Account GetOneAccount(string id);

        Account AddAccount(Account model);

        Account UpdatePutAccount(string id,string AccountNumber, Account model);

        Account UpdatePatchAccount(string id,string AccountNumber, Account model);

        Account DeleteAccount(string id);
    }
    
}
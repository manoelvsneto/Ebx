using Ebx.Models;

namespace Ebx.Service
{
    public interface IAccountService
    {
        Account GetBalance(string accountId);
        bool Deposit(string id, int amount);
        bool Withdraw(string id, int amount);
        bool Transfer(string originAccountId, string destinationAccountId, int amount);
        void Reset();

        bool Create(string id);
    }

}
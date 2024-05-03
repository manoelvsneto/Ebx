using Ebx.Models;
using Ebx.Repository;
using System.Linq.Expressions;

namespace Ebx.Service
{
    public class AccountService(IAccountRepository repository) : IAccountService
    {
        public IAccountRepository _repository = repository;

        public Account? GetBalance(string accountId)
        {
            Account? account = _repository.GetById(accountId);
            return account;
        }

        public bool Deposit(string id, int amount)
        {
            try
            {
                Account? account_ = _repository.GetById(id);

                if (account_ == null)
                {
                    Account account = new() { Id = id, Balance = amount };
                    _repository.Add(account);
                }
                else
                {
                    account_.Balance += amount;
                    _repository.Update(account_);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Withdraw(string id, int amount)
        {
            try
            {
                Account? account_ = _repository.GetById(id);
                if (account_ == null)
                {
                    return false;
                }
                else
                {
                    account_.Balance -= amount;
                    _repository.Update(account_);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Transfer(string originAccountId, string destinationAccountId, int amount)
        {
            try
            {
                Account? originAccount = _repository.GetById(originAccountId);
                if (originAccount == null)
                {
                    return false;
                }
                Account? destinationAccount = _repository.GetById(destinationAccountId);
                if (destinationAccount == null)
                {
                    Create(destinationAccountId);
                    destinationAccount = _repository.GetById(destinationAccountId);
                }
                if (Withdraw(originAccountId, amount))
                {
                    if (Deposit(destinationAccountId, amount))
                    {
                        return true;
                    }
                    else
                    {
                        //rollback transaction
                        Deposit(originAccountId, amount);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch { 
                return false; 
            }
        }

        public void Reset()
        {
            _repository.DeleteAll();
        }

        public bool Create(string id)
        {
            Account account = new() { Id = id, Balance = 0 };
            _repository.Add(account);
            return true;
        }

        public List<Account> GetAll()
        {
            return _repository.GetList();
        }
    }

}
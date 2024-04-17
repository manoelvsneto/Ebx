using Ebx.Models;
namespace Ebx.Repository
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account GetById(string id);
        List<Account> GetList();
        void Add(Account ac);
        void Update(Account ac);
        void Delete(Account ac);
        void DeleteAll();
    }
}
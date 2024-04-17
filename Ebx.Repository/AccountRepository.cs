using Ebx.Data;
using Ebx.Models;
using Microsoft.EntityFrameworkCore;

namespace Ebx.Repository
{
    public class AccountRepository : IAccountRepository
    {

        private readonly AppDbContext _dbContext;

        public AccountRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Account> GetAll()
        {
            return _dbContext.Accounts.ToList();
        }

        public Account GetById(string id)
        {
            return _dbContext.Accounts.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Account> GetList()
        {
            return _dbContext.Accounts.ToList<Account>();
        }

        public void Add(Account ac)
        {
            _dbContext.Accounts.Add(ac);
            _dbContext.SaveChanges();
        }

        public void Update(Account ac)
        {
            _dbContext.Entry(ac).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Account ac)
        {
            _dbContext.Accounts.Remove(ac);
            _dbContext.SaveChanges();
        }

        public void DeleteAll()
        {
            var data = GetList();
            foreach (var d in data)
            {
                Delete(d);
            }
        }
    }
}
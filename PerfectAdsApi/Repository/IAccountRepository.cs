using MongoDB.Bson;
using PerfectAdsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectAdsApi.Repository
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts();

        Task<Account> GetAccountById(ObjectId id);

        Task CreateAccount(Account account);

        Task UpdateAccount(Account account);

        Task DeleteAccount(ObjectId id);
    }
}

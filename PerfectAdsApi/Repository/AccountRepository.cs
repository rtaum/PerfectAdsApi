using MongoDB.Bson;
using MongoDB.Driver;
using PerfectAdsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectAdsApi.Repository
{
    public class AccountRepository : IAccountRepository
    {
        /// <summary>
        /// Accounts database name
        /// </summary>
        private const string AccountsDbName = "accountsdb";

        /// <summary>
        /// Accounts collection name
        /// </summary>
        private const string AccountsCollectionName = "accounts";

        /// <summary>
        /// Get all limit is set to 1000 items
        /// </summary>
        private static readonly FindOptions<Account, Account> RecordLimitOption = new FindOptions<Account, Account>()
        {
            Limit = 1000
        };

        /// <summary>
        /// Mongo database instance. To be injected.
        /// </summary>
        private IMongoDatabase _mongoDatabase;

        /// <summary>
        /// Account repository constructor.
        /// </summary>
        /// <param name="mongoClient">Mongo database client injected into AccountRepository class</param>
        public AccountRepository(IMongoClient mongoClient)
        {
            _mongoDatabase = mongoClient.GetDatabase(AccountsDbName);
        }

        /// <summary>
        /// Craete account method.
        /// </summary>
        /// <param name="account">Account to be created in database.</param>
        /// <returns></returns>
        public async Task CreateAccount(Account account)
        {
            await _mongoDatabase.
                GetCollection<Account>(AccountsCollectionName).
                InsertOneAsync(account);
        }

        /// <summary>
        /// Method to delete account from the database.
        /// </summary>
        /// <param name="id">Account id to be deleted.</param>
        /// <returns></returns>
        public async Task DeleteAccount(ObjectId id)
        {
            await _mongoDatabase.
                GetCollection<Account>(AccountsCollectionName).
                DeleteOneAsync<Account>(a => a.Id == id);
        }

        /// <summary>
        /// Method that returns Account by given id.
        /// </summary>
        /// <param name="id">Account id.</param>
        /// <returns>Account that was found be given id.</returns>
        public async Task<Account> GetAccountById(ObjectId id)
        {
            using (var accountResultCursor = await _mongoDatabase.
                                                GetCollection<Account>(AccountsCollectionName).
                                                FindAsync<Account>(a => a.Id == id))
            {
                return await accountResultCursor.FirstOrDefaultAsync<Account>();
            }
        }

        /// <summary>
        /// Method that returns all Accounts in the database. There is limit 1000 element by default.
        /// </summary>
        /// <returns>List of all accounts in the database.</returns>
        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            using (var accountResultCursor = await _mongoDatabase.
                                    GetCollection<Account>(AccountsCollectionName).
                                    FindAsync<Account>(a => true, RecordLimitOption))
            {
                return await accountResultCursor.ToListAsync<Account>();
            };
        }

        /// <summary>
        /// Method that updates given account.
        /// </summary>
        /// <param name="account">Account to update.</param>
        /// <returns></returns>
        public async Task UpdateAccount(Account account)
        {
            await _mongoDatabase.
                GetCollection<Account>(AccountsCollectionName).
                ReplaceOneAsync<Account>(a => a.Id == account.Id, account);
        }
    }
}
using MongoDB.Bson;
using PerfectAdsApi.Models;
using PerfectAdsApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PerfectAdsApi.Controllers
{
    public class AccountsController : ApiController
    {
        /// <summary>
        /// Repository instance to provide database access logic.
        /// </summary>
        private IAccountRepository _accountRepository;

        /// <summary>
        /// AccountController constructor.
        /// </summary>
        /// <param name="accountRepository">Repository object which is being injected by dependency injection framework.</param>
        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// Method is responsible for returning all Accounts currently stored in databse.
        /// </summary>
        /// <returns>List of all Accounts</returns>
        [HttpGet]
        public async Task<IEnumerable<Account>> Get()
        {
            return await _accountRepository.GetAllAccounts();
        }

        /// <summary>
        /// Method is responsible for returning Account by given id.
        /// </summary>
        /// <param name="id">Account id field</param>
        /// <returns>Return Account with given id is found. Null otherwise.</returns>
        [HttpGet]
        public async Task<Account> Get(string id)
        {
            ObjectId objectId = new ObjectId(id);
            return await _accountRepository.GetAccountById(objectId);
        }

        /// <summary>
        /// Updates the given account.
        /// </summary>
        /// <param name="account">Account object to update in the database</param>
        [HttpPost]
        public async Task Post([FromUri] string id, [FromBody]Account account)
        {
            account.Id = new ObjectId(id);
            await _accountRepository.UpdateAccount(account);
        }

        /// <summary>
        /// Creates new account.
        /// </summary>
        /// <param name="account">Account object to be stored in the database</param>
        [HttpPut]
        public async Task Put([FromBody]Account account)
        {
            account.Hash = Guid.NewGuid();
            account.HashExpire = DateTime.Now.AddHours(1);
            await _accountRepository.CreateAccount(account);
        }

        /// <summary>
        /// Deletes the given account.
        /// </summary>
        /// <param name="value">Account id to delete from the database</param>
        [HttpDelete]
        public async Task Delete(string id)
        {
            ObjectId objectId = new ObjectId(id);
            await _accountRepository.DeleteAccount(objectId);
        }
    }
}

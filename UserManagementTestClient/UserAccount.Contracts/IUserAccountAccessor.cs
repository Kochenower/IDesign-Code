using System.ServiceModel;

namespace UserAccount.Contracts
{
    [ServiceContract(Namespace = "UserAccount.Contracts.Accessor")]
    public interface IUserAccountAccessor
    {
        /// <summary>
        /// Get an array of Accounts
        /// </summary>
        /// <returns>Account Array</returns>
        [OperationContract]
        Account[] GetAccounts();

        /// <summary>
        /// Create a new account
        /// </summary>
        /// <param name="account">Account to Create</param>
        /// <returns>Result of the account Creation</returns>
        [OperationContract]
        Result CreateAccount(Account account);

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="account">Account to Update</param>
        /// <param name="deleteAccount">Was the request a delete?</param>
        /// <returns>Result of the account update</returns>
        [OperationContract]
        Result UpdateAccount(Account account, bool deleteAccount = false);
    }
}

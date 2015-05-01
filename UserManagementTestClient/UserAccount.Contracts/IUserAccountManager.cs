using System.ServiceModel;

namespace UserAccount.Contracts
{
    [ServiceContract(Namespace = "UserAccount.Contracts.Manager")]
    public interface IUserAccountManager
    {
        /// <summary>
        /// Get an array of Accounts
        /// </summary>
        /// <returns>Account Array</returns>
        [OperationContract]
        Account[] GetAccounts();

        /// <summary>
        /// Get a specific account by user name.
        /// </summary>
        /// <param name="userName">Account User Name</param>
        /// <returns>Specified Account</returns>
        [OperationContract]
        Account GetAccount(string userName);

        /// <summary>
        /// Log into the account
        /// </summary>
        /// <param name="userName">Account User Name</param>
        /// <param name="password">Account Password</param>
        /// <returns>Result of Login</returns>
        [OperationContract]
        Result Login(string userName, string password);

        /// <summary>
        /// Create a new account
        /// </summary>
        /// <param name="userName">Account User Name</param>
        /// <param name="password">Account Password</param>
        /// <param name="firstName">Account First Name</param>
        /// <param name="lastName">Account Last Name</param>
        /// <param name="level">Account Security Level</param>
        /// <returns></returns>
        [OperationContract]
        Result CreateAccount(string userName, string password, string firstName, string lastName, UserSecurityLevel level = UserSecurityLevel.Standard);

        /// <summary>
        /// Update an account
        /// </summary>
        /// <param name="userName">Account User Name</param>
        /// <param name="password">Account Password</param>
        /// <param name="firstName">Account First Name</param>
        /// <param name="lastName">Account Last Name</param>
        /// <param name="lockAccount">Is the Update to lock the account?</param>
        /// <returns>Result of the Update</returns>
        [OperationContract]
        Result UpdateAccount(string userName, string password, string firstName, string lastName, bool? lockAccount = null);

        /// <summary>
        /// Delete an account
        /// </summary>
        /// <param name="userName">Account User Name</param>
        /// <returns>Result of Delete</returns>
        [OperationContract]
        Result DeleteAccount(string userName);
    }
}

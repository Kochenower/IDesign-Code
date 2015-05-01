using System.ServiceModel;

namespace UserAccount.Contracts
{
    [ServiceContract(Namespace = "UserAccount.Contracts.Engine")]
    public interface IUserAccountEngine
    {
        #region Methods

        /// <summary>
        /// Validate that the password meets all the business logic for password strength and history.
        /// </summary>
        /// <param name="account">Account for password validation</param>
        /// <param name="password">Password to validate</param>
        /// <returns>Result of password validation</returns>
        [OperationContract]
        Result ValidatePassword(Account account, string password);

        /// <summary>
        /// Validate that the new account is acceptable. 
        /// Includes a check for password strength and if the user name is taken.
        /// </summary>
        /// <param name="userName">Account User Name</param>
        /// <param name="password">Account Password</param>
        /// <returns>Result of validation of new account</returns>
        [OperationContract]
        Result ValidateNewUserAccount(string userName, string password);

        /// <summary>
        /// Authenticate the account and login.
        /// </summary>
        /// <param name="userName">Account User Name</param>
        /// <param name="password">Account Password</param>
        /// <returns>Result of the account authentication</returns>
        [OperationContract]
        Result AuthenticateAccount(string userName, string password);

        #endregion
    }
}

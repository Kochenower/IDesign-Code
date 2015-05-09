using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using ServiceModelEx;
using UserAccount.Accessor;
using UserAccount.Contracts;
using UserAccount.Engine;

namespace UserAccount.Manager
{
    [ServiceBehavior]
    public class UserAccountManager : IUserAccountManager
    {
        #region Fields

        private readonly Lazy<IUserAccountAccessor> _UserAccountAccessor;
        private readonly Lazy<IUserAccountEngine> _UserAccountEngine;

        #endregion

        #region Constructor

        public UserAccountManager()
        {
            _UserAccountAccessor = new Lazy<IUserAccountAccessor>(InProcFactory.CreateInstance<UserAccountAccessor, IUserAccountAccessor>);
            _UserAccountEngine = new Lazy<IUserAccountEngine>(InProcFactory.CreateInstance<UserAccountEngine, IUserAccountEngine>);
        }

        #endregion

        #region Private Methods

        private Result UpdateAccountPassword(Account account, string password)
        {
            var isPasswordValid = _UserAccountEngine.Value.ValidatePassword(account, password);

            if (isPasswordValid.IsSuccessful)
            {
                isPasswordValid.Account.Password.Add(password);

                isPasswordValid.Account.PasswordLastChangedDate = DateTime.Now;

                if (isPasswordValid.Account.Password.Count == 4)
                {
                    isPasswordValid.Account.Password.Remove(account.Password.FirstOrDefault());
                }
            }

            return isPasswordValid;
        }

        #endregion

        #region Service Methods

        [OperationBehavior]
        public Account[] GetAccounts()
        {
            return _UserAccountAccessor.Value.GetAccounts();
        }

        [OperationBehavior]
        public Account GetAccount(string userName)
        {
            return GetAccounts().FirstOrDefault(x => x.UserName == userName);
        }

        [OperationBehavior]
        public Result Login(string userName, string password)
        {
            return _UserAccountEngine.Value.AuthenticateAccount(userName, password);
        }

        [OperationBehavior]
        public Result CreateAccount(string userName, string password, string firstName, string lastName,
            UserSecurityLevel level = UserSecurityLevel.Standard)
        {
            var isAcceptableAccount = _UserAccountEngine.Value.ValidateNewUserAccount(userName, password);

            if (!isAcceptableAccount.IsSuccessful) 
                return isAcceptableAccount;
            
            var account = new Account()
            {
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                IsLocked = false,
                LoginAttempts = 0,
                Password = new List<string>() { password },
                PasswordLastChangedDate = DateTime.Now,
                UserSecurityLevel = level
            };

            return _UserAccountAccessor.Value.CreateAccount(account);
        }

        [OperationBehavior]
        public Result UpdateAccount(string userName, string password, string firstName, string lastName, bool? lockAccount = null)
        {
            var account = GetAccount(userName);

            if (account == null)
            {
                return new Result()
                {
                    Activity = "Update Account",
                    IsSuccessful = false,
                    Reason = "Account was not found."
                };
            }

            Debug.Assert(account != null);

            if (account.FirstName == firstName && account.LastName == lastName && string.IsNullOrEmpty(password) && lockAccount == null)
            {
                return new Result()
                {
                    Activity = "Account Update",
                    IsSuccessful = true,
                    Reason = "Nothing to update.",
                    Account = account
                };
            }

            if (!string.IsNullOrEmpty(firstName) && account.FirstName != firstName)
            {
                account.FirstName = firstName;
            }

            if (!string.IsNullOrEmpty(lastName) && account.LastName != lastName)
            {
                account.LastName = lastName;
            }

            if (!string.IsNullOrEmpty(password))
            {
                var result = UpdateAccountPassword(account, password);

                if (!result.IsSuccessful)
                    return result;
                
                account = result.Account;

                Debug.Assert(account.Password.FirstOrDefault() == password);
            }           

            if (lockAccount != null)
            {
                if (!lockAccount.Value)              
                    account.LoginAttempts = 0;

                account.IsLocked = lockAccount.Value;
            }

            return _UserAccountAccessor.Value.UpdateAccount(account);

            //If this point is reached then the update has failed.
        }      

        [OperationBehavior]
        public Result DeleteAccount(string userName)
        {
            var account = GetAccount(userName);

            if (account != null)
            {
                return _UserAccountAccessor.Value.UpdateAccount(account, true);
            }

            return new Result()
            {
                Activity = "Delete Account",
                IsSuccessful = false,
                Reason = "Account was not found."
            };
        }

        #endregion
    }
}

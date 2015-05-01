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
        private readonly Lazy<IUserAccountAccessor> _UserAccountAccessor;
        private readonly Lazy<IUserAccountEngine> _UserAccountEngine;

        public UserAccountManager()
        {
            _UserAccountAccessor = new Lazy<IUserAccountAccessor>(InProcFactory.CreateInstance<UserAccountAccessor, IUserAccountAccessor>);
            _UserAccountEngine = new Lazy<IUserAccountEngine>(InProcFactory.CreateInstance<UserAccountEngine, IUserAccountEngine>);
        }

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

            if (isAcceptableAccount.IsSuccessful)
            {
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

            return isAcceptableAccount;
        }

        [OperationBehavior]
        public Result UpdateAccount(string userName, string password, string firstName, string lastName, bool? lockAccount = null)
        {
            var account = GetAccount(userName);

            if (account != null)
            {
                Debug.Assert(account != null);

                if (!string.IsNullOrEmpty(firstName) && account.FirstName != firstName)
                {
                    Debug.Assert(!string.IsNullOrEmpty(firstName));
                    Debug.Assert(account.FirstName != firstName);

                    account.FirstName = firstName;
                }

                if (!string.IsNullOrEmpty(lastName) && account.LastName != lastName)
                {
                    Debug.Assert(!string.IsNullOrEmpty(lastName));
                    Debug.Assert(account.LastName != lastName);

                    account.LastName = lastName;
                }

                if (!string.IsNullOrEmpty(password))
                {
                    Debug.Assert(!string.IsNullOrEmpty(password));

                    var isPasswordValid = _UserAccountEngine.Value.ValidatePassword(account, password);

                    if (isPasswordValid.IsSuccessful)
                    {
                        account.Password.Add(password);

                        account.PasswordLastChangedDate = DateTime.Now;

                        if (account.Password.Count == 4)
                        {
                            account.Password.Remove(account.Password.FirstOrDefault());
                        }
                    }
                    else
                    {
                        return isPasswordValid;
                    }
                }

                if (lockAccount != null)
                {
                    Debug.Assert(lockAccount != null);

                    if (!lockAccount.Value)
                    {
                        account.LoginAttempts = 0;
                    }

                    account.IsLocked = lockAccount.Value;
                }

                return _UserAccountAccessor.Value.UpdateAccount(account);
            }

            //If this point is reached then the update has failed.
            return new Result()
            {
                Activity = "Update Account",
                IsSuccessful = false,
                Reason = "Account was not found."
            };
        }

        [OperationBehavior]
        public Result DeleteAccount(string userName)
        {
            var account = GetAccount(userName);

            if (account != null)
            {
                Debug.Assert(account != null);

                return _UserAccountAccessor.Value.UpdateAccount(account, true);
            }
            else
            {
                return new Result()
                {
                    Activity = "Delete Account",
                    IsSuccessful = false,
                    Reason = "Account was not found."
                };
            }
        }
    }
}

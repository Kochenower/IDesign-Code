using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using ServiceModelEx;
using UserAccount.Accessor;
using UserAccount.Contracts;

namespace UserAccount.Engine
{
    [ServiceBehavior]
    public class UserAccountEngine : IUserAccountEngine
    {
        #region Fields

        private Lazy<IUserAccountAccessor> _UserAccountAccessor;

        #endregion

        #region Constructor

        public UserAccountEngine()
        {
            _UserAccountAccessor = new Lazy<IUserAccountAccessor>(() => InProcFactory.CreateInstance<UserAccountAccessor, IUserAccountAccessor>());
        }

        #endregion

        #region Private Methods

        private static bool ValidPasswordStrength(string password)
        {
            //Password Strength Requirements:
            //1 lowercase + 
            //1 uppercase + 
            //1 number + 
            //1 special character or space
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
        }

        private Result Login(Account account, string password)
        {
            Result result;

            if (account.Password.LastOrDefault() == password)
            {
                account.LoginAttempts = 0;
                result = _UserAccountAccessor.Value.UpdateAccount(account);

                if (result.IsSuccessful)
                {
                    result.Activity = "Login";
                }
            }
            else
            {
                account.LoginAttempts++;
                result = _UserAccountAccessor.Value.UpdateAccount(account);

                if (result.IsSuccessful)
                {
                    result.IsSuccessful = false;
                    result.Account = account;
                    result.Reason = "Incorrect Password.";
                }
            }

            return result;
        }

        #endregion

        #region Service Methods

        public Result ValidatePassword(Account account, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return new Result()
                {
                    IsSuccessful = false,
                    Reason = "Please enter a password."
                };
            }

            Debug.Assert(!string.IsNullOrEmpty(password));

            if (account == null)
            {
                return new Result()
                {
                    IsSuccessful = false,
                    Reason = "Account was null."
                };
            }

            Debug.Assert(account != null);

            if (!ValidPasswordStrength(password))
            {
                return new Result()
                {
                    IsSuccessful = false,
                    Account = account,
                    Activity = "Validate Password",
                    Reason = "Password does not meet the acceptable password strength."
                };
            }

            if (!account.Password.Contains(password))
            {
                return new Result()
                {
                    IsSuccessful = true,
                    Account = account,
                    Activity = "Validate Password"
                };
            }

            //If this point is reached then the password validation failed.
            return new Result()
            {
                IsSuccessful = false,
                Account = account,
                Activity = "Validate Password",
                Reason = "Password does not meet the acceptable historical requirements."
            };
        }

        public Result ValidateNewUserAccount(string userName, string password)
        {
            var result = new Result { Activity = "Validate New User Account" };

            if (string.IsNullOrEmpty(userName))
            {
                return new Result()
                {
                    IsSuccessful = false,
                    Reason = "Please enter a user name."
                };
            }

            if (string.IsNullOrEmpty(password))
            {
                return new Result()
                {
                    IsSuccessful = false,
                    Reason = "Please enter a password."
                };
            }

            Debug.Assert(!string.IsNullOrEmpty(userName));
            Debug.Assert(!string.IsNullOrEmpty(password));


            if (ValidPasswordStrength(password))
            {
                if (_UserAccountAccessor.Value.GetAccounts().All(x => x.UserName != userName))
                {
                    result.IsSuccessful = true;
                }
                else
                {
                    result.IsSuccessful = false;
                    result.Reason = "User Name is taken.";
                }
            }
            else
            {
                result.IsSuccessful = false;
                result.Reason = "Password does not meet the acceptable password strength.";
            } 

            return result;
        }

        public Result AuthenticateAccount(string userName, string password)
        {
            var result = new Result {Activity = "Authentication"};

            if (string.IsNullOrEmpty(userName))
            {
                return new Result()
                {
                    IsSuccessful = false,
                    Reason = "Please enter a user name."
                };
            }

            if (string.IsNullOrEmpty(password))
            {
                return new Result()
                {
                    IsSuccessful = false,
                    Reason = "Please enter a password."
                };
            }

            Debug.Assert(!string.IsNullOrEmpty(userName));
            Debug.Assert(!string.IsNullOrEmpty(password));

            var account = _UserAccountAccessor.Value.GetAccounts().FirstOrDefault(x =>
                x.UserName == userName);

            if (account == null)
            {
                result.IsSuccessful = false;
                result.Reason = "User Account was not found.";

                return result;
            }

            Debug.Assert(account != null);

            if (account.IsLocked)
            {
                result.IsSuccessful = false;
                result.Account = account;
                result.Reason = "User Account is Locked.";
            }
            else
            {
                if (account.LoginAttempts < 5)
                {
                    result = Login(account, password);
                }
                else
                {
                    account.IsLocked = true;
                    result = _UserAccountAccessor.Value.UpdateAccount(account);

                    if (result.IsSuccessful)
                    {
                        result.IsSuccessful = false;
                        result.Account = account;
                        result.Reason = "User Account is Locked.";
                    }
                }
            }

            return result;
        }
      
        #endregion
    }
}

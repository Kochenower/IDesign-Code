using System;
using System.Diagnostics;
using System.ServiceModel;
using UserAccount.Contracts;
using UserAccount.XmlAccountStore;

namespace UserAccount.Accessor
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class UserAccountAccessor : IUserAccountAccessor
    {
        #region Fields

        private const string _FileName = @"C:\temp\UserAccounts.xml";
        private static readonly object _SyncObject = new object();

        /// <summary>
        /// Field for interacting with a file-based User Store.  
        /// The constructor loads the persisted file everytime.
        /// </summary>
        private readonly Lazy<XmlAccountStoreResource> _XmlAccountStore = new Lazy<XmlAccountStoreResource>(() =>
        {
            Debug.Assert(!string.IsNullOrEmpty(_FileName));

            lock (_SyncObject)
            {
                return new XmlAccountStoreResource(_FileName);
            }
        });

        #endregion   

        #region Methods

        public Account[] GetAccounts()
        {
            Debug.Assert(_XmlAccountStore.Value != null && _XmlAccountStore.IsValueCreated);

            lock (_SyncObject)
            {
                return _XmlAccountStore.Value.GetAccounts();
            }
        }

        public Result CreateAccount(Account account)
        {
            Debug.Assert(_XmlAccountStore.Value != null && _XmlAccountStore.IsValueCreated);
            Debug.Assert(account != null);

            lock (_SyncObject)
            {
                return _XmlAccountStore.Value.CreateAccount(account);
            }         
        }

        public Result UpdateAccount(Account account, bool deleteAccount)
        {
            Debug.Assert(_XmlAccountStore.Value != null && _XmlAccountStore.IsValueCreated);
            Debug.Assert(account != null);

            lock (_SyncObject)
            {
                return _XmlAccountStore.Value.UpdateAccount(account, deleteAccount);
            }          
        }

        #endregion
    }
}

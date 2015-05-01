using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using UserAccount.Contracts;

namespace UserAccount.XmlAccountStore
{
    public class XmlAccountStoreResource
    {
        #region Fields

        private readonly string _FileName;
        private readonly XmlSerializer _Serializer;

        #endregion

        #region Constructor

        public XmlAccountStoreResource(string filePath)
        {
            _FileName = filePath;

            _Serializer = new XmlSerializer(typeof(Account[]));

            // If the XML document has been altered with unknown 
            // nodes or attributes, handles them with the 
            // UnknownNode and UnknownAttribute events.
            _Serializer.UnknownNode += serializer_UnknownNode;
            _Serializer.UnknownAttribute += serializer_UnknownAttribute;

            if (!File.Exists(_FileName))
                XmlInitialize(_FileName);
        }

        #endregion

        #region XML Private Methods

        private void XmlInitialize(string fileName)
        {
            var accounts = new[]
            {
                new Account()
                {
                    UserName = "a",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    IsLocked = false,
                    LoginAttempts = 0,
                    Password = new List<string>() {"a"},
                    PasswordLastChangedDate = DateTime.Now,
                    UserSecurityLevel = UserSecurityLevel.Administrator
                }
            };

            using (TextWriter writer = new StreamWriter(fileName))
            {
                _Serializer.Serialize(writer, accounts);
            }
        }

        protected void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        protected void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " +
            attr.Name + "='" + attr.Value + "'");
        }

        #endregion

        #region Methods

        public Account[] GetAccounts()
        {
            Account[] accounts;

            using (FileStream reader = new FileStream(_FileName, FileMode.Open))
            {
                accounts = _Serializer.Deserialize(reader) as Account[];
            }

            return accounts;
        }

        public Result CreateAccount(Account account)
        {
            IList<Account> accounts = GetAccounts().ToList();

            accounts.Add(account);

            using (TextWriter writer = new StreamWriter(_FileName))
            {
                _Serializer.Serialize(writer, accounts.ToArray());
            }

            return new Result()
            {
                Activity = "Create Account",
                Account = account,
                IsSuccessful = true,
            };
        }

        public Result UpdateAccount(Account account, bool deleteAccount)
        {
            IList<Account> accounts = GetAccounts().ToList();
            var result = new Result()
            {
                Activity = deleteAccount ? "Delete Account" : "Update Account"
            };
            if (accounts.Count > 0 && accounts.All(x => x != null))
            {
                Debug.Assert(accounts.Count > 0);
                Debug.Assert(accounts.All(x => x != null));

                if (deleteAccount)
                {
                    accounts.Remove(accounts.FirstOrDefault(x => x.UserName == account.UserName));
                }
                else
                {
                    accounts.Remove(accounts.FirstOrDefault(x => x.UserName == account.UserName));
                    accounts.Add(account);
                    result.Account = account;
                }

                using (TextWriter writer = new StreamWriter(_FileName))
                {
                    _Serializer.Serialize(writer, accounts.ToArray());
                }

                result.IsSuccessful = true;
            }
            else
            {
                result.IsSuccessful = false;
                result.Reason = "Xml did not return any accounts.";
            }

            return result;
        }

        #endregion


    }
}

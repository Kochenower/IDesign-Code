using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.ServiceModel;
using System.Threading;
using UserAccount.Contracts;

namespace UserManagementTestClient
{
    public partial class MainTestView : Form
    {
         #region Fields
        private readonly ChannelFactory<IUserAccountManager> _Factory;
        #endregion

        #region Constructor
        public MainTestView()
        {
            InitializeComponent();
            _Factory = new ChannelFactory<IUserAccountManager>(typeof(IUserAccountManager).Name + "_Endpoint");

            Debug.Assert(_Factory != null);
        }
        #endregion

        #region Private Methods

        private void RefreshAccountListView(IEnumerable<Account> accounts)
        {
            _UsersListView.Items.Clear();

            foreach (var account in accounts)
            {
                var item = _UsersListView.Items.Add(new ListViewItem(new []
                {
                    account.UserName,
                    account.FirstName,
                    account.LastName,
                    account.IsLocked.ToString(),
                    account.LoginAttempts.ToString(),
                    account.PasswordLastChangedDate.ToShortDateString(),
                }));
                item.Tag = account;
            }
        }

        private void RefreshActivityListView(Result result)
        {
                var item = _ActivityListView.Items.Add(new ListViewItem(new []
                {
                    result.IsSuccessful.ToString(),
                    result.Activity,
                    result.Reason
                }));
                item.Tag = result;
        }

        #endregion

        #region Button Methods

        #region Stress Test

        private void btnStressTest_Click(object sender, EventArgs e)
        {
            int iterations = Convert.ToInt32(m_IterationsTextBox.Text);
            int threads = Convert.ToInt32(m_ThreadsTextBox.Text);

            RefreshActivityListView(new Result()
            {
                Activity = "Stress Testing Login",
                Reason = "See Output for result.",
                IsSuccessful = true
            });

            for (int j = 0; j < threads; j++)
            {
                Console.WriteLine("Thread: {0}", j);

                var thread = new Thread(delegate()
                {
                    var proxy = _Factory.CreateChannel();
                                   
                    Stopwatch watch = new Stopwatch();

                    watch.Start();

                    for (var i = 0; i < iterations; i++)
                    {
                        var result = proxy.Login("a", "a");

                        if(!result.IsSuccessful)
                            Console.WriteLine("Thread: {0} Iteration: {1} WasSuccessful: {2}", j, i, result.IsSuccessful);
                    }
                    watch.Stop();

                    (proxy as ICommunicationObject).Close();

                    var transactionsPerSecond = (int)((Convert.ToDecimal(iterations) / Convert.ToDecimal(watch.ElapsedMilliseconds)) * 1000);
                    var transactionDuration = 1.0 / (double)transactionsPerSecond;

                    Trace.WriteLine("Transactions Per Second = " + transactionsPerSecond * threads + "  Transaction Duration = " + transactionDuration, "Stress Test Results");                 
                });
                thread.Start();
            }            
        }

        #endregion

        private void btnGetUsers_Click(object sender, EventArgs e)
        {
            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            try
            {
                RefreshAccountListView(proxy.GetAccounts());
                (proxy as ICommunicationObject).Close();

                RefreshActivityListView(new Result()
                {
                    Activity = "Get Accounts",
                    IsSuccessful = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            try
            {
                var result = proxy.CreateAccount("user"+ new Random().Next(), "12345 Bb", "FirstName1", "LastName1");

                RefreshActivityListView(result);

                RefreshAccountListView(proxy.GetAccounts());
                (proxy as ICommunicationObject).Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            try
            {
                var result = proxy.Login("a", "a");

                RefreshActivityListView(result);

                RefreshAccountListView(proxy.GetAccounts());
                (proxy as ICommunicationObject).Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        private void btnInvalidCredentials_Click(object sender, EventArgs e)
        {
            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            try
            {
                var result = proxy.Login("a", "b");

                RefreshActivityListView(result);

                RefreshAccountListView(proxy.GetAccounts());
                (proxy as ICommunicationObject).Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        private void btnAccountLock_Click(object sender, EventArgs e)
        {
            if (_UsersListView.SelectedItems.Count == 0)
                return;

            var account = _UsersListView.SelectedItems[0].Tag as Account;
            if (account == null)
                return;

            if(account.IsLocked)
                return;

            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            try
            {
                var result = proxy.UpdateAccount(account.UserName, "", account.FirstName, account.LastName, true);

                RefreshActivityListView(result);

                RefreshAccountListView(proxy.GetAccounts());
                (proxy as ICommunicationObject).Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        private void btnAccountUnlock_Click(object sender, EventArgs e)
        {
            if (_UsersListView.SelectedItems.Count == 0)
                return;

            var account = _UsersListView.SelectedItems[0].Tag as Account;
            if (account == null)
                return;

            if (!account.IsLocked) 
                return;

            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            try
            {
                var result = proxy.UpdateAccount(account.UserName, "", account.FirstName, account.LastName, false);

                RefreshActivityListView(result);

                RefreshAccountListView(proxy.GetAccounts());
                (proxy as ICommunicationObject).Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
                InvalidPasswords("123B $b");
                InvalidPasswords("12345 $b");
                InvalidPasswords("12345B $");
                InvalidPasswords("12345Bbcs");
                InvalidPasswords(string.Empty);
                InvalidPasswords(null);
                InvalidPasswords("");
        }

        private void InvalidPasswords(string password)
        {
            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            try
            {
                var result = proxy.UpdateAccount("a", password, "FirstName", "LastName", false);

                if (!string.IsNullOrEmpty(password))
                    result.Reason = "\"" + password + "\" " + result.Reason;

                RefreshActivityListView(result);

                RefreshAccountListView(proxy.GetAccounts());
                (proxy as ICommunicationObject).Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (_UsersListView.SelectedItems.Count == 0)
                return;

            var account = _UsersListView.SelectedItems[0].Tag as Account;
            if (account == null)
                return;

            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            try
            {
                var result = proxy.DeleteAccount(account.UserName);

                RefreshActivityListView(result);

                RefreshAccountListView(proxy.GetAccounts());
                (proxy as ICommunicationObject).Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        #endregion

        #region ToolBar Methods

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UsersListView.Items.Clear(); // show that the ListView was cleared
            _UsersListView.Update();

            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            RefreshAccountListView(proxy.GetAccounts());
            (proxy as ICommunicationObject).Close();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            try
            {
                var result = proxy.Login("a", "a");

                RefreshActivityListView(result);
                RefreshAccountListView(proxy.GetAccounts());
                (proxy as ICommunicationObject).Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            try
            {
                var result = proxy.CreateAccount("user" + new Random().Next(), "12345 Bb", "FirstName1", "LastName1");

                RefreshActivityListView(result);

                RefreshAccountListView(proxy.GetAccounts());
                (proxy as ICommunicationObject).Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_UsersListView.SelectedItems.Count == 0)
                return;

            var account = _UsersListView.SelectedItems[0].Tag as Account;
            if (account == null)
                return;

            var proxy = _Factory.CreateChannel();

            Debug.Assert(proxy != null);

            try
            {
                var result = proxy.DeleteAccount(account.UserName);

                RefreshActivityListView(result);

                RefreshAccountListView(proxy.GetAccounts());
                (proxy as ICommunicationObject).Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}

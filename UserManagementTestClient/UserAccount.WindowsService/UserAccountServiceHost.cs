using System;
using System.ServiceModel;
using ServiceModelEx;
using UserAccount.Manager;

namespace UserAccount.WindowsService
{
    public class UserAccountServiceHost
    {
        #region Fields

        private ServiceHost<UserAccountManager> _Service;

        #endregion

        #region Constructor

        internal UserAccountServiceHost()
        {
            _Service = new ServiceHost<UserAccountManager>(new Uri[] {});
        }

        #endregion

        #region Methods

        /// <summary>
        /// Start the service
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Starting Service...");
            _Service.Open();
        }

        /// <summary>
        /// Stop the service
        /// </summary>
        public void Stop()
        {
            Console.WriteLine("Stopping Service...");
            try
            {
                if (_Service != null)
                    if (_Service.State == CommunicationState.Opened)
                    {
                        _Service.Close();
                        if (_Service.State == CommunicationState.Closed)
                            Console.WriteLine("Service Stopped.");
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine("Service could not stop: {0}" + e.Message);
            }
        }

        #endregion
    }
}

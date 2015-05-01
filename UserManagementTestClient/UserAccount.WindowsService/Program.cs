using System;
using Topshelf;

namespace UserAccount.WindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const string name = "UserAccountManager";
                const string description = "User Account Manager";
                var host = HostFactory.New(configuration =>
                {
                    configuration.Service<UserAccountServiceHost>(callback =>
                    {
                        callback.ConstructUsing(s => new UserAccountServiceHost());
                        callback.WhenStarted(service => service.Start());
                        callback.WhenStopped(service => service.Stop());
                    });
                    configuration.SetDisplayName(name);
                    configuration.SetServiceName(name);
                    configuration.SetDescription(description);
                    configuration.RunAsLocalService();
                });
                host.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("User Account Service fatal exception. " + ex.Message);
            }
        }
    }
}

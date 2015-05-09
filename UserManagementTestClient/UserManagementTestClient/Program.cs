using System;
using System.Threading;
using System.Windows.Forms;

namespace UserManagementTestClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += ApplicationThreadException;

            Application.Run(new MainTestView());
        }

        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Console.WriteLine("Exception: {0}", e.Exception.Message);
        }
    }
}

using CyberCafe.Forms;
using Google.Cloud.Firestore;
using System.Configuration;

namespace CyberCafe
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var isAdminConsole = ConfigurationManager.AppSettings["Admin"];
            if (Convert.ToBoolean(isAdminConsole)) 
            {
                Application.Run(new AdminPanel());
            }
            else
            {
                Application.Run(new ClientApplication());
            }
        }
    }
}
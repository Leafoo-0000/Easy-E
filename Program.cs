using System;
using System.Windows.Forms;

namespace EasyEv3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var db = new DatabaseManager())
            {
                db.ArchiveFinishedEvents();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start with your login screen
            Application.Run(new LoginScreen());
        }

    }
}

using System;
using System.Windows.Forms;
using PharmacySystem.Forms;
using PharmacySystem.Infrastructure;
using PharmacySystem.Logging;

namespace PharmacySystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var logger = new LogService();
            GlobalExceptionHandler.Register(logger);
            logger.LogInfo("SmartMed Pharmacy starting.");

            Application.Run(new LoginForm());
        }
    }
}

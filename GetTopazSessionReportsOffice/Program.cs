using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetTopazSessionReportsOffice
{
    static class Program
    {
        public static Logger logger;

        [STAThread]
        static void Main()
        {
            logger = LogManager.GetCurrentClassLogger();

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                logger.Fatal(e);
            }
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            logger.Fatal(e.ExceptionObject);
        }
    }
}

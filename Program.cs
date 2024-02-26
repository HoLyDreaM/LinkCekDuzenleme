using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FistasCekDuzenleme
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        internal static ApplicationContext ac = new ApplicationContext();
        [STAThread]
        static void Main()
        {
            DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode = DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.v20_1;
            try
            {
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ac.MainForm = new Form1();
                Application.Run(ac);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

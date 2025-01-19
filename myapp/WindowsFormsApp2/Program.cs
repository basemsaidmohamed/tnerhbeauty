using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tnerhbeauty
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //try
            //{
            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WebClient webClient = new WebClient();
            int Version = Convert.ToInt16(Application.ProductVersion.Replace(".", ""));
            int updateVersion = Convert.ToInt16(webClient.DownloadString(new Uri("https://drive.usercontent.google.com/download?id=1rKGYv1gcvKLB9Gk9Aq8SXvkSOpXLIsDZ&export=download&authuser=0&confirm=t&uuid=361008fd-8283-476e-b671-8747545850b3&at=AIrpjvNpKXasdtX4dfTvbzPWko6M:1736552245616")).Replace(".", ""));

            if (updateVersion > Version)
            {
                Application.Run(new app_update());
            }
            else
            Application.Run(new login());
            //}
            //catch (Exception ex) // This is optional if you want to display the exception
            //{
            //    MyMessageBox.showMessage(" خطاء غير متوقع ", "  Sorry, an unExpected error occurred  " + ex.Message, "", MessageBoxButtons.RetryCancel);
            //}
        }
        //static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    MyMessageBox.showMessage(" خطاء غير متوقع ", "  Sorry, an unExpected error occurred  ", "", MessageBoxButtons.RetryCancel);
        //}
    }
}

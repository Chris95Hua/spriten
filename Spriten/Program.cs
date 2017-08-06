using System;
using System.Windows.Forms;

namespace Spriten
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(args.Length > 0)
                Application.Run(new Spriten(args));
            else
                Application.Run(new Spriten());
        }
    }
}

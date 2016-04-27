using System;
using System.Windows.Forms;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Sandboxes.InputForms
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
            Application.Run(new InputForm());
        }
    }
}

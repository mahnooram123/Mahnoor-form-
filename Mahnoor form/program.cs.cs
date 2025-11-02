using System;
using System.Windows.Forms;

namespace WinFormsLoginApp   // <-- Make sure this matches your form's namespace
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Enable Windows visual styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start the app with LoginForm
            Application.Run(new LoginForm());
        }
    }
}

using Booksystem;
using System;
using System.Windows.Forms;

namespace Booksystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LibraryData.InitializeSampleBooks();

            Application.Run(new LoginForm());
        }
    }
}
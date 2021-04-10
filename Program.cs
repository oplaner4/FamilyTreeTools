using System;
using System.Windows.Forms;

namespace FamilyTreeTools
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(args.Length > 0 ? args[0] : null));
        }
    }
}

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace dotNES
{
    static class App
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UI ui = new UI();
            Application.Run(ui);
        }
    }
}

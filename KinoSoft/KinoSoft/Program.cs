using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoSoft.FormsAutorisation;
using KinoSoft.FormsClient;
using KinoSoft.Forms;

namespace KinoSoft
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Autorisation.Autorisation() /*Form1()*/);
            //Application.Run(new EditClient());
            //Application.Run(new Form1());
            //Application.Run(new Employees.AddEmployee());
            //Application.Run(new AddDisk());
        }
    }
}

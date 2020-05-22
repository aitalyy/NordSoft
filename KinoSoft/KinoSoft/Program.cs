using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoSoft.FormsAutorisation;
using KinoSoft.FormsClient;
using KinoSoft.Forms;
using KinoSoft.FormsOrder;
using KinoSoft.FormsDisk;

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
            Application.Run(new Autorisation.Autorisation());
            //Application.Run(new EditClient());
            //Application.Run(new Form1());
            //Application.Run(new Forms.AddMovie(null));
            //Application.Run(new Employees.AddEmployee());
            //Application.Run(new AddDisk());
            //Application.Run(new AddOrder());
            //Application.Run(new AddMovieDisk());
        }
    }
}

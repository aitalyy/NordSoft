using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft.FormsAutorisation
{
    class LogicAutorisation
    {
        

        public static Employee Autorisation(string login, string password)
        {
            Contex My = new Contex();
            try
            {
                Employee employee = My.Employees.Where(s => s.Login == login).FirstOrDefault();
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}

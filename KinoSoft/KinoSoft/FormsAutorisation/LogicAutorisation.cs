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
                int RoleId = employee.RoleId;
                Role role = My.Roles.FirstOrDefault(b => b.Id == RoleId);

                Form1 form1 = new Form1();

                if (employee.Equals(password))
                {
                    form1.Show();
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}

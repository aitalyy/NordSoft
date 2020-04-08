using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft.FormsAutorisation
{
    static class Admin
    {
        public static bool admin;
    }

    class LogicAutorisation
    {
        public string Autorisation(string login, string password)
        {
            Contex My = new Contex();
            try
            {
                Employee employee = My.Employees.Where(s => s.Login == login).FirstOrDefault();

                int RoleId = employee.RoleId;


                Role role = My.Roles.FirstOrDefault(b => b.RoleId == RoleId);
                if (employee.Password.Equals(password))
                {
                    if (role.Name == "Директор")
                        return "admin";
                    return "user";
                }
                else return null;
                
            }
            catch
            {
                return null;
            }
        }
        
    }
}

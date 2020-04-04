using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft.Employees
{
    class LogicEmployees
    {
        Contex My = new Contex();

        public void AddEmployee(string firstname, string lastname, string secondname, string phonenumber, string login, string password, int roleId, int passSer, int passNum)
        {
            MessageBox.Show(Convert.ToString(roleId));
            Passport passport = new Passport
            {
                number = passNum,
                series = passSer
            };

            My.Passports.Add(passport);
            int id = passport.Id;

            My.Employees.Add(new Employee
            {
                FirstName = firstname,
                LastName = lastname,
                SecondName = secondname,
                PhoneNumber = phonenumber,
                Login = login,
                Password = password,
                RoleId = roleId,
                PassportId = id
            });

            My.SaveChanges();
        }

        public void AddRole(string name)
        {
            My.Roles.Add(new KinoSoft.Role
            {
                Name = name,
            });
            My.SaveChanges();
        }
        public void RemoveRole(int Roleid)
        {
            //My.Roles.Remove(My.Roles.Where(k => k.RoleId == Roleid).FirstOrDefault());
            //My.SaveChanges();
        }

        public void getDataEmployee(DataGridView asd)
        {
            var result = from a in My.Employees
                         join b in My.Passports on a.PassportId equals b.Id
                         join c in My.Roles on a.RoleId equals c.RoleId
                         select new
                         {

                         };
        }
    }
}

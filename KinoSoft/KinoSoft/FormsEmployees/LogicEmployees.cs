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
                             id = a.Id,
                             login = a.Login,
                             Password = a.Password,
                             Имя = a.FirstName,
                             Фамилия = a.LastName,
                             Отчество = a.SecondName,
                             Id_role = a.RoleId,
                             Должность = c.Name,
                             id_passport = b.Id,
                             Номер_телефона = a.PhoneNumber,
                             Номер_паспорта = b.number,
                             Серия_паспорта = b.series
                         };
            asd.DataSource = result.ToList();
        }

        public void RemoveEmployee(int idEmp, int idPass)
        {
            Employee emp = My.Employees.Where(k => k.Id == idEmp).FirstOrDefault();
            Passport pass = My.Passports.Where(s => s.Id == idPass).FirstOrDefault();
            My.Employees.Remove(emp);
            My.Passports.Remove(pass);
            My.SaveChanges();
        }
    }
}

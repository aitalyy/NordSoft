using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft.Employees
{
    static class EditEmployee
    {
        public static bool editEmployee;
        public static int idEmployee;
    }

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
            Employee employee = My.Employees.Where(k => k.Login == login).FirstOrDefault();
            Employee check = CheckedEmployee(employee, firstname, lastname, secondname, phonenumber, login, password, roleId, passNum, passSer);
            if (check != null)
                MessageBox.Show("Пользователь успешно зарегистрирован");
            else
            {
                try
                {
                    Passport pass = My.Passports.Where(k => k.Id == employee.PassportId).FirstOrDefault();
                    RemoveEmployee(employee.Id, pass.Id);
                }
                catch
                {
                    
                }
                MessageBox.Show("Повторите попытку");
            }
        }

        public void AddRole(string name)
        {
            My.Roles.Add(new KinoSoft.Role
            {
                Name = name,
            });
            My.SaveChanges();
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

        public static Employee CheckedEmployee(Employee emp, string firstname, string lastname, string secondname, string phonenumber, string login, string password, int roleId, int passSer, int passNum)
        {
            Contex My = new Contex();
            try
            {
                Passport pass = My.Passports.Where(k => k.Id == emp.PassportId).FirstOrDefault();
                if (emp.FirstName.Equals(firstname))
                    if (emp.LastName.Equals(lastname))
                        if (emp.SecondName.Equals(secondname))
                            if (emp.PhoneNumber.Equals(phonenumber))
                                if (emp.Login.Equals(login))
                                    if (emp.Password.Equals(password))
                                        if (emp.RoleId.Equals(roleId))
                                            if (pass.number.Equals(passNum))
                                                if (pass.series.Equals(passSer))
                                                    return emp;
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}

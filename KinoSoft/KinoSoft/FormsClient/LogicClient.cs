using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KinoSoft.FormsClient
{
    class LogicClient
    {
        Contex My = new Contex();
        public void AddClient(string firstname, string lastname, string secondname, int numbPassp, int serPassp, string phonenumber)
        {
            Passport passport = new Passport
            {
                number = numbPassp,
                series = serPassp
            };

            My.Passports.Add(passport);
            My.SaveChanges();

            int id = passport.Id;

            Client client = new Client
            {
                
                InBalckList = false,
                PassportId = id,
                PhoneNumber = phonenumber,
                SecondName = secondname,
                LastName = lastname,
                FirstName = firstname

            };

            My.SaveChanges();
            My.Clients.Add(client);
            

            int idCl = client.Id;
            Client checkRe = My.Clients.Where(k => k.PassportId == id).FirstOrDefault();
            Client check = CheckedClient(checkRe, firstname, lastname, secondname, phonenumber);
            if (check != null)
                MessageBox.Show("Пользователь успешно зарегистрирован");
            else
            {
                try
                {
                    Passport pass = My.Passports.Where(k => k.Id == checkRe.PassportId).FirstOrDefault();
                    RemoveClient(checkRe.Id, pass.Id);
                }
                catch
                {

                }
                MessageBox.Show("Повторите попытку");
            }
        }

        public static Client CheckedClient(Client client, string firstname, string lastname, string secondname, string phonenumber)
        {
            Contex My = new Contex();
            try
            {
                if (client.FirstName.Equals(firstname))
                    if (client.LastName.Equals(lastname))
                        if (client.SecondName.Equals(secondname))
                            if (client.PhoneNumber.Equals(phonenumber))
                                return client;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public void RemoveClient(int idClient, int idPass)
        {
            Client client = My.Clients.Where(k => k.Id == idClient).FirstOrDefault();
            Passport passport = My.Passports.Where(k => k.Id == idPass).FirstOrDefault();
            My.Passports.Remove(passport);
            My.Clients.Remove(client);
            My.SaveChanges();
        }

        public void getDataClient(DataGridView asd)
        {
            var result = from a in My.Clients
                         join b in My.Passports on a.PassportId equals b.Id
                         select new
                         {
                             id = a.Id,
                             Имя = a.FirstName,
                             Фамилия = a.LastName,
                             Отчество = a.SecondName,
                             Номер_телефона = a.PhoneNumber,
                             Заказ = a.Orders,
                             Черный_лист = a.InBalckList,
                             Номер_паспорта = b.number,
                             Серия_паспорта = b.series,
                             PassportId = a.PassportId
                         };
            asd.DataSource = result.ToList();
        }

        public void getDataClientSearch(DataGridView asd, string name)
        {
            Client client = My.Clients.Where(s => s.FirstName == name).FirstOrDefault();

            int? idPass = client.PassportId;

            var result = from a in My.Clients.Where(s => s.FirstName == name)
                         join b in My.Passports.Where(k => k.Id == idPass) on a.PassportId equals b.Id
                         select new
                         {
                             id = a.Id,
                             Имя = a.FirstName,
                             Фамилия = a.LastName,
                             Отчество = a.SecondName,
                             Номер_телефона = a.PhoneNumber,
                             Заказ = a.Orders,
                             Черный_лист = a.InBalckList,
                             Номер_паспорта = b.number,
                             Серия_паспорта = b.series,
                             PassportId = a.PassportId
                         };
            asd.DataSource = result.ToList();
        }
    }
}
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
            
            My.Clients.Add(client);
            My.SaveChanges();

            int idCl = client.Id;
            Client check = CheckedClient(idCl, firstname, lastname, secondname, phonenumber);
            if (check != null)
                MessageBox.Show("Пользователь успешно зарегистрирован");
            else
                MessageBox.Show("Повторите попытку");

        }

        public static Client CheckedClient(int id, string firstname, string lastname, string secondname, string phonenumber)
        {
            Contex My = new Contex();
            try
            {
                Client client = My.Clients.Where(a => a.Id == id).FirstOrDefault();
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
    }
}
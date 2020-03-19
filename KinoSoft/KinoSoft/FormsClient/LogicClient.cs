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
            Client client = new Client
            {
                InBalckList = false,
                PhoneNumber = phonenumber
            };

            Person person = new Person
            {
                FirstName = firstname,
                LastName = lastname,
                SecondName = secondname
            };

            Passport passport = new Passport
            {
                number = numbPassp,
                series = serPassp
            };

            My.Clients.Add(client);
            My.Persons.Add(person);
            My.Passports.Add(passport);
            My.SaveChanges();
        }
    }
}
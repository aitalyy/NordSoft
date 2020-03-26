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
                PhoneNumber = phonenumber,
                FirstName = firstname,
                LastName = lastname,
                SecondName = secondname,
                PassportId = id
            };
            
            My.Clients.Add(client);
            My.SaveChanges();

        }

        public void EditClient()
        {

        }
    }
}
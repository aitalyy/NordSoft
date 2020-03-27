using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft.FormsClient
{
    public partial class AddClient : Form
    {
        Contex My = new Contex();
        private Client client = null;
        public AddClient(Client client)
        {
            InitializeComponent();
            if (client == null)
            {
                button3.Visible = false;
                return;
            }
            else
            {
                button1.Visible = false;
                FillFields(client);
                this.client = My.Clients.Find(client.Id);
            }
        }
        private void FillFields(Client client)
        {
            maskedTextBox1.Text = client.PhoneNumber;
            textBox1.Text = client.FirstName;
            textBox2.Text = client.SecondName;
            textBox4.Text = client.LastName;
            //textBox6.Text = client.Passport.series.ToString();
            //textBox5.Text = client.Passport.number.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                   "Если вы закроете, то введённые данные будут сброшены. Вы уверены в этом?",
                   "Сообщение",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.ServiceNotification);
            if (result == DialogResult.Yes) Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogicClient logicClient = new LogicClient();
            

            string FirstName = textBox1.Text;
            string LastName = textBox2.Text;
            string SecondName = textBox4.Text;
            int NumberPassport = Convert.ToInt32(textBox5.Text);
            int seriesPassport = Convert.ToInt16(textBox6.Text);
            string PhoneNumber = maskedTextBox1.Text;

            logicClient.AddClient(FirstName, LastName, SecondName, NumberPassport, seriesPassport, PhoneNumber);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.PhoneNumber = maskedTextBox1.Text;
            client.FirstName = textBox1.Text;
            client.LastName = textBox4.Text;
            client.SecondName = textBox2.Text;

            int? idPass = client.PassportId;
            Passport passport = My.Passports.Where(k => k.Id == idPass).FirstOrDefault();
            //passport.number = Convert.ToInt32(textBox5.Text);
            //passport.series = Convert.ToInt16(textBox6.Text);

            My.SaveChanges();
            this.Close();
        }
    }
}

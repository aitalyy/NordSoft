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
        public AddClient()
        {
            InitializeComponent();
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
    }
}

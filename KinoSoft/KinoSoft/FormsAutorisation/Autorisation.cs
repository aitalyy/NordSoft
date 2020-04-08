using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoSoft.FormsAutorisation;

namespace KinoSoft.Autorisation
{
    public partial class Autorisation : Form
    {
        LogicAutorisation logicAut = new LogicAutorisation();

        public Autorisation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            //Employee m = LogicAutorisation.Autorisation(login, password);
            LogicAutorisation logAu = new LogicAutorisation();
            string m = logAu.Autorisation(login, password);
            if (m == null) MessageBox.Show("Неправильно ввели логин или пароль");
            else
            {
                Form1 form1 = new Form1();
                if (m == "admin")
                {
                    Admin.admin = true;
                    this.Hide();
                    form1.Show();
                }
                if (m == "user")
                {
                    Admin.admin = false;
                    this.Hide();
                    form1.Show();
                }
                
            }
            
        }
    }
}

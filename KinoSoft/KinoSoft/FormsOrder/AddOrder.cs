using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft.FormsOrder
{
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormsClient.AddClient addClient = new FormsClient.AddClient();
            addClient.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormsClient.EditClient editClient = new FormsClient.EditClient();
            editClient.Show();
        }
    }
}

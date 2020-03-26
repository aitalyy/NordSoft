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
    public partial class EditClient : Form
    {
        Contex My = new Contex();

        public EditClient()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string name = searchBox.Text;
            MessageBox.Show(name);
            dataGridView1.DataSource = My.Clients.Where(s => s.FirstName == name).FirstOrDefault();

        }

        private void EditClient_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = My.Clients.ToList<Client>();
            dataGridView1.DataSource = My.Persons.ToList<Person>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = My.Clients.ToList<Client>();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

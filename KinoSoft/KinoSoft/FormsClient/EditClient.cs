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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idClient = Convert.ToInt32(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value);
            int idPass = Convert.ToInt32(dataGridView1[7, dataGridView1.CurrentCell.RowIndex].Value);

            LogicClient LogClRem = new LogicClient();
            LogClRem.RemoveClient(idClient, idPass);
        }

        private void selectionButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = My.Clients.ToList<Client>();
        }
    }
}

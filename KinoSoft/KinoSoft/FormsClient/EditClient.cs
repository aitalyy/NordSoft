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
        LogicClient LogCl = new LogicClient();

        public EditClient()
        {
            InitializeComponent();
            LogCl.getDataClient(dataGridView1);
        }

        private void back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string name = searchBox.Text;
            LogCl.getDataClientSearch(dataGridView1, name);

        }

        private void EditClient_Load(object sender, EventArgs e)
        {
            LogCl.getDataClient(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idClient = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
            int idPass = Convert.ToInt32(dataGridView1[9, dataGridView1.CurrentCell.RowIndex].Value);
            LogCl.RemoveClient(idClient, idPass);
            button1_Click(sender, e);
        }

        private void selectionButton_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value);
            FirstNameBox.Text = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value);
            LastNameBox.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
            SecondNameBox.Text = Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value);
            PassNumBox.Text = Convert.ToString(dataGridView1[7, dataGridView1.CurrentCell.RowIndex].Value);
            PassSerBox.Text = Convert.ToString(dataGridView1[8, dataGridView1.CurrentCell.RowIndex].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogCl.getDataClient(dataGridView1);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            int idClient = Convert.ToInt16(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);

            Client client = My.Clients.Where(k => k.Id == idClient).FirstOrDefault();

            client.PhoneNumber = maskedTextBox1.Text;
            client.FirstName = FirstNameBox.Text;
            client.LastName = LastNameBox.Text;
            client.SecondName = SecondNameBox.Text;

            int? idPass = client.PassportId;
            Passport passport = My.Passports.Where(k => k.Id == idPass).FirstOrDefault();
            passport.number = Convert.ToInt32(PassNumBox.Text);
            passport.series = Convert.ToInt16(PassSerBox.Text);

            My.SaveChanges();

            maskedTextBox1.Text = null;
            FirstNameBox.Text = null;
            LastNameBox.Text = null;
            SecondNameBox.Text = null;
            PassNumBox.Text = null;
            PassSerBox.Text = null;
            
            button1_Click(sender, e);
        }
    }
}

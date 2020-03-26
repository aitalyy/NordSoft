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
        }

        private void back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string name = searchBox.Text;
            Client client = My.Clients.Where(s => s.FirstName == name).FirstOrDefault();

            int? idPass = client.PassportId;

            var result = from a in My.Clients.Where(s => s.FirstName == name)
                         from b in My.Passports.Where(k => k.Id == idPass)
                         select new
                         {
                             id = a.Id,
                             Имя = a.FirstName,
                             Фамилия = a.LastName,
                             Отчество = a.SecondName,
                             Номер_телефона = a.PhoneNumber,
                             Заказ = a.Orders,
                             Черный_лист = a.InBalckList,
                             Номер_паспорта = b.number,
                             Серия_паспорта = b.series,
                             PassportId = a.PassportId
                         };
            dataGridView1.DataSource = result.ToList();

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
            PhoneNumBox.Text = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value);
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

            client.PhoneNumber = PhoneNumBox.Text;
            client.FirstName = FirstNameBox.Text;
            client.LastName = LastNameBox.Text;
            client.SecondName = SecondNameBox.Text;

            int? idPass = client.PassportId;
            Passport passport = My.Passports.Where(k => k.Id == idPass).FirstOrDefault();
            passport.number = Convert.ToInt32(PassNumBox.Text);
            passport.series = Convert.ToInt16(PassSerBox.Text);

            My.SaveChanges();

            PhoneNumBox.Text = null;
            FirstNameBox.Text = null;
            LastNameBox.Text = null;
            SecondNameBox.Text = null;
            PassNumBox.Text = null;
            PassSerBox.Text = null;
            
            button1_Click(sender, e);
        }
    }
}

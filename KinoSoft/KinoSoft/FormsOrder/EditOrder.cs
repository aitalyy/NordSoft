using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Collections.ObjectModel;

namespace KinoSoft.FormsOrder
{
    public partial class EditOrder : Form
    {
        Contex My = new Contex();
        private int costDiskAll = 0;
        private ArrayList arrayDisk = new ArrayList();
        private int idOrder;
        private int idClient;
        private int idRows;

        private enum TablesOrder
        {
            Client,
            Disk
        }

        TablesOrder table;

        public EditOrder()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            monthCalendar1.Show();
            //Data.Text = monthCalendar1.SelectionStart.ToShortDateString().ToString();
            monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);

            //monthCalendar1.Hide();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Data.Text = e.Start.ToShortDateString();
            monthCalendar1.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {
            monthCalendar2.Show();
            monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
        }
        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            Data2.Text = e.Start.ToShortDateString();
            monthCalendar2.Hide();
        }

        private void buttonListDisk_Click(object sender, EventArgs e)
        {
            ListDisk();
        }

        private void ListDisk()
        {
            dataGridView1.DataSource = My.Disks.ToList<Disk>();
            textDatagrid.Text = "Список дисков";
            buttonDisk.Visible = true;
            RemDiskBut.Visible = true;
            table = TablesOrder.Disk;
        }

        private void button5_Click(object sender, EventArgs e)
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoSoft.FormsClient;

namespace KinoSoft
{
    public enum Tables
    {
        Order = 1,
        Client,
        Movie,
        Disk
    }

    public partial class Form1 : Form
    {
        Tables table = Tables.Order;
        Contex My = new Contex();

        public Form1()
        {
            InitializeComponent();
            UpdateTable();
        }

        public void UpdateTable()
        {
            switch (table)
            {
                case Tables.Client:
                    dataAll.DataSource = My.Clients.ToList<Client>();
                    break;
                case Tables.Disk:
                    dataAll.DataSource = My.Disks.ToList<Disk>();
                    break;
                case Tables.Movie:
                    dataAll.DataSource = My.Movies.ToList<Movie>();
                    break;
                case Tables.Order:
                    dataAll.DataSource = My.Orders.ToList<Order>();
                    break;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (table)
            {
                case Tables.Movie:
                    Forms.AddMovie addMovie = new Forms.AddMovie(null);
                    addMovie.Show();
                break;
                case Tables.Disk:
                    Forms.AddDisk addDisk = new Forms.AddDisk();
                    addDisk.Show();
                break;
                case Tables.Client:
                    FormsClient.AddClient addClient = new FormsClient.AddClient();
                    addClient.Show();
                break;
                default:
                    DialogResult result = MessageBox.Show(
                    "В процессе разработки!",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
                    break;
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataAll.SelectedRows.Count == 0)
                return;

            switch (table)
            {
                case Tables.Movie:
                    Movie movie = dataAll.SelectedRows[0].DataBoundItem as Movie; // вытаскиваем фильм из таблицы
                    if (movie == null)
                        return;

                    Forms.AddMovie editMovie = new Forms.AddMovie(movie);
                    editMovie.Show();
                    break;
                case Tables.Client:
                    FormsClient.EditClient editClient = new FormsClient.EditClient();
                    editClient.Show();
                    break;
                default:
                    DialogResult result = MessageBox.Show(
                    "В процессе разработки!",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataAll.SelectedRows.Count == 0)
                return;

            DialogResult result = MessageBox.Show(
                    "Вы уверены в этом?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);

            switch (table)
            {
                case Tables.Movie:
                    if (result == DialogResult.Yes)
                    {
                        foreach(DataGridViewRow row in dataAll.SelectedRows)
                        {
                            Movie movie = row.DataBoundItem as Movie;
                            if (movie == null)
                                continue;
                            Movie dbMovie = My.Movies.Find(movie.Id);
                            My.Movies.Remove(dbMovie);
                        }
                        My.SaveChanges();
                        UpdateTable();
                    }
                break;
                case Tables.Client:
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataAll.SelectedRows)
                        {
                            Client client = row.DataBoundItem as Client;
                            if (client == null)
                                continue;
                            Client dbClient = My.Clients.Find(client.Id);
                            My.Clients.Remove(dbClient);
                        }
                        My.SaveChanges();
                        UpdateTable();
                    }
                break;
                case Tables.Disk:
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataAll.SelectedRows)
                        {
                            Disk disk = row.DataBoundItem as Disk;
                            if (disk == null)
                                continue;
                            Disk dbDisk = My.Disks.Find(disk.Id);
                            My.Disks.Remove(dbDisk);
                        }
                        My.SaveChanges();
                        UpdateTable();
                    }
                break;
                default:
                break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forms.AddDisk addDisk = new Forms.AddDisk();
            addDisk.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            table = Tables.Client;
            UpdateTable();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            table = Tables.Order;
            UpdateTable();
        }
        private void dataClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            table = Tables.Disk;
            UpdateTable();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            table = Tables.Movie;
            UpdateTable();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataAll.DataSource = My.Employees.ToList<Employee>();
            //Employee employee = new Employee
            //{
            //    Login = "asd",
            //    Password = "123",
            //    RoleId = 1,
            //};

            //Role role = new Role
            //{
            //    Name = "Директор"
            //};
            //My.Employees.Add(employee);
            ////My.Roles.Add(role);
            //My.SaveChanges();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
        }
    }
}

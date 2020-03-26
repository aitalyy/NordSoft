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
    public partial class Form1 : Form
    {
        public enum Tables
        {
            Order = 1,
            Client,
            Movie,
            Disk
        }

        Tables table = Tables.Disk;
        //1)-Список заказов 2)-Список клиентов 3)-Список фильмов 4)-Список дисков
        Contex My = new Contex();
        public Form1()
        {
            InitializeComponent();
            dataAll.DataSource = My.Orders.ToList<Order>();
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
            DialogResult result = MessageBox.Show(
                   "В процессе разработки!",
                   "Сообщение",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.ServiceNotification);
            /*   try
               {

                   System.IO.File.Delete(listBox1.SelectedIndex.ToString());
                   listBox1.Items.RemoveAt(listBox1.SelectedIndex);
               }
               catch (Exception err)
               {

               }
               */
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
            dataAll.DataSource = My.Clients.ToList<Client>();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            table = Tables.Order;
            dataAll.DataSource = My.Orders.ToList<Order>();
        }
        private void dataClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            table = Tables.Disk;
            dataAll.DataSource = My.Disks.ToList<Disk>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            table = Tables.Movie;
            dataAll.DataSource = My.Movies.ToList<Movie>();
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
    }
}

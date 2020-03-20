using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft
{
    public partial class Form1 : Form
    {
        int Num=1;
        //1)-Список заказов 2)-Список клиентов 3)-Список фильмов 4)-Список дисков
        Contex My = new Contex();
        public Form1()
        {
            InitializeComponent();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(Num)
            {
                case 3:
                    Forms.AddMovie addMovie = new Forms.AddMovie();
                    addMovie.Show();
                break;
                case 4:
                    Forms.AddDisk addDisk = new Forms.AddDisk();
                    addDisk.Show();
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
            Num = 2;
            dataAll.DataSource = My.Clients.ToList<Client>();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Num = 1;
            dataAll.DataSource = My.Orders.ToList<Order>();
        }
        private void dataClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Num = 4;
            dataAll.DataSource = My.Disks.ToList<Disk>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Num = 3;
            dataAll.DataSource = My.Movies.ToList<Movie>();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            switch (Num)
            {
                case 3:
                    if (dataAll.SelectedRows.Count == 0)
                        return;
                    Forms.EditMovie editMovie = new Forms.EditMovie(dataAll.SelectedRows[0]);
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
    }
}

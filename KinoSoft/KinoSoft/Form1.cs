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
            dataOrder.Visible = false;
            dataClient.Visible = true;
            dataDisk.Visible = false;
            dataMovie.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Num = 1;
            dataDisk.Visible = false;
            dataOrder.Visible = true;
            dataClient.Visible = false;
            dataMovie.Visible = false;
        }
        private void dataClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Num = 4;
            dataOrder.Visible = false;
            dataClient.Visible = false;
            dataDisk.Visible = true;
            dataMovie.Visible = false;
            //dataDisk.DataSource = My.Disks.ToList<Disk>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Num = 3;
            dataOrder.Visible = false;
            dataClient.Visible = false;
            dataDisk.Visible = false;
            dataMovie.Visible = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}

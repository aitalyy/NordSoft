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
            Forms.AddMovie addMovie = new Forms.AddMovie();
            addMovie.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
            dataOrder.Visible = false;
            dataClient.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataOrder.Visible = true;
            dataClient.Visible = false;
        }
    }
}

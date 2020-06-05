using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoSoft.FormsSearch;
using KinoSoft.FormsDisk;

namespace KinoSoft.Forms
{
    public partial class AddDisk : Form
    {
        LogicDisk LD = new LogicDisk();

        public AddDisk()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string format = comboBox1.Text;
            int copy = Convert.ToInt32(textBox2.Text);
            int cost = Convert.ToInt32(textBox3.Text);
            
            LD.AddDisk(name, format, copy, cost);
            MessageBox.Show("Диск успешно добавлен!");
            Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddDisk_Load(object sender, EventArgs e)
        {
            button3_Click(sender, e);
            if (EditMovieDisk.check == true)
            {
                Disk disk = EditMovieDisk.disk;
                textBox1.Text = disk.Name;
                comboBox1.Text = disk.format;
                textBox2.Text = Convert.ToString(disk.copy);
                textBox3.Text = Convert.ToString(disk.cost);
                dataGridView1.DataSource = disk.Movies.ToList();
                for(int i=0; i< dataGridView1.ColumnCount; i++)
                {
                    ArrayMoviesDisk.arrayList.Add(dataGridView1[0, i].Value);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ArrayMoviesDisk.movies != null)
                dataGridView1.DataSource = ArrayMoviesDisk.movies;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddMovieDisk addMovieDisk = new AddMovieDisk();
            addMovieDisk.Show();
            button3_Click(sender, e);
        }

        private void AddDisk_Activated(object sender, EventArgs e)
        {
            AddMovieDisk addMovieDisk = new AddMovieDisk();
            if (addMovieDisk.Visible == false)
                button3_Click(sender, e);
        }
    }
}

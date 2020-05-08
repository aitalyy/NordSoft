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
            LogicDisk LD = new LogicDisk();
            LD.AddDisk(name, format, copy, cost);
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ArrayMoviesDisk.movies != null)
                dataGridView1.DataSource = ArrayMoviesDisk.movies;
            //Contex my = new Contex();
            //dataGridView1.DataSource = my.MovieDisks.ToList<MovieDisk>();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Disk disk = My.Disks.Where(k => k.Name == textBox1.Text).FirstOrDefault();
            //Id_all.id_all = disk.Id;
            //table = Tables.Movie;
            //SearchForm formP = new SearchForm(table);
            //formP.Show();

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

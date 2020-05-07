using iTextSharp.text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoSoft.FormsDisk;

namespace KinoSoft.FormsDisk
{
    
    public partial class AddMovieDisk : Form
    {
        Contex My = new Contex();
        ArrayList list = new ArrayList();
        List<Movie> listmovie = new List<Movie>();

        public AddMovieDisk()
        {
            InitializeComponent();
        }

        private void AddMovieDisk_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = My.Movies.ToList<Movie>();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            int idMov = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
            if (checkAdd(idMov) == false)
            {
                list.Add(idMov);
                listmovie.Add(My.Movies.Where(k => k.Id == idMov).FirstOrDefault());
            }
            update();
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            ArrayMoviesDisk.arrayList = list;
            ArrayMoviesDisk.movies = listmovie;
            Forms.AddDisk addDisk = new Forms.AddDisk();
            Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            update();
        }

        private void update()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listmovie;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
                return;
            int idMov = Convert.ToInt32(dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value);
            for (int i = 0; i < listmovie.Count; i++)
                if (Convert.ToInt32(list[i]) == idMov)
                {
                    list.RemoveAt(i);
                    listmovie.RemoveAt(i);
                }
            update();
        }
        
        private bool checkAdd(int id)
        {
            for(int i=0; i<list.Count; i++)
            {
                if (Convert.ToInt32(list[i]) == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

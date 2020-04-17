using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft.Forms
{
    public partial class AddMovie : Form
    {
        private Contex db = new Contex();
        private Movie movie = null;

        public AddMovie(Movie movie)
        {
            InitializeComponent();
            if (movie == null)
            {
                button4.Visible = false;
                return;
            }

            button2.Visible = false;
            FillFields(movie);
            this.movie = db.Movies.Find(movie.Id);

            
        }

        private void FillFields(Movie movie)
        {
            MovieName.Text = movie.Name;
            // ...
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        // Добавление
        private void button2_Click(object sender, EventArgs e) 
        {
            //string genre = "";
            //string name = MovieName.Text;
            //DateTime god = Convert.ToDateTime(Data.Text);
            //string category = Category.Text;
            //string country = Country.Text;
            //string producer = Producer.Text;
            //string actor = Actors.Text;
            //foreach (var item in Genre.CheckedItems)
            //{
            //   genre += item.ToString() + ";";
            //}
            //LogicMovie LM = new LogicMovie();
            //LM.AddMovie(name, god, category, country, producer, actor, genre);

            using (Contex db = new Contex())
            {
                Movie movie = new Movie();
                //movie.Date = Convert.ToDateTime(Data.Text);
                foreach (var item in Genre.CheckedItems)
                {
                //   movie.Genres = item.ToString();
                }
                movie.Name = MovieName.Text;
                //movie.Category = Category.Text;
                //movie.Contries = Country.Text;
            }
            this.Close();
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

        //Редактирование
        private void button4_Click(object sender, EventArgs e) 
        {
            movie.Name = MovieName.Text;
            // ...

            db.SaveChanges();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Forms.AddGenre asd = new Forms.AddGenre();
            asd.ShowDialog();
        }

        private void AddMovie_Load(object sender, EventArgs e)
        {
            //var genres = db.Genres.ToList();
            //foreach (var item in genres)
            //{
            //    Genre.Items.Add(item.Name.ToString());
            //}
        }

        private void AddMovie_Activated(object sender, EventArgs e)
        {
            Genre.Items.Clear();
            var genres = db.Genres.ToList();
            foreach (var item in genres)
            {
                Genre.Items.Add(item.Name.ToString());
            }
        }
    }
}
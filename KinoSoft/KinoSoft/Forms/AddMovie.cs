using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Contex My = new Contex();
        private Movie movie = null;

        public AddMovie(Movie movie)
        {
            InitializeComponent();
            LogicMovie.ProducerAdd.FIO = null;
            if (movie == null)
            {
                button4.Visible = false;
                return;
            }

            button2.Visible = false;
            FillFields(movie);
            this.movie = My.Movies.Find(movie.Id);

            
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
            var genre = new Collection<MovieGenre>();
            foreach (var item in Genre.CheckedItems)
            {
                string Genres = item.ToString();
                MovieGenre genre1 = My.MovieGenre.Where(k => k.Genre.Name == Genres).FirstOrDefault();
                genre.Add(genre1);
            }
            string name = MovieName.Text;
            DateTime god = Convert.ToDateTime(Data.Text);
            string category = Category.Text;
            MovieCategory MCat = My.MovieCategory.Where(k => k.Category == category).FirstOrDefault();
            //var country = new Collection<KinoSoft.MovieCountry>();
            //string[] mystring = Country.Text.Split(',');
            //for (int i = 0; i<mystring.Length;i++)
            //{
            //    MovieCountry country1 = KinoSoft.Country;
            //    country.Add(country1);
            //}
            //var producers = new Collection<MovieProducer>();
            //string[] mystring = Country.Text.Split(',');
            //for (int i = 0; i < mystring.Length; i++)
            //{
            //    My.Producers.Add(new Producer { SecondName = mystring[i], FirstName = mystring[i+1], LastName = mystring});
            //    producers.Add(prod);
            //}
            //string actor = Actors.Text;
            //foreach (var item in Genre.CheckedItems)
            //{
            //   genre += item.ToString() + ";";
            //}
            LogicMovie LM = new LogicMovie();
            LM.AddMovie(name, god, /*MCat /*country, producer, /*actor*/ genre);

            //using (Contex My = new Contex())
            //{
            //    var movie = new Movie();
            //    Name = MovieName.Text;
            //    //Date = Convert.ToDateTime(Data.Text);
            //    var genre = new Collection<MovieGenre>();
            //    foreach (var item in Genre.CheckedItems)
            //    {
            //        string Genres = item.ToString();
            //        MovieGenre genre1 = My.MovieGenre.Where(k => k.Genre.Name == Genres).FirstOrDefault();
            //        movie.Genres.Add(genre1);
            //    }
            //    //movie.Category = Category.Text;
            //    //movie.Contries = Country.Text;
            //    My.SaveChanges();
            //}
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

            My.SaveChanges();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Forms.AddGenre asd = new Forms.AddGenre();
            asd.ShowDialog();
        }

        private void AddMovie_Load(object sender, EventArgs e)
        {
        }

        private void AddMovie_Activated(object sender, EventArgs e)
        {
            Genre.Items.Clear();
            Category.Items.Clear();
            var genres = My.Genres.ToList();
            foreach (var item in genres)
            {
                Genre.Items.Add(item.Name.ToString());
            }   
            var category = My.MovieCategory.ToList();
            foreach (var item in category)
            {
                Category.Items.Add(item.Category.ToString());
            }
            Producer.Text += LogicMovie.ProducerAdd.FIO;
            LogicMovie.ProducerAdd.FIO = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Forms.AddCategory asd = new Forms.AddCategory();
            asd.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Forms.AddProducer asd = new Forms.AddProducer();
            asd.Show();
        }
    }
}
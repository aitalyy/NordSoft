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
        //--------------------------------------------------------------------------------------------- Инициализация
        public AddMovie(Movie movie)
        {
            InitializeComponent();
            if (movie == null)
            {
                button4.Visible = false;
                return;
            }
            else
            {
                button2.Visible = false;
                this.movie = My.Movies.Find(movie.Id);
                FillFields();
            }
        }
        //--------------------------------------------------------------------------------------------- Заполнение полей данными редактируемого фильма
        private void FillFields()
        {
            List<Genre> listgenre = new List<Genre>();

            MovieName.Text = movie.Name;

            foreach (MovieGenre c in movie.Genres)
            {
                textBox1.Text += c.Genre.Name + "; ";
            }

            Data.Text = movie.Date.Day.ToString() + "." + movie.Date.Month.ToString() + "." + movie.Date.Year.ToString();

            Category.Text = movie.Category;

            foreach (MovieCountry country in movie.Contries)
            {
                Country.Text += country.Country.CountryName + "; ";
            }

            foreach (MovieActor actor in movie.Actors)
            {
                Actors.Text += actor.Actor.SecondName + " " + actor.Actor.FirstName + " " + actor.Actor.LastName + "; ";
            }

            foreach (MovieProducer producer in movie.Producers)
            {
                Producer.Text += producer.Producer.SecondName + " " + producer.Producer.FirstName + " " + producer.Producer.LastName + "; ";
            }

            Opisanie.Text = movie.Description;
            
        }
        //--------------------------------------------------------------------------------------------- /Добавление фильма
        private void button2_Click(object sender, EventArgs e) 
        {
            //--------------------------------------------------------------------------------------------- //Жанр фильма
            var genre = new Collection<KinoSoft.MovieGenre>();
            if (GenreAdd.id != null)
                foreach (Genre c in GenreAdd.id)
                {
                    int genId = c.Id;
                    MovieGenre MGen = My.MovieGenre.Where(k => k.Id == genId).FirstOrDefault();
                    genre.Add(MGen);
                }
            //--------------------------------------------------------------------------------------------- //Название фильма
            string name = MovieName.Text;
            //--------------------------------------------------------------------------------------------- //Дата выпуска фильма
            DateTime god = Convert.ToDateTime(Data.Text);
            //--------------------------------------------------------------------------------------------- //Категория фильма
            string category = Category.Text;
            //--------------------------------------------------------------------------------------------- //Режиссёр(-ы) фильма
            var producers = new Collection<KinoSoft.MovieProducer>();
            if (ProducerAdd.id != null)
                foreach (Producer c in ProducerAdd.id)
                {
                    int proId = c.Id ;
                    MovieProducer MPro = My.MoviMovieProducere.Where(k => k.Id == proId).FirstOrDefault();
                    producers.Add(MPro);
                }
            //--------------------------------------------------------------------------------------------- //Актёр(-ы) фильма
            var actors = new Collection<KinoSoft.MovieActor>();
            if (ActorAdd.id != null)
                foreach (Actor c in ActorAdd.id)
                {
                    int actId = c.Id;
                    MovieActor MAct = My.MovieActors.Where(k => k.Id == actId).FirstOrDefault();
                    actors.Add(MAct);
                }
            //--------------------------------------------------------------------------------------------- //Страна(-ы), в котором(-ых) снимали фильм
            var countrys = new Collection<KinoSoft.MovieCountry>();
            if (CountryAdd.id != null)
                foreach (Country c in CountryAdd.id)
                {
                    int couId = c.Id;
                    MovieCountry MCou = My.MovieCountry.Where(k => k.Id == couId).FirstOrDefault();
                    countrys.Add(MCou);
                }
            //--------------------------------------------------------------------------------------------- // Описание фильма
            string opisanie = Opisanie.Text;
            //--------------------------------------------------------------------------------------------- //Функция добавления фильма
            LogicMovie LM = new LogicMovie();
            LM.AddMovie(name, god, category, countrys, producers, actors, genre, opisanie);
            //--------------------------------------------------------------------------------------------- //Обнуление
            ProducerAdd.id = null;
            ActorAdd.id = null;
            CountryAdd.id = null;
            GenreAdd.id = null;
            this.Close();
        }
        //--------------------------------------------------------------------------------------------- /Функция выбора даты (Часть 1: Открытие и выбор)
        private void button3_Click(object sender, EventArgs e)
        {
            monthCalendar1.Show();
            monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
        }
        //--------------------------------------------------------------------------------------------- /Функция выбора даты (Часть 2: Назначение и закрытие)
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Data.Text = e.Start.ToShortDateString();
            monthCalendar1.Hide();
        }
        //--------------------------------------------------------------------------------------------- /Редактирование фильма
        private void button4_Click(object sender, EventArgs e) 
        {
            //--------------------------------------------------------------------------------------------- //Жанр фильма
            var genre = new Collection<KinoSoft.MovieGenre>();
            if (GenreAdd.id != null)
                foreach (Genre c in GenreAdd.id)
                {
                    int genId = c.Id;
                    MovieGenre MGen = My.MovieGenre.Where(k => k.Id == genId).FirstOrDefault();
                    genre.Add(MGen);
                }
            //--------------------------------------------------------------------------------------------- //Название фильма
            string name = MovieName.Text;
            //--------------------------------------------------------------------------------------------- //Дата выпуска фильма
            DateTime god = Convert.ToDateTime(Data.Text);
            //--------------------------------------------------------------------------------------------- //Категория фильма
            string category = Category.Text;
            //--------------------------------------------------------------------------------------------- //Режиссёр(-ы) фильма
            var producers = new Collection<KinoSoft.MovieProducer>();
            if (ProducerAdd.id != null)
                foreach (Producer c in ProducerAdd.id)
                {
                    int proId = c.Id;
                    MovieProducer MPro = My.MoviMovieProducere.Where(k => k.Id == proId).FirstOrDefault();
                    producers.Add(MPro);
                }
            //--------------------------------------------------------------------------------------------- //Актёр(-ы) фильма
            var actors = new Collection<KinoSoft.MovieActor>();
            if (ActorAdd.id != null)
                foreach (Actor c in ActorAdd.id)
                {
                    int actId = c.Id;
                    MovieActor MAct = My.MovieActors.Where(k => k.Id == actId).FirstOrDefault();
                    actors.Add(MAct);
                }
            //--------------------------------------------------------------------------------------------- //Страна(-ы), в котором(-ых) снимали фильм
            var countrys = new Collection<KinoSoft.MovieCountry>();
            if (CountryAdd.id != null)
                foreach (Country c in CountryAdd.id)
                {
                    int couId = c.Id;
                    MovieCountry MCou = My.MovieCountry.Where(k => k.Id == couId).FirstOrDefault();
                    countrys.Add(MCou);
                }
            //--------------------------------------------------------------------------------------------- // Описание фильма
            string opisanie = Opisanie.Text;
            //--------------------------------------------------------------------------------------------- // Обновление данных
            this.movie.Actors = actors;
            this.movie.Category = category;
            this.movie.Contries = countrys;
            this.movie.Date = god;
            this.movie.Description = opisanie;
            this.movie.Genres = genre;
            this.movie.Name = name;
            this.movie.Producers = producers;
            My.SaveChanges();
            //--------------------------------------------------------------------------------------------- // Обнуление
            ProducerAdd.id = null;
            ActorAdd.id = null;
            CountryAdd.id = null;
            GenreAdd.id = null;
            this.Close();
        }
        //--------------------------------------------------------------------------------------------- /Открывает форму с жанрами
        private void button5_Click(object sender, EventArgs e)
        {
            Forms.AddGenre asd = new Forms.AddGenre();
            asd.ShowDialog();
        }
        //--------------------------------------------------------------------------------------------- /Ошибка молодости
        private void AddMovie_Load(object sender, EventArgs e)
        {
        }
        //--------------------------------------------------------------------------------------------- /Обновление некоторых штучек-дрючек
        private void AddMovie_Activated(object sender, EventArgs e)
        {
            //--------------------------------------------------------------------------------------------- //Обновление списка категорий 
            Category.Items.Clear();
            var category = My.MovieCategory.ToList();
            foreach (var item in category)
            {
                Category.Items.Add(item.Category.ToString());
            }
            //--------------------------------------------------------------------------------------------- //Заполнение строки с режиссёрами из дочернего окна
            if(ProducerAdd.id != null)
            {
                Producer.Clear();
                foreach (Producer c in ProducerAdd.id)
                {
                    Producer.Text += c.SecondName + " " + c.FirstName + " " + c.LastName + ", ";
                }
            }
            //--------------------------------------------------------------------------------------------- //Заполнение строки с актёрами из дочернего окна
            if (ActorAdd.id != null)
            {
                Actors.Clear();
                foreach (Actor c in ActorAdd.id)
                {
                    Actors.Text += c.SecondName + " " + c.FirstName + " " + c.LastName + ", ";
                }
            }
            //--------------------------------------------------------------------------------------------- //Заполнение строки с странами из дочернего окна
            if (CountryAdd.id != null)
            {
                Country.Clear();
                foreach (Country c in CountryAdd.id)
                {
                    Country.Text += c.CountryName + ", ";
                }
            }
            //--------------------------------------------------------------------------------------------- //Заполнение строки с жанрами из дочернего окна
            if (GenreAdd.id != null)
            {
                textBox1.Clear();
                foreach (Genre c in GenreAdd.id)
                {
                    textBox1.Text += c.Name + ", ";
                }
            }
        }
        //--------------------------------------------------------------------------------------------- /Открывает форму с категориями 
        private void button6_Click(object sender, EventArgs e)
        {
            Forms.AddCategory asd = new Forms.AddCategory();
            asd.ShowDialog();
        }
        //--------------------------------------------------------------------------------------------- /Открывает форму с странами 
        private void button7_Click(object sender, EventArgs e)
        {
            Forms.AddCountry asd = new Forms.AddCountry();
            asd.ShowDialog();
        }
        //--------------------------------------------------------------------------------------------- /Открывает форму с режиссерами
        private void button8_Click(object sender, EventArgs e)
        {
            Forms.AddProducer asd = new Forms.AddProducer();
            asd.Show();
        }
        //--------------------------------------------------------------------------------------------- /Отркывает форму с актёрами
        private void button9_Click(object sender, EventArgs e)
        {
            Forms.AddActor asd = new Forms.AddActor();
            asd.Show();
        }
        //--------------------------------------------------------------------------------------------- /Отркывает форму с странами
        private void Country_Click(object sender, EventArgs e)
        {
            Forms.AddCountry asd = new Forms.AddCountry();
            asd.ShowDialog();
        }
        //--------------------------------------------------------------------------------------------- /Отркывает форму с режиссёрами
        private void Producer_Click(object sender, EventArgs e)
        {
            Forms.AddProducer asd = new Forms.AddProducer();
            asd.Show();
        }
        //--------------------------------------------------------------------------------------------- /Отркывает форму с актёрами
        private void Actors_Click(object sender, EventArgs e)
        {
            Forms.AddActor asd = new Forms.AddActor();
            asd.Show();
        }
        //--------------------------------------------------------------------------------------------- /Отркывает форму с жанрами
        private void textBox1_Click(object sender, EventArgs e)
        {
            Forms.AddGenre asd = new Forms.AddGenre();
            asd.Show();
        }
        //--------------------------------------------------------------------------------------------- Кнопка закрытия
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Если вы закроете, то введённые данные будут сброшены. Вы уверены в этом?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
            if (result == DialogResult.Yes)
            {
                //--------------------------------------------------------------------------------------------- // Обнуление
                ProducerAdd.id = null;
                ActorAdd.id = null;
                CountryAdd.id = null;
                GenreAdd.id = null;
                Close();
            }
        }
        //--------------------------------------------------------------------------------------------- Забытая всеми функция 
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
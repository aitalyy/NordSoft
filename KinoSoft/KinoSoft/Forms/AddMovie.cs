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
        //--------------------------------------------------------------------------------------------- Инициализация (Тоже не знаю почему принимает Movie)
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
            this.movie = My.Movies.Find(movie.Id);

            
        }
        //--------------------------------------------------------------------------------------------- Я (Вова) не знаю откуда это, наверное кто-то добавил
        private void FillFields(Movie movie)
        {
            MovieName.Text = movie.Name;
            // ...
        }
        //--------------------------------------------------------------------------------------------- Забытая всеми функция 
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            if (result == DialogResult.Yes) Close();   
        }
        //--------------------------------------------------------------------------------------------- /Добавление фильма
        private void button2_Click(object sender, EventArgs e) 
        {
            //--------------------------------------------------------------------------------------------- //Жанр фильма
            var genre = new Collection<MovieGenre>();
            foreach (var item in Genre.CheckedItems)
            {
                string Genres = item.ToString();
                MovieGenre genre1 = My.MovieGenre.Where(k => k.Genre.Name == Genres).FirstOrDefault();
                genre.Add(genre1);
            }
            //--------------------------------------------------------------------------------------------- //Название фильма
            string name = MovieName.Text;
            //--------------------------------------------------------------------------------------------- //Дата выпуска фильма
            DateTime god = Convert.ToDateTime(Data.Text);
            //--------------------------------------------------------------------------------------------- //Категория фильма
            string category = Category.Text;
            MovieCategory MCat = My.MovieCategory.Where(k => k.Category == category).FirstOrDefault();
            //--------------------------------------------------------------------------------------------- //Режиссёр(-ы) фильма
            var producers = new Collection<KinoSoft.MovieProducer>();
            if (Producer.Text.Length < 3)
            {
                int proId = Convert.ToInt32(Producer.Text);
                MovieProducer MPro = My.MoviMovieProducere.Where(k => k.Id == proId).FirstOrDefault();
                producers.Add(MPro);
            }
            else
            {
                string[] producerstr = Producer.Text.Split(' ');
                for (int i = 0; i < producerstr.Length; i++)
                {
                    int proId = Convert.ToInt32(producerstr[i]);
                    MovieProducer MPro = My.MoviMovieProducere.Where(k => k.Id == proId).FirstOrDefault();
                    producers.Add(MPro);
                }
            }
            //--------------------------------------------------------------------------------------------- //Актёр(-ы) фильма
            var actors = new Collection<KinoSoft.MovieActor>();
            string[] actorsstr = Actors.Text.Split(' ');
            for (int i = 0; i < actorsstr.Length; i++)
            {
                int actId = Convert.ToInt32(actorsstr[i]);
                MovieActor MAct = My.MovieActors.Where(k => k.Id == actId).FirstOrDefault();
                actors.Add(MAct);
            }
            //--------------------------------------------------------------------------------------------- //Страна(-ы), в котором(-ых) снимали фильм
            var countrys = new Collection<KinoSoft.MovieCountry>();
            if (Country.Text.Length < 3)
            {
                int couId = Convert.ToInt32(Country.Text);
                MovieCountry MCou = My.MovieCountry.Where(k => k.Id == couId).FirstOrDefault();
                countrys.Add(MCou);
            }
            else
            {
                string[] countrystr = Country.Text.Split(' ');
                for (int i = 0; i < countrystr.Length; i++)
                {
                    int couId = Convert.ToInt32(countrystr[i]);
                    MovieCountry MCou = My.MovieCountry.Where(k => k.Id == couId).FirstOrDefault();
                    countrys.Add(MCou);
                }
            }
            //--------------------------------------------------------------------------------------------- // Описание фильма
            string opisanie = Opisanie.Text;
            //--------------------------------------------------------------------------------------------- //Функция добавления фильма
            LogicMovie LM = new LogicMovie();
            LM.AddMovie(name, god, MCat, countrys, producers, actors, genre, opisanie);
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
            movie.Name = MovieName.Text;
            // ...

            My.SaveChanges();
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
            //--------------------------------------------------------------------------------------------- //Обновление списка жанров
            Genre.Items.Clear();
            var genres = My.Genres.ToList();
            foreach (var item in genres)
            {
                Genre.Items.Add(item.Name.ToString());
            }
            //--------------------------------------------------------------------------------------------- //Обновление списка категорий 
            Category.Items.Clear();
            var category = My.MovieCategory.ToList();
            foreach (var item in category)
            {
                Category.Items.Add(item.Category.ToString());
            }
            //--------------------------------------------------------------------------------------------- //Заполнение строки с режиссёрами из дочернего окна
            //Producer.Text += LogicMovie.ProducerAdd.FIO + ' ';
            //if (Producer.Text == "0 ") Producer.Clear();
            //Producer.Text = new string(Producer.Text.Distinct().ToArray());
            //--------------------------------------------------------------------------------------------- //Заполнение строки с актёрами из дочернего окна
            //Actors.Text += LogicMovie.ActorAdd.FIO + ' ';
            //if (Actors.Text == "0 ") Actors.Clear();
            //Actors.Text = new string(Actors.Text.Distinct().ToArray());
            //--------------------------------------------------------------------------------------------- //Заполнение строки с странами из дочернего окна
            //Country.Text += LogicMovie.CountryAdd.Name + ' ';
            //if (Country.Text == "0 ") Country.Clear();
            //Country.Text = new string(Country.Text.Distinct().ToArray());
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

        private void Country_Click(object sender, EventArgs e)
        {
            Forms.AddCountry asd = new Forms.AddCountry();
            asd.ShowDialog();
        }

        private void Producer_Click(object sender, EventArgs e)
        {
            Forms.AddProducer asd = new Forms.AddProducer();
            asd.Show();
        }

        private void Actors_Click(object sender, EventArgs e)
        {
            Forms.AddActor asd = new Forms.AddActor();
            asd.Show();
        }
    }
}
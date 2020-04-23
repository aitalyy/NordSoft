using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.ObjectModel;
using KinoSoft.FormsSearch;

namespace KinoSoft
{
    public partial class SearchForm : Form
    {
        private Contex db = new Contex();
        private Tables table = Tables.Actor;
        private Movie movie = null;

        public SearchForm(Tables table/*, Movie movie*/)
        {
            InitializeComponent();
            //this.table = table;
            //this.movie = db.Movies.Find(movie.Id);
            UpdateTable();
        }

        private void UpdateTable()
        {
            switch (table)
            {
                case Tables.Actor:
                    dataAll.DataSource = db.Actors.ToList<Actor>();
                    //foreach (MovieActor actor in movie.Actors)
                    //{
                    //    for (int i = 0; i < dataAll.Rows.Count; i++)
                    //    {
                    //        Actor dataActor = dataAll.Rows[i].DataBoundItem as Actor;
                    //        if (actor.ActorId == dataActor.Id)
                    //        {
                    //            dataAll.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    //        }
                    //    }
                    //}
                    break;
                case Tables.Producer:
                    dataAll.DataSource = db.Producers.ToList<Producer>();
                    break;
                case Tables.Country:
                    dataAll.DataSource = db.Countrys.ToList<Country>();
                    break;
                case Tables.Genre:
                    dataAll.DataSource = db.Genres.ToList<Genre>();
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

        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }

        private void dataAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataAll_SelectionChanged(object sender, EventArgs e)
        {
            dataAll.SelectedRows[0].DefaultCellStyle.BackColor = Color.Red;
            dataAll.SelectedRows[0].Selected = false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (table)
            {
                case Tables.Genre:
                    //movie.Genres.Clear();
                    break;
                case Tables.Country:
                    //movie.Contries.Clear();
                    break;
                case Tables.Actor:
                    //movie.Actors.Clear();
                    break;
                case Tables.Producer:
                    //movie.Producers.Clear();
                    break;
                default:
                    break;
            }
            for (int i = 0; i < dataAll.Rows.Count; i++)
            {
                if (dataAll.Rows[i].DefaultCellStyle.BackColor == Color.Red)
                {
                    switch (table)
                    {
                        case Tables.Genre:
                            //movie.Genres.Add(dataAll.Rows[i].DataBoundItem as Genre);
                            break;
                        case Tables.Country:
                            //Countrys.Add(dataAll.Rows[i].DataBoundItem as Country);
                            break;
                        case Tables.Actor:
                            //Actors.Add(dataAll.Rows[i].DataBoundItem as Actor);
                            break;
                        case Tables.Producer:
                            //Producers.Add(dataAll.Rows[i].DataBoundItem as Producer);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string[] text = addText.Text.Split(' ');
            string[] FIO = new string[3];

            for(int i = 0; i < text.Length; ++i)
            {
                FIO[i] = text[i];
            }

            switch (table)
            {
                case Tables.Genre:
                    Genre genre = new Genre()
                    {
                        Name = addText.Text
                    };
                    db.Genres.Add(genre);
                    break;
                case Tables.Country:
                    Country country = new Country()
                    {
                        CountryName = addText.Text
                    };
                    db.Countrys.Add(country);
                    break;
                case Tables.Actor:
                    Actor actor = new Actor()
                    {
                        FirstName = FIO[1],
                        LastName = FIO[2],
                        SecondName = FIO[3]
                    };
                    db.Actors.Add(actor);
                    break;
                case Tables.Producer:
                    Producer producer = new Producer()
                    {
                        FirstName = FIO[1],
                        LastName = FIO[2],
                        SecondName = FIO[3]
                    };
                    db.Producers.Add(producer);
                    break;
                default:
                    break;
            }
            db.SaveChanges();
        }
        private void addMovieDisk()
        {
            int id = Convert.ToInt32(dataAll[0, dataAll.CurrentCell.RowIndex].Value);
            MessageBox.Show(Convert.ToString(id));
            
            Movie mov = db.Movies.Where(k => k.Id == id).FirstOrDefault();
            Disk disk = db.Disks.Where(k => k.Id == Id_all.id_all).FirstOrDefault();

            MovieDisk movieDisk = new MovieDisk
            {
                MovieId = mov.Id,
                Movie = mov,
                DiskId = id,
                Disk = disk
            };
            db.MovieDisks.Add(movieDisk);

            if (addText == null)
                addText.Text = mov.Name;
            else
                addText.Text = "," + mov.Name;

            var disk2 = new Disk();
            disk2.Movies = new Collection<MovieDisk>();
            disk2.Movies.Add(movieDisk);
            db.SaveChanges();
        }
    }
}
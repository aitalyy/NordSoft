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
    public partial class SearchForm : Form
    {
        private Contex db = new Contex();
        private Tables table = Tables.Actor;
        private Movie movie = null;

        public SearchForm(Tables table, Movie movie)
        {
            InitializeComponent();
            this.table = table;
            this.movie = db.Movies.Find(movie.Id);
            UpdateTable();
        }

        private void UpdateTable()
        {
            switch (table)
            {
                case Tables.Actor:
                    dataAll.DataSource = db.Actors.ToList<Actor>();
                    foreach (MovieActor actor in movie.Actors)
                    {
                        for (int i = 0; i < dataAll.Rows.Count; i++)
                        {
                            Actor dataActor = dataAll.Rows[i].DataBoundItem as Actor;
                            if (actor.ActorId == dataActor.Id)
                            {
                                dataAll.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }
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
                    movie.Genres.Clear();
                    break;
                case Tables.Country:
                    movie.Contries.Clear();
                    break;
                case Tables.Actor:
                    movie.Actors.Clear();
                    break;
                case Tables.Producer:
                    movie.Producers.Clear();
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
                            movie.Genres.Add(dataAll.Rows[i].DataBoundItem as Genre);
                            break;
                        case Tables.Country:
                            Countrys.Add(dataAll.Rows[i].DataBoundItem as Country);
                            break;
                        case Tables.Actor:
                            Actors.Add(dataAll.Rows[i].DataBoundItem as Actor);
                            break;
                        case Tables.Producer:
                            Producers.Add(dataAll.Rows[i].DataBoundItem as Producer);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
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

        public SearchForm(Tables table)
        {
            InitializeComponent();
        }

        public void UpdateTable()
        {
            switch (table)
            {
                case Tables.Actor:
                    dataAll.DataSource = db.Actors.ToList<Actor>();
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
    }
}

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
    public partial class EditMovie : Form
    {
        public EditMovie()
        {
            InitializeComponent();
            using (Contex db = new Contex())
            {
                foreach (Genre genre in db.Genres)
                    Genre.Items.Add(genre.Name);
            }
            //MovieName.Text = (string) row.Cells[1].Value;
        }

        private void EditMovie_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}

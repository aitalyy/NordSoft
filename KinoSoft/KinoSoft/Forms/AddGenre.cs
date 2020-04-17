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
    public partial class AddGenre : Form
    {
        Contex My = new Contex();
        LogicMovie logMovie = new LogicMovie();
        public AddGenre()
        {
            InitializeComponent();
            dataGridView1.DataSource = My.Genres.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logMovie.addGenre(textBox1.Text);
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            My.SaveChanges();
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int idGenre = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
                logMovie.RemoveGenre(idGenre);
                update();
            }
            catch
            {
                DialogResult result = MessageBox.Show(
                     "Ошибка! \n Вы не выбрали жанр для удаления.",
                     "Сообщение",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.ServiceNotification);
                if (result == DialogResult.OK) Close();
            }
            
        }
        public void update()
        {
            dataGridView1.DataSource = My.Genres.ToList();
        }
    }
}

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
    public partial class AddCategory : Form
    {
        Contex My = new Contex();
        LogicMovie logMovie = new LogicMovie();
        public AddCategory()
        {
            InitializeComponent();
            dataGridView1.DataSource = My.MovieCategory.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                     "Ошибка! \n Вы не выбрали  для удаления.",
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
            dataGridView1.DataSource = My.MovieCategory.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logMovie.addCategory(textBox1.Text);
            update();
        }
    }
}

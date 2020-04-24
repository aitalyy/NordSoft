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
    public partial class AddProducer : Form
    {
        LogicMovie lm = new LogicMovie();
        Contex My = new Contex();
        public AddProducer()
        {
            InitializeComponent();
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lm.addProducer(textBox1.Text, textBox2.Text, textBox3.Text);
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int idGenre = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
                lm.RemoveProducer(idGenre);
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
            dataGridView1.DataSource = My.Producers.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
            textBox2.Text = Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value);
            textBox3.Text = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value);
            LogicMovie.ProducerAdd.FIO = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + "; ";
        }
    }
}

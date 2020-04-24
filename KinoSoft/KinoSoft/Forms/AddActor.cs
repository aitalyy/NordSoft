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
    public partial class AddActor : Form
    {
        LogicMovie lm = new LogicMovie();
        Contex My = new Contex();
        //--------------------------------------------------------------------------------------------- /Инициализация
        public AddActor()
        {
            InitializeComponent();
            update();
        }
        //--------------------------------------------------------------------------------------------- /Кнопка закрытия
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------------------------------------------------------------- /Кнопка удаления
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
                     "Ошибка! \n Вы не выбрали строку для удаления.",
                     "Сообщение",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.ServiceNotification);
                if (result == DialogResult.OK) Close();
            }
        }
        //--------------------------------------------------------------------------------------------- /Кнопка добавления актёра
        private void button3_Click(object sender, EventArgs e)
        {
            lm.addActor(textBox1.Text, textBox2.Text, textBox3.Text);
            update();
        }
        //--------------------------------------------------------------------------------------------- /Функция обновления таблицы
        public void update()
        {
            dataGridView1.DataSource = My.Producers.ToList();
        }
        //--------------------------------------------------------------------------------------------- /Функция выбора строки, которая будет отправлена в родительское окно
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //--------------------------------------------------------------------------------------------- //Заполнение полей ФИО
            textBox1.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
            textBox2.Text = Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value);
            textBox3.Text = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value);
            //--------------------------------------------------------------------------------------------- //Отправка id родительскому окну
            LogicMovie.ActorAdd.FIO = Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value);
        }
    }
}

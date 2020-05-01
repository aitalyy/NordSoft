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
    public partial class AddCountry : Form
    {
        Contex My = new Contex();
        LogicMovie logMovie = new LogicMovie();
        //--------------------------------------------------------------------------------------------- /Инициализация
        public AddCountry()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------------------------------- /Кнопка закрытия
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------------------------------------------------------------- /Кнопка удаления
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int idCountry = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
                logMovie.RemoveCountry(idCountry);
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
        //--------------------------------------------------------------------------------------------- /Кнопка добавления
        private void button2_Click(object sender, EventArgs e)
        {
            logMovie.addCountry(textBox1.Text);
            update();
        }
        //--------------------------------------------------------------------------------------------- /Функция обновления таблицы
        public void update()
        {
            dataGridView1.DataSource = My.Countrys.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //--------------------------------------------------------------------------------------------- //Заполнение поля названия
            //textBox1.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
            //--------------------------------------------------------------------------------------------- //Отправка id родительскому окну
            //LogicMovie.CountryAdd.Name = Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value);
        }
    }
}

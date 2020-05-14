using iTextSharp.text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoSoft.FormsDisk;

namespace KinoSoft.Forms
{
    public partial class AddProducer : Form
    {
        LogicMovie lm = new LogicMovie();
        Contex My = new Contex();
        ArrayList list = new ArrayList();
        List<Producer> listprod = new List<Producer>();
        //--------------------------------------------------------------------------------------------- /Инициализация
        public AddProducer()
        {
            InitializeComponent();
            update();
        }
        //--------------------------------------------------------------------------------------------- /Функция проверки выбранных объектов
        private bool checkAdd(int id)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (Convert.ToInt32(list[i]) == id)
                {
                    return true;
                }
            }
            return false;
        }
        //--------------------------------------------------------------------------------------------- /Кнопка закрытия
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------------------------------------------------------------- /Кнопка добавления режиссёра
        private void button3_Click(object sender, EventArgs e)
        {
            lm.addProducer(textBox1.Text, textBox2.Text, textBox3.Text);
            update();
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
                     "Ошибка! \n Вы не выбрали жанр для удаления.",
                     "Сообщение",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.ServiceNotification);
                if (result == DialogResult.OK) Close();
            }

        }
        //--------------------------------------------------------------------------------------------- /Функция обновления таблицы
        public void update()
        {
            dataGridView1.DataSource = My.Producers.ToList();
            dataGridView2.DataSource = listprod.ToList();
        }
        //--------------------------------------------------------------------------------------------- /Функция выбора строки, которая будет отправлена в родительское окно
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //--------------------------------------------------------------------------------------------- //Заполнение полей ФИО
            //textBox1.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
            //textBox2.Text = Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value);
            //textBox3.Text = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value);
            //--------------------------------------------------------------------------------------------- //Отправка id родительскому окну
            //LogicMovie.ProducerAdd.FIO = Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value);
        }
        //--------------------------------------------------------------------------------------------- /Функция выбора строки, которая будет отправлена в родительское окно
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            int idProd = Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value);
            if (checkAdd(idProd) == false)
            {
                list.Add(idProd);
                listprod.Add(My.Producers.Where(k => k.Id == idProd).FirstOrDefault());
            }
            update();
        }
        //--------------------------------------------------------------------------------------------- /Убрать выбранного актёра
        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
                return;
            int idProd = Convert.ToInt32(dataGridView2[1, dataGridView2.CurrentCell.RowIndex].Value);
            for (int i = 0; i < listprod.Count; i++)
                if (Convert.ToInt32(list[i]) == idProd)
                {
                    list.RemoveAt(i);
                    listprod.RemoveAt(i);
                }
            update();
        }
        //--------------------------------------------------------------------------------------------- /Поиск 
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(textBox1.Text) &&
                            dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(textBox3.Text) &&
                            dataGridView1.Rows[i].Cells[4].Value.ToString().Contains(textBox2.Text))
                        {
                            dataGridView1.CurrentCell = dataGridView1[0, i];
                        }
                    }
            }
        }
        //--------------------------------------------------------------------------------------------- /Отправка на родительское окно
        private void button5_Click(object sender, EventArgs e)
        {
            //--------------------------------------------------------------------------------------------- //coming soon
        }
    }
}

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
            if (ProducerAdd.id != null)
                listprod = ProducerAdd.id;
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
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Visible = false;
            this.dataGridView1.Columns[2].HeaderText = "Имя";
            this.dataGridView1.Columns[3].HeaderText = "Фамилия";
            this.dataGridView1.Columns[4].HeaderText = "Отчество";
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[6].Visible = false;
            dataGridView2.DataSource = listprod.ToList();
            this.dataGridView2.Columns[0].Visible = false;
            this.dataGridView2.Columns[1].Visible = false;
            this.dataGridView2.Columns[2].HeaderText = "Имя";
            this.dataGridView2.Columns[3].HeaderText = "Фамилия";
            this.dataGridView2.Columns[4].HeaderText = "Отчество";
            this.dataGridView2.Columns[5].Visible = false;
            this.dataGridView2.Columns[6].Visible = false;
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

        //--------------------------------------------------------------------------------------------- /Отправка на родительское окно
        private void button5_Click(object sender, EventArgs e)
        {
            ProducerAdd.id = listprod;
            this.Close();
        }
        //--------------------------------------------------------------------------------------------- /Поиск по имени
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.CurrentCell = null;
                if (row.Cells[2].Value.ToString().Contains(textBox1.Text))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
        //--------------------------------------------------------------------------------------------- /Поиск по Фамилии
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.CurrentCell = null;
                if (row.Cells[4].Value.ToString().Contains(textBox2.Text))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
        //--------------------------------------------------------------------------------------------- /Поиск по отчеству/матчеству
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.CurrentCell = null;
                if (row.Cells[3].Value.ToString().Contains(textBox3.Text))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
    }
}

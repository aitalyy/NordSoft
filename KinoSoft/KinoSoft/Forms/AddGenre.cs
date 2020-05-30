using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.ObjectModel;

namespace KinoSoft.Forms
{
    public partial class AddGenre : Form
    {
        Contex My = new Contex();
        LogicMovie logMovie = new LogicMovie();
        ArrayList list = new ArrayList();
        List<Genre> listcount = new List<Genre>();
        //--------------------------------------------------------------------------------------------- /Инициализация
        public AddGenre()
        {
            InitializeComponent();
            dataGridView1.DataSource = My.Genres.ToList();
        }
        //--------------------------------------------------------------------------------------------- /Кнопка добавления
        private void button2_Click(object sender, EventArgs e)
        {
            logMovie.addGenre(textBox1.Text);
            update();
        }
        //--------------------------------------------------------------------------------------------- /Кнопка закрытия
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------------------------------------------------------------- /Кажется ещё одна функция для обновления, но с сохранением
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            My.SaveChanges();
            update();
        }
        //--------------------------------------------------------------------------------------------- /Кнопка удаления
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
        //--------------------------------------------------------------------------------------------- /Функция обновления таблицы
        public void update()
        {
            dataGridView1.DataSource = My.Genres.ToList();
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].HeaderText = "Жанр";
            this.dataGridView1.Columns[2].Visible = false;
            dataGridView2.DataSource = listcount.ToList();
            this.dataGridView2.Columns[0].Visible = false;
            this.dataGridView2.Columns[1].HeaderText = "Жанр";
            this.dataGridView2.Columns[2].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.CurrentCell = null;
                if (row.Cells[1].Value.ToString().Contains(textBox1.Text))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenreAdd.id = listcount;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            int idCount = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
            if (checkAdd(idCount) == false)
            {
                list.Add(idCount);
                listcount.Add(My.Genres.Where(k => k.Id == idCount).FirstOrDefault());
            }
            update();
        }

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

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
                return;
            int idCount = Convert.ToInt32(dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value);
            for (int i = 0; i < listcount.Count; i++)
                if (Convert.ToInt32(list[i]) == idCount)
                {
                    list.RemoveAt(i);
                    listcount.RemoveAt(i);
                }
            update();
        }
    }
}

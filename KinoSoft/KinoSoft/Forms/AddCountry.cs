﻿using iTextSharp.text;
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
    public partial class AddCountry : Form
    {
        Contex My = new Contex();
        LogicMovie logMovie = new LogicMovie();
        ArrayList list = new ArrayList();
        List<Country> listcount = new List<Country>();
        //--------------------------------------------------------------------------------------------- /Инициализация
        public AddCountry()
        {
            InitializeComponent();
            dataGridView1.DataSource = My.Countrys.ToList();
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
            dataGridView2.DataSource = listcount.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //--------------------------------------------------------------------------------------------- //Заполнение поля названия
            //textBox1.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
            //--------------------------------------------------------------------------------------------- //Отправка id родительскому окну
            //LogicMovie.CountryAdd.Name = Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value);
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
        //--------------------------------------------------------------------------------------------- /Функция выбора строки, которая будет отправлена в родительское окно
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            int idCount = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
            if (checkAdd(idCount) == false)
            {
                list.Add(idCount);
                listcount.Add(My.Countrys.Where(k => k.Id == idCount).FirstOrDefault());
            }
            update();
        }
        //--------------------------------------------------------------------------------------------- /Убрать выбранного актёра
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
        //--------------------------------------------------------------------------------------------- /Поиск
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.CurrentCell = dataGridView1[0, i];
                        }
                    }
            }
            }
    }
}

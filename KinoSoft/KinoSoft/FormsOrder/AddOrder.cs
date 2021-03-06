﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Collections.ObjectModel;

namespace KinoSoft.FormsOrder
{
    public partial class AddOrder : Form
    {
        Contex My = new Contex();
        private int costDiskAll = 0;
        private ArrayList arrayDisk = new ArrayList();
        private int idOrder;
        private int idClient;
        private int idRows;

        private enum TablesOrder
        {
            Client,
            Disk
        }

        TablesOrder table;

        public AddOrder()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormsClient.AddClient addClient = new FormsClient.AddClient();
            addClient.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormsClient.EditClient editClient = new FormsClient.EditClient();
            editClient.Show();
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            Data2.Text = e.Start.ToShortDateString();
            monthCalendar2.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible == true)
                monthCalendar1.Visible = false;
            else
                monthCalendar1.Show();
            //Data.Text = monthCalendar1.SelectionStart.ToShortDateString().ToString();
            monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);

            //monthCalendar1.Hide();
        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Data.Text = e.Start.ToShortDateString();
            monthCalendar1.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (monthCalendar2.Visible == true)
                monthCalendar2.Visible = false;
            else
                monthCalendar2.Show();
            //Data.Text = monthCalendar1.SelectionStart.ToShortDateString().ToString();
            monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            
            
            //monthCalendar1.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LogicOrder logOr = new LogicOrder();

            


            logOr.AddOrder(Convert.ToDateTime(Data.Text), Convert.ToDateTime(Data2.Text), arrayDisk, idClient, idOrder, costDiskAll);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            ListClient();
            try
            {
                var lastId = My.Orders.OrderByDescending(k => k.Id).FirstOrDefault();
                idOrder = lastId.Id + 1;
                textBox1.Text = Convert.ToString(idOrder);
            }
            catch
            {
                idOrder = 0;
                textBox1.Text = Convert.ToString(idOrder);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddOrder_Activated(object sender, EventArgs e)
        {
            //if (checkClient == true)
            //{
            //    LogicOrder logOr = new LogicOrder();
            //    logOr.AddOrder(Convert.ToDateTime(Data), Convert.ToDateTime(Data2));
            //    checkClient = false;
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = My.Orders.ToList<Order>();
            LogicOrder logOr = new LogicOrder();
            logOr.GetListOrder(dataGridView1);
            textDatagrid.Text = "Список заказов";
            buttonDisk.Visible = false;
            RemDiskBut.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            switch (table)
            {
                case TablesOrder.Disk:
                    int idDisk = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);//айди диска

                    int CostDisk = Convert.ToInt32(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value); //сумма стоимости заказа
                    costDiskAll += CostDisk;
                    CostOrder.Text = Convert.ToString(costDiskAll);

                    dataGridView1.CurrentRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;//изменение цвета выбронного поля
                    bool check = false;
                    for (int i=0; i<arrayDisk.Count; i++)
                        if (Convert.ToInt32(arrayDisk[i]) == idDisk)
                        {
                            check = true;
                            break;
                        }
                    if (check == false)
                        arrayDisk.Add(idDisk);

                    //MessageBox.Show(Convert.ToString(arrayDisk[0]));
                    break;
                case TablesOrder.Client:
                    if (idClient == Convert.ToInt32(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value))
                    {
                        dataGridView1.CurrentRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;//изменение цвета выбронного поля
                        idRows = dataGridView1.CurrentRow.Index;
                    }
                    else
                    {
                        dataGridView1.Rows[idRows].DefaultCellStyle.BackColor = Color.White;
                        dataGridView1.CurrentRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;//изменение цвета выбронного поля
                        idRows = dataGridView1.CurrentRow.Index;
                    }
                    idClient = Convert.ToInt32(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value);//айди кдиента
                    break;
                default:
                    break;
            }
            
        }

        private void buttonListDisk_Click(object sender, EventArgs e)
        {
            ListDisk();
        }

        private void ListDisk()
        {
            dataGridView1.DataSource = My.Disks.ToList<Disk>();
            textDatagrid.Text = "Список дисков";
            buttonDisk.Visible = true;
            RemDiskBut.Visible = true;
            table = TablesOrder.Disk;
            RemDiskBut.Text = "Удалить из списка";
        }

        private void RemDiskBut_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            switch (table)
            {
                case TablesOrder.Client:
                    dataGridView1.CurrentRow.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    break;
                case TablesOrder.Disk:
                    int idDisk = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);//айди диска
                    int CostDisk = Convert.ToInt32(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
                    costDiskAll -= CostDisk;
                    CostOrder.Text = Convert.ToString(costDiskAll);
                    dataGridView1.CurrentRow.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    arrayDisk.Remove(idDisk);
                    break;
                default:
                    break;
            }
            
        }

        private void ClientSelect_Click(object sender, EventArgs e)
        {
            ListClient();
        }

        private void ListClient()
        {
            dataGridView1.DataSource = My.Clients.ToList<Client>();
            textDatagrid.Text = "Список клиентов";
            buttonDisk.Visible = true;
            RemDiskBut.Visible = true;
            table = TablesOrder.Client;
            RemDiskBut.Text = "Удалить";
        }

        private void textButton_Click(object sender, EventArgs e)
        {
            int asdqwe = Convert.ToInt32(arrayDisk[0]);
            Disk qwe = My.Disks.Where(k => k.Id == asdqwe).FirstOrDefault();
            dataGridView1.DataSource = qwe.Movies.ToList<MovieDisk>();
        }

        private void button3_Click(object sender, EventArgs e)
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

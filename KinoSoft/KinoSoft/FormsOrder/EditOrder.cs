﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft.FormsOrder
{
    public partial class EditOrder : Form
    {
        public EditOrder()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
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

        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {
            monthCalendar2.Show();
            monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
        }
        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            Data2.Text = e.Start.ToShortDateString();
            monthCalendar2.Hide();
        }

    }
}
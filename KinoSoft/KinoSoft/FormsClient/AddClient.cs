﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft.FormsClient
{
    public partial class AddClient : Form
    {
        Contex My = new Contex();

        public AddClient()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogicClient logicClient = new LogicClient();

            string FirstName = textBox1.Text;
            string LastName = textBox2.Text;
            string SecondName = textBox4.Text;
            int NumberPassport = Convert.ToInt16(textBox5.Text);
            int seriesPassport = Convert.ToInt32(textBox6.Text);
            string PhoneNumber = textBox3.Text;

            logicClient.AddClient(FirstName, LastName, SecondName, NumberPassport, seriesPassport, PhoneNumber);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

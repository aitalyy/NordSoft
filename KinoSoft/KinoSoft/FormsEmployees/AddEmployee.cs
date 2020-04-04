﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft.Employees
{
    public partial class AddEmployee : Form
    {
        Contex My = new Contex();
        LogicEmployees logEmp = new LogicEmployees();
            
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRole role = new FormRole();
            role.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logEmp.AddEmployee(firstNameBox.Text, LastNameBox.Text, secondNameBox.Text, phoneNumberBox.Text, loginBox.Text, passwordBox.Text, Convert.ToInt32(roleComboBox.SelectedValue), Convert.ToInt32(numberBox.Text), Convert.ToInt32(seriesBox.Text));
        }

        private void roleComboBox_Click(object sender, EventArgs e)
        {
            roleComboBox.DataSource = My.Roles.ToList();
            roleComboBox.ValueMember = "RoleId";
            roleComboBox.DisplayMember = "Name";
        }

        private void roleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            roleComboBox.DataSource = My.Roles.ToList();
            roleComboBox.ValueMember = "RoleId";
            roleComboBox.DisplayMember = "Name";
        }
    }
}

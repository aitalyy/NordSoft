using System;
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
            string firstName = firstNameBox.Text;
            string LastName = LastNameBox.Text;
            string secondName = secondNameBox.Text;
            string phoneNumber = phoneNumberBox.Text;
            string login = loginBox.Text;
            string password = passwordBox.Text;
            int role = Convert.ToInt32(roleComboBox.SelectedValue);
            int passNum = Convert.ToInt32(numberBox.Text);
            int passSer = Convert.ToInt32(seriesBox.Text);
            Employee employee = My.Employees.Where(k => k.Login == login).FirstOrDefault();
            if (employee == null)
            { 
                logEmp.AddEmployee(firstName, LastName, secondName, phoneNumber, login, password, role, passNum, passSer);
            }
            else
            {
                loginBox.BackColor = Color.FromArgb(255, 192, 192);
                checkLogin.Text = "Такой логин уже существует";
            } 
            

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

        private void loginBox_Click(object sender, EventArgs e)
        {
            checkLogin.Text = "";
            loginBox.BackColor = Color.White;
        }
    }
}

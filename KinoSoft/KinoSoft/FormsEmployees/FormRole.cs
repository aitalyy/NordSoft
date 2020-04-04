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
    public partial class FormRole : Form
    {
        Contex My = new Contex();
        LogicEmployees logEm = new LogicEmployees();

        public FormRole()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            My.SaveChanges();
        }

        private void Role_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = My.Roles.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logEm.AddRole(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Role role = new Role();
                if (role == null)
                    continue;
                Role dbrole = My.Roles.Find(role.RoleId);
                My.Roles.Remove(dbrole);
            }
            My.SaveChanges();
            Role_Load(sender, e);
        }
    }
}

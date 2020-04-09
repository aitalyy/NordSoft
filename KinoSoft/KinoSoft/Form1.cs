using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoSoft.FormsClient;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using KinoSoft.Employees;

namespace KinoSoft
{
    public enum Tables
    {
        Order = 1,
        Client,
        Movie,
        Disk,
        Employee
    }

    public partial class Form1 : Form
    {
        Tables table = Tables.Order;
        Contex My = new Contex();

        public Form1()
        {
            InitializeComponent();
            UpdateTable();
        }

        public void UpdateTable()
        {
            switch (table)
            {
                case Tables.Client:
                    //dataAll.DataSource = My.Clients.ToList<Client>();

                    LogicClient logicCl = new LogicClient();
                    logicCl.getDataClient(dataAll);
                    break;
                case Tables.Disk:
                    dataAll.DataSource = My.Disks.ToList<Disk>();
                    break;
                case Tables.Movie:
                    dataAll.DataSource = My.Movies.ToList<Movie>();
                    break;
                case Tables.Order:
                    dataAll.DataSource = My.Orders.ToList<Order>();
                    break;
                case Tables.Employee:
                    //dataAll.DataSource = My.Employees.ToList<Employee>();
                    LogicEmployees logicEmp = new LogicEmployees();
                    logicEmp.getDataEmployee(dataAll);
                    break;
                default:
                    DialogResult result = MessageBox.Show(
                    "В процессе разработки!",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
                    break;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (table)
            {
                case Tables.Movie:
                    Forms.AddMovie addMovie = new Forms.AddMovie(null);
                    addMovie.Show();
                break;
                case Tables.Disk:
                    Forms.AddDisk addDisk = new Forms.AddDisk();
                    addDisk.Show();
                break;
                case Tables.Client:
                    FormsClient.AddClient addClient = new FormsClient.AddClient();
                    addClient.Show();
                break;
                case Tables.Employee:
                    EditEmployee.editEmployee = false;
                    AddEmployee formEmployee = new AddEmployee();
                    formEmployee.Show();
                break;
                default:
                    DialogResult result = MessageBox.Show(
                    "В процессе разработки!",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
                    break;
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataAll.SelectedRows.Count == 0)
                return;

            switch (table)
            {
                case Tables.Movie:
                    Movie movie = dataAll.SelectedRows[0].DataBoundItem as Movie; // вытаскиваем фильм из таблицы
                    if (movie == null)
                        return;

                    Forms.AddMovie editMovie = new Forms.AddMovie(movie);
                    editMovie.Show();
                    break;
                case Tables.Client:
                    FormsClient.EditClient editClient = new FormsClient.EditClient();
                    editClient.Show();
                    break;
                case Tables.Employee:
                    EditEmployee.editEmployee = true;
                    AddEmployee addEmployee = new AddEmployee();
                    int idEmployee = Convert.ToInt16(dataAll[0, dataAll.CurrentCell.RowIndex].Value);
                    EditEmployee.idEmployee = idEmployee;
                    addEmployee.Show();
                    break;  
                default:
                    DialogResult result = MessageBox.Show(
                    "В процессе разработки!",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataAll.SelectedRows.Count == 0)
                return;
            Form1 from1 = new Form1();
            DialogResult result = MessageBox.Show(
                    "Вы уверены в этом?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification
                    );
            from1.MaximizeBox = true;
            switch (table)
            {
                case Tables.Movie:
                    if (result == DialogResult.Yes)
                    {
                        foreach(DataGridViewRow row in dataAll.SelectedRows)
                        {
                            Movie movie = row.DataBoundItem as Movie;
                            if (movie == null)
                                continue;
                            Movie dbMovie = My.Movies.Find(movie.Id);
                            My.Movies.Remove(dbMovie);
                        }
                        My.SaveChanges();
                        UpdateTable();
                    }
                break;
                case Tables.Client:
                    if (result == DialogResult.Yes)
                    {
                        LogicClient LogCl = new LogicClient();
                        int idClient = Convert.ToInt32(dataAll[0, dataAll.CurrentCell.RowIndex].Value);
                        int idPassCL = Convert.ToInt32(dataAll[9, dataAll.CurrentCell.RowIndex].Value);
                        LogCl.RemoveClient(idClient, idPassCL);
                        UpdateTable();

                        //ObjectContext objectContext = (new Contex() as IObjectContextAdapter).ObjectContext;
                        //SqlConnection connection = new SqlConnection(@"Data source=.\SQLEXPRESS;InitialCatalog=Kinosoft4");
                        //ObjectQuery<DbDataRecord> disk = objectContext.CreateQuery<DbDataRecord>("SELECT * FROM Client, Passport");
                        //dataAll.DataSource = disk.ToList();
                    }
                    break;
                case Tables.Disk:
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataAll.SelectedRows)
                        {
                            Disk disk = row.DataBoundItem as Disk;
                            if (disk == null)
                                continue;
                            Disk dbDisk = My.Disks.Find(disk.Id);
                            My.Disks.Remove(dbDisk);
                        }
                        My.SaveChanges();
                        UpdateTable();
                    }
                break;
                case Tables.Employee:
                    LogicEmployees logEmp = new LogicEmployees();
                    int idEmployee = Convert.ToInt16(dataAll[0, dataAll.CurrentCell.RowIndex].Value);
                    int idPassEmp = Convert.ToInt16(dataAll[8, dataAll.CurrentCell.RowIndex].Value);
                    logEmp.RemoveEmployee(idEmployee, idPassEmp);
                    UpdateTable();

                    //if (result == DialogResult.Yes)
                    //{
                    //    foreach (DataGridViewRow row in dataAll.SelectedRows)
                    //    {
                    //        Employee employee = new Employee();
                    //        if (employee == null)
                    //            continue;
                    //        Employee dbEmployee = My.Employees.Find(employee.Id);
                    //        My.Employees.Remove(dbEmployee);
                    //    }
                    //    My.SaveChanges();
                    //    UpdateTable();
                    //}
                    break;
                default:
                break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forms.AddDisk addDisk = new Forms.AddDisk();
            addDisk.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (FormsAutorisation.Admin.admin == true)
                button8.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            table = Tables.Client;
            UpdateTable();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            table = Tables.Order;
            UpdateTable();
        }
        private void dataClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            table = Tables.Disk;
            UpdateTable();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            table = Tables.Movie;
            UpdateTable();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //dataAll.DataSource = My.Employees.ToList<Employee>();
            table = Tables.Employee;
            UpdateTable();
            //Employee employee = new Employee
            //{
            //    Login = "asd",
            //    Password = "123",
            //    RoleId = 1,
            //};

            //Role role = new Role
            //{
            //    Name = "Директор"
            //};
            //My.Employees.Add(employee);
            ////My.Roles.Add(role);
            //My.SaveChanges();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            My.SaveChanges();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

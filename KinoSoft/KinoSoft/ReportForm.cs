using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoSoft
{
    public partial class ReportForm : Form
    {
        private ReportPDF report = new ReportPDF();

        public ReportForm()
        {
            InitializeComponent();
            this.typeReport.DataSource = Enum.GetValues(typeof(TypeReport));
        }

        private void typeReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            report.Save((TypeReport) typeReport.SelectedItem, dateStart.Value, dateEnd.Value);
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

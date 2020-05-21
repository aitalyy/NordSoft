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
        private string startDate;
        private string endDate;

        public ReportForm()
        {
            InitializeComponent();
            this.typeReport.DataSource = Enum.GetValues(typeof(TypeReport));
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
        }

        private void typeReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            report.Save((TypeReport) typeReport.SelectedItem, startDate, endDate);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            startDate = e.Start.ToShortDateString();
            endDate = e.End.ToShortDateString();
        }
    }
}

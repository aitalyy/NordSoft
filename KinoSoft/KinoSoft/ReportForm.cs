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
            typeReport.DataSource = Enum.GetValues(typeof(TypeReport));
        }

        private void typeReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

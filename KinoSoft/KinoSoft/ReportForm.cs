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
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.typeReport.DisplayMember = "Description";
            this.typeReport.ValueMember = "Value";
            this.typeReport.DataSource = Enum.GetValues(typeof(TypeReport))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }

        private void typeReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            report.Save((TypeReport) typeReport.SelectedIndex, dateStart.Value, dateEnd.Value);
            this.Close();
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

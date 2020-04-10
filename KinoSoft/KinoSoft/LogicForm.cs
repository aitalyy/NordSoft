using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KinoSoft.FormsClient;

namespace KinoSoft
{

    class LogicForm
    {

        public string SearForDel(DataGridView dataGrid, string name)
        {
            LogicClient logCl = new LogicClient();
            int columns = dataGrid.ColumnCount;
            for (int i = 0; i < columns; i++)
            {
                if (dataGrid.Columns[i].HeaderText == name)
                {
                    return Convert.ToString(i);
                } 
            }
            return "error";
        }
    }
}

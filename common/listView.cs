using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace product
{

    public partial class listView : baseForm
    {
        private int id;
        private string query;
        executeQuery ex;
        string textform2;
        public listView()
        {
            InitializeComponent();
            
        }
        public int index2;
        public listView(string query)
        { 
            this.query = query;
            InitializeComponent();


        }
        
        private void myDataGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(myDataGrid1.CurrentRow.Cells[0].Value.ToString());
            textform2  = myDataGrid1.CurrentRow.Cells[1].Value.ToString();
            mymessagbox.mymessagebox("انتخاب شد .");

        }
        public int MyID { get
            {
                return id;
            }
            }
        public string  textform {
            get
            {
                return textform2 ;
            }
        }
        private void listView_Load(object sender, EventArgs e)
        {
      
            ex = new executeQuery();
            ex.report(query ,myDataGrid1  );
        }

        private void mytexbox1_TextChanged(object sender, EventArgs e)
        {
            if (mytexbox1.ForeColor == Color.Black)
              ex.dataview1.RowFilter = "convert(" + myDataGrid1 .Columns[index2].DataPropertyName + ",System.String) like '%" + mytexbox1 .Text + "%'";

        }

        private void myDataGrid1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            mytexbox1 .ForeColor = SystemColors.GrayText;
            index2 = e.ColumnIndex;
            mytexbox1 .Text = "فیلتر بر اساس :" + myDataGrid1 .Columns[index2].HeaderText;
        }

        private void mytexbox1_Enter(object sender, EventArgs e)
        {
            mytexbox1 .ForeColor = Color.Black;
            mytexbox1 .Text = string.Empty;
            mytexbox1 .Focus();
        }

        private void mytexbox1_Leave(object sender, EventArgs e)
        {

             mytexbox1 .ForeColor = SystemColors.GrayText;
             mytexbox1 .Text = "فیلتر بر اساس :" + myDataGrid1 .Columns[index2].HeaderText;
            mytexbox1 .Focus();
        }

        private void mytexbox1_Click(object sender, EventArgs e)
        {
            mytexbox1_Enter(null, null);
        }
    }
}

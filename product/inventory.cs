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
    public partial class inventory : Form
    {
        public inventory()
        {
            InitializeComponent();
        }
        executeQuery ex;
        private void inventory_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txttitle .Text == string.Empty)
            {
                MessageBox.Show("لطفا نام کالا را وارد کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                txttitle .Focus();
            }
            string s = "insert into  [dbo].[inventory] (title,address,tel) values (N'"+txttitle.Text +"',N'"+ txtaddress.Text +"',"+masktel.Text +");";
            ex = new executeQuery();
            ex.executnonQuery(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (TextBox a in Controls)
                a.Text = string.Empty;

            btnDelet.Enabled = panel2.Visible = btnEdit.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string a = "select * from [dbo].[inventory]" ;
            ex = new executeQuery();
            ex.report(a, dataGridView1);
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {

            string d = "delete inventory where code=" + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(d);
            MessageBox.Show("حدف انجام شد .");
            btnDelet.Enabled = btnEdit.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string b = "update inventory set title=N'" + txttitle .Text + "',address =N'" + txtaddress.Text +"', tel="+ masktel.Text + " where inventory.code=" + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(b);

            MessageBox.Show("ویرایش انجام شد .");
            btnDelet.Enabled = btnEdit.Enabled = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            txttitle .Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtaddress .Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            masktel .Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            btnDelet.Enabled = btnEdit.Enabled = true;
            panel2.Visible = false;
        }
    }
}

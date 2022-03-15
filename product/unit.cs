using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace product
{
    public partial class unit : Form
    {
        executeQuery ex;
        public unit()
        {
            InitializeComponent();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (txtname .Text == string.Empty)
            {
                MessageBox.Show("لطفا نام کالا را وارد کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                txtname.Focus();
            }
            string s = "insert into [unitt]  values (N'" + txtname.Text + "');";
            ex = new executeQuery();
            ex.executnonQuery(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            ex = new executeQuery();
            string a = "select * from unitt ";
            ex.report(a, dataGridView1);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            btnDelet.Enabled  = panel2.Visible = btnEdit .Enabled  = false;
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string b = "update [unitt] set name=N'" + txtname.Text + "' where [code]=" + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(b);


            MessageBox.Show("ویرایش انجام شد ");

        }

        private void btnDelet_Click(object sender, EventArgs e)
        {

                string d = "delete unitt where code = " + dataGridView1.CurrentRow.Cells[0].Value;
                ex = new executeQuery();
                ex.executnonQuery(d);




        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = true;
            txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
             btnDelet.Enabled  = btnEdit.Enabled  = true;
            panel2.Visible = false;
        }

        private void unit_Load(object sender, EventArgs e)
        {
            myunituserControl1.Mytitle = "name";
            myunituserControl1.MyFormname  = "واحد مصرف";
            myunituserControl1.MyDB  = "unitt";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void myunituserControl1_Mytextchange_event(object sender, EventArgs e)
        {

        }
    }
}

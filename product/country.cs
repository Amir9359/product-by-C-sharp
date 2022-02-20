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
    public partial class country : baseForm
    {
        public country()
        {
            InitializeComponent();
        }
        executeQuery ex;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void country_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام کشور را وارد کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                txtpassword.Focus();
            }

            string s = "insert into [dbo].[country] (title,parentcode,levelcode) values (N'" + txtpassword.Text + "',NULL,1)";
            ex = new executeQuery();
            ex.executnonQuery(s);
            MessageBox.Show("درج انجام شد .");
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            string d = "delete [dbo].[country] where code= " + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(d);
            MessageBox.Show("حذف انجام شد . ", "Alert!", MessageBoxButtons.OK);
            label1.Visible = textBox1.Visible = btnDelet.Enabled = btnEdit.Enabled = false;
            txtpassword.Text = "";

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string b = "update [dbo].[country]  set title=N'" + txtpassword.Text +"'";
            ex = new executeQuery();
            ex.executnonQuery(b);

            MessageBox.Show("ویرایش انجام شد . ", "Alert!", MessageBoxButtons.OK);
            label1.Visible = textBox1.Visible = btnDelet.Enabled = btnEdit.Enabled = false;
            txtpassword.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = textBox1.Visible = panel2.Visible = true;
            string a = "select code,title  from country where levelcode=1";
            ex = new executeQuery();
            ex.report(a, dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = textBox1.Visible = btnDelet.Enabled = panel2.Visible = btnEdit.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            textBox1.Text = dataGridView1.CurrentRow.Cells [0].Value .ToString();
            txtpassword .Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            btnDelet.Enabled = btnEdit.Enabled = true;
            panel2.Visible = false;
        }
    }
}

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
    public partial class city : baseForm 
    {
        public city()
        {
            InitializeComponent();
        }
        executeQuery ex;
        private void province_Load(object sender, EventArgs e)
        {
            string a = "select [dbo].[country].code,[dbo].[country].title from country ";
            ex = new executeQuery();
            ex.set(a, comboBox1, "title", "code");

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (txtpassword.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام شهر را وارد کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                txtpassword.Focus();
            }

            string s = "insert into [dbo].[country] (title,parentcode,levelcode) values (N'" + txtpassword.Text + "'," + comboBox1.SelectedValue + ",2)";
            ex = new executeQuery();
            ex.executnonQuery(s);
            MessageBox.Show("درج انجام شد .");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            txtpassword .Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1 .Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1 .Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           label1 .Visible = textBox1.Visible = btnDelet.Enabled = btnEdit.Enabled = true;
            panel2.Visible = false;


        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            string d = "delete [dbo].[country] where code= " + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(d);
            MessageBox.Show("حذف انجام شد . ", "Alert!", MessageBoxButtons.OK);
            label1.Visible = textBox1.Visible= btnDelet.Enabled = btnEdit.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string b = "update [dbo].[country]  set title=N'" + txtpassword .Text + "',parentcode="+comboBox1.SelectedValue +" where [code]=" + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(b);

            MessageBox.Show("ویرایش انجام شد . ", "Alert!", MessageBoxButtons.OK);
            label1.Visible = textBox1.Visible=btnDelet.Enabled = btnEdit.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = textBox1.Visible=panel2.Visible = true;
            string a = "select [dbo].[country].code,[dbo].[country].title,parentcode,levelcode  from city ";
            ex = new executeQuery();
            ex.report(a, dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnDelet.Enabled = panel2.Visible = btnEdit.Enabled =  false;
            txtpassword.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


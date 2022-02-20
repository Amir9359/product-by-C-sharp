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
    public partial class province : baseForm
    {
        public province()
        {
            InitializeComponent();
        }
        executeQuery ex;
        private void province_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtcity.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام استان را وارد کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                txtcity.Focus();
            }

            string s = "insert into [dbo].[country] (title,parentcode,levelcode) values (N'" + txtcity.Text + "',"+comboBox1.SelectedValue + ",3)";
            ex = new executeQuery();
            ex.executnonQuery(s);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            txtcity.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtcode .Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1  .Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtcode.Visible =label2.Visible =btnDelet.Enabled = btnEdit.Enabled = true;
            panel2.Visible = false;


        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            string d = "delete [dbo].[country] where code = " + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(d);
            MessageBox.Show("حذف انجام شد . ", "Alert!", MessageBoxButtons.OK);
            btnDelet.Enabled = btnEdit.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string b = "update [dbo].[country]  set title=N'" + txtcity.Text + "',parentcode="+comboBox1.SelectedValue +" where [code]=" + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(b);

            MessageBox.Show("ویرایش انجام شد . ", "Alert!", MessageBoxButtons.OK);
            btnDelet.Enabled = btnEdit.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string a = "select [dbo].[country].code,[dbo].[country].title,parentcode from [province] left join city on province.provincecode=city.code";
            ex = new executeQuery();
            ex.report(a, dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnDelet.Enabled = panel2.Visible = btnEdit.Enabled = false;
            txtcity.Text = string.Empty;
            txtcode.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (txtcity.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام استان را وارد کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                txtcity.Focus();
            }

            string s = "insert into [dbo].[country] (title,parentcode,levelcode) values (N'" + txtcity.Text + "',"+comboBox1.SelectedValue +",3)";
            ex = new executeQuery();
            ex.executnonQuery(s);
            MessageBox.Show("درج انجام شد");
        }

        private void city_Load(object sender, EventArgs e)
        {
            string c = "select title,code from [dbo].[country] where levelcode=2 ";//select country.[title],country.code from country where parentcode
            ex = new executeQuery();
            ex.set(c,comboBox1   , "title", "code");
            string d = "select title,code from [dbo].[country] where levelcode=3";
            ex = new executeQuery();
            ex.set(d, txtcity , "title", "code");
            txtcity.SelectedValue = -1;
            comboBox1.SelectedValue = -1;
        }

 

        private void comboBox1_Leave(object sender, EventArgs e)
        {
           
            var index = comboBox1.SelectedValue;
            ex = new executeQuery();
            ex.set("select country.[title],country.code from country where parentcode=" + index, txtcity, "title", "code");

        }


    }
}


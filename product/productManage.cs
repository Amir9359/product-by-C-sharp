using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace product
{
    
    public partial class productManage : Form
    {
        public  productManage()
        {
            InitializeComponent();
        }
        private executeQuery ex;

        private void btninsert_Click(object sender, EventArgs e)
        {
            if(txtname.Text==string.Empty )
            {
                MessageBox.Show("لطفا نام کالا را وارد کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                txtname.Focus();
            }
            string s= "insert into [product] (proname,unit,[product].usercode) values (N'" + txtname .Text +"' ,"+ cmdunit .SelectedValue +","+cmdUser.SelectedValue +");";
           ex = new executeQuery();
            ex.executnonQuery(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            string a = "select product.code ,Product.[proname] ,unitt.[name],[product].usercode from product left join unitt on  Product.unit=unitt.code  left join [user] on product.usercode=[user].code";
            ex = new executeQuery();
            ex.report(a, dataGridView1);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            btnDelet.Enabled = panel3.Visible = btnEdit.Enabled = false;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string b= "update [dbo].[Product] set proname=N'"+txtname.Text +"', unit ="+ cmdunit.SelectedValue +", usercode="+cmdUser.SelectedValue +" where [code]="+ dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(b);
          
            button1_Click(null, null);
            btnDelet. Enabled   = btnEdit.Enabled  = false;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            SqlConnection conn = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand("select * from product where code= " + dataGridView1.CurrentRow.Cells[0].Value, conn);

            conn.Open();
            SqlDataReader c = com.ExecuteReader();

            if (c.Read())
            {

                txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cmdUser.SelectedValue = c[3].ToString();
                cmdunit.SelectedValue = c[2].ToString();
                
                btnDelet.Enabled = btnEdit.Enabled = true;
                panel3.Visible = false;
            }
            c.Close();
            conn.Close();
        }
        private void btnDelet_Click(object sender, EventArgs e)
        {

            string d = "delete [Product] where code=" + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(d);
            button1_Click(null, null);
            btnDelet.Enabled  = btnEdit.Enabled  = false;

        }

        private void productManage_Load(object sender, EventArgs e)
        {
            string a = "select * from unitt ";
            ex = new executeQuery();
            ex.set (a, dataGridView1,cmdunit , "name", "code");

            string b = "select * from [user] ";
            ex = new executeQuery();
            ex.set(b, dataGridView1,cmdUser  , "username", "code");
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellDoubleClick(null, null);
        }

        private void myunituserControl1_Load(object sender, EventArgs e)
        {

        }

        private void myunituserControl2_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

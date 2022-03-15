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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }
        executeQuery ex;

        private void user_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ex = new executeQuery();
           
            object  a = ex.executscaler ("select count(username ) from [user] where [username]='"+txtusername.Text +"'");
            if (txtpassword.Text !=txtrepassword.Text )
            {
                MessageBox.Show("تکرار کلمه عبور را درست وارد کنید!", "Alert!", MessageBoxButtons.OK);
                txtrepassword.Focus();
                txtrepassword.SelectAll() ;
                return ;
            }
            if (int.Parse(a.ToString()) <= 0)
            {
                MessageBox.Show("کد کاربری تکراری است! ", "Alert!", MessageBoxButtons.OK);
                txtusername.Focus();
                txtusername .SelectAll();
                return;
            }
            ex = new executeQuery();
            ex.executnonQuery ("insert into [user] ([name],family,username,[password]) values (N'" + txtnname.Text + "',N'" + txtfamily.Text + "','" + txtusername.Text + "','" + txtpassword.Text + "');");
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand();


            com.CommandText = "select [password] from [user] where username='" + txtusername.Text + "'";
            con.Open();
            com.Connection = con;


            SqlDataReader x = com.ExecuteReader();
            if (x.Read())
            {
                if (txtpassword.Text != x[0].ToString())
                {
                    MessageBox.Show("رمز اشتباه است. ", "Alert!", MessageBoxButtons.OK);
                }

                else
                {

                    string b = "delete [dbo].[user] where code=" + txtcode .Text  ;
                    ex = new executeQuery();
                    ex.executnonQuery(b);

               
                    btnDelet.Enabled = btnEdit.Enabled = false;
                    MessageBox.Show("حذف انجام شد . ", "Alert!", MessageBoxButtons.OK);
                }
            }


            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string a = "select  [user].code,[user].[name],[user].family,username  from [user]  ";
            ex = new executeQuery();
            ex.report(a, dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
 
            txtusername.ReadOnly = btnDelet.Enabled = panel2.Visible = btnEdit.Enabled = label2.Visible = txtcode.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand();


             com.CommandText = "select [password] from [user] where username='" + txtusername.Text + "'";
            con.Open();
            com.Connection = con;
 
            SqlDataReader x = com.ExecuteReader ();
            if (x.Read())
            {
                if (txtpassword.Text != x[0].ToString())
                {
                    MessageBox.Show("رمز اشتباه است. ", "Alert!", MessageBoxButtons.OK);
                }

                else
                {

                    string b = "update [dbo].[user] set [name]=N'" + txtnname.Text + "', family=N'" + txtfamily.Text +  "'  where [code]=" + dataGridView1.CurrentRow.Cells[0].Value;
                    ex = new executeQuery();
                    ex.executnonQuery(b);

                
                    btnDelet.Enabled = btnEdit.Enabled = false;
                    MessageBox.Show("ویرایش انجام شد . ", "Alert!", MessageBoxButtons.OK);
                }
            }


           con.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("لطفا برای اعمال ویرایش و حذف رمز عبور خود را وارد کنید ", "Alert!", MessageBoxButtons.OK);
            txtcode.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtnname .Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtfamily .Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtusername .Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
         
            btnDelet.Enabled = btnEdit.Enabled = true;
            label6.Visible=txtrepassword.Visible = panel2.Visible = false;
           txtusername.ReadOnly= label2.Visible = txtcode.Visible = true;
        }
    }
}

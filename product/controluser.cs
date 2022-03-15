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
using System.Security.Cryptography;
using System.IO;

namespace product
{
    public partial class controluser : Form
    {
        public controluser()
        {
            InitializeComponent();
            
        }
        
        executeQuery ex;
        private  system p = new system();
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '*')
                txtpassword.PasswordChar = txtusername.PasswordChar;
            else
                txtpassword.PasswordChar = '*';
        }

        private void controluser_Load(object sender, EventArgs e)
        {
         txtusername.Text = Properties.Settings.Default.UserCode ;
         txtpassword.Text = Properties.Settings.Default.Password;
         checkBox1.Checked = Properties.Settings.Default.Remmember ;
         

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand();

            conn.Open();

            com.CommandText = "select * from [dbo].[user] where [username]='" + txtusername.Text + "' and [password]='" + txtpassword .Text + "'";
            com.Connection = conn;
            SqlDataReader a = com.ExecuteReader();
            
            if (a .Read())
            {

                p.toolStripLabel5.Text = a[1].ToString() + " " + a[2];
                if(checkBox1.Checked ==true )
                {
                    Properties.Settings.Default.UserCode  = txtusername.Text ;
                    Properties.Settings.Default.Password   = txtpassword .Text;
                    Properties.Settings.Default.Remmember  = checkBox1.Checked;
                    

                }
                else
                {
                    Properties.Settings.Default.UserCode = "";
                    Properties.Settings.Default.Password ="";
                    Properties.Settings.Default.Remmember = false ;

                }
                Properties.Settings.Default.Save();
                progressBar1.Visible = true;
               pictureBox3 .Visible = timer1.Enabled = !(pictureBox2.Visible=false );

                staticuser.username = a[3].ToString();
                staticuser.usercode  = a[0].ToString();
                staticuser.password = a[4].ToString();
                staticuser.family  = a[2].ToString();
                staticuser.name = a[1].ToString();
            }
            else
            {
                MessageBox.Show("کد کاربری یا رمز عبور اشتباه است! ", "Alert!", MessageBoxButtons.OK);
                txtusername.Focus();
                txtusername.SelectAll();
                return;

            }
            conn.Close();
 
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1 .Value  <100)
            {
                progressBar1.Value += 5;
            }
            else
            {
                Hide();
                p.Show();
            }
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

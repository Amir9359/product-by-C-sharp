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
    public partial class ChangePassword : baseForm
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        executeQuery ex; 
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

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txtusername.Text = staticuser.usercode;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if(txtnewpassword.Text!=txtrepassword .Text )
            {
                MessageBox.Show("تکرار کلمه عبور را درست وارد کنید!", "Alert!", MessageBoxButtons.OK);
                txtrepassword.Focus();
                txtrepassword.SelectAll();
                return;

            }

            if(txtpassword.Text ==staticuser.password )
            {
                ex = new executeQuery();
                ex.executnonQuery("update [user] set [password] ='"+txtnewpassword .Text +"' where username ='"+staticuser.usercode +  "'");
                MessageBox.Show("ویرایش انجام شد .", "ویرایش" ,MessageBoxButtons.OK);
            }
            else  if (txtpassword.Text != staticuser.password)
            {
                MessageBox.Show("کد عبور قبلی درست نیست.", "Alert!", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}

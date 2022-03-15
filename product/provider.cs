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
    public partial class supplier : baseForm
    {
        public supplier()
        {
            InitializeComponent();
        }
        executeQuery ex;
        private void button5_Click(object sender, EventArgs e)
        {
            if (txtnname .Text == string.Empty || txtfamily .Text == string.Empty || txtphone .Text == string.Empty)
            {
                
                MessageBox.Show("لطفا اطلاعات را کامل وارد کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnname.Focus();
                return;
          
            }
            string s = "insert into  [dbo].[supplier] (name,family,province,city,address,telphone) values (N'" + txtnname.Text + "',N'" + txtfamily.Text + "'," + cmdprovince.MyID + "," + cmdcity.MyID  + ",N'" + txtaddress.Text + "'," + txtphone.Text + ");";
            ex = new executeQuery();
            ex.executnonQuery(s);
            MessageBox.Show("درج انجام شد . ");
        }

        private void supplier_Load(object sender, EventArgs e)
        {

            ex = new executeQuery();
            ex.bindingsource("select * from [dbo].[supplier] ", bindingNavigator1, dataGridView1);
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            string d = "delete supplier where codesup= " + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(d);
            MessageBox.Show("حذف انجام شد . ");
            btnDelet.Enabled = btnEdit.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Visible=txtcode.Visible = btnDelet.Enabled = panel2.Visible = btnEdit.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
           

            panel2.Visible = true;
            string a = "select supplier.codesup,supplier.name+ ' ' +supplier.family as fullname,provincetitle.title  as province,citytitle.title  as city ,supplier.address,supplier.telphone   from supplier inner join country as provincetitle on supplier.province=provincetitle.code inner join country as citytitle on supplier.city =citytitle .code";
            ex = new executeQuery();
            ex.bindingsource(a, bindingNavigator1, dataGridView1);


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string b = "update [supplier] set name=N'" + txtnname.Text + "',family =N'" + txtfamily.Text + "', city=" + cmdcity.MyID  + ",province=" + cmdprovince.MyID  + ",address=N'" + txtaddress.Text + "', telphone=" + txtphone.Text + " where codesup=" + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(b);
            mymessagbox.mymessagebox("ویرایش انجام شد . ");

            btnDelet.Enabled = btnEdit.Enabled = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            SqlConnection con = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand("select * from supplier",con );
            con.Open();
        
            SqlDataAdapter da = new SqlDataAdapter(com );
            DataTable t1 = new DataTable();

  
         
 
            da.Fill(t1);
            com.ExecuteNonQuery();
    
            int index1 = dataGridView1.CurrentRow.Index;
            txtcode.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtnname.Text = t1.Rows[index1][1].ToString();
            txtfamily.Text = t1.Rows[index1][2].ToString();
            cmdprovince.Text  = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmdcity.Text =dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtaddress .Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtphone .Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            btnDelet.Enabled = btnEdit.Enabled = true;
            panel2.Visible = false;
            con.Close();

        }



        private void cmdcity_Mytextchange_event(object sender, EventArgs e)
        {
            cmdprovince.MyDB = "country where parentcode=" + cmdcity.MyID;
        }

        private void cmdcity_Load(object sender, EventArgs e)
        {

        }

        private void cmdprovince_Load(object sender, EventArgs e)
        {

        }

        private void cmdprovince_Mytextchange_event(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ex.dataview1.RowFilter = "convert(codesup,System.String) like '%" + textBox1.Text + "%'";
                    break;
                case 1:
                    ex.dataview1.RowFilter = "fullname like '%" + textBox1.Text + "%'";
                    break;
                case 2:
                    ex.dataview1.RowFilter = "city like '%" + textBox1.Text + "%'";
                    break;
                case 3:
                    ex.dataview1.RowFilter = "province like '%" + textBox1.Text + "%'";
                    break;
                case 4:
                    ex.dataview1.RowFilter = "address like '%" + textBox1.Text + "%'";
                    break;
                case 5:
                    ex.dataview1.RowFilter = "telphone like '%" + textBox1.Text + "%'";
                    break;

            }
        }




        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox1.Focus();
        }
    }
}


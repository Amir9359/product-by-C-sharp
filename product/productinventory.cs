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
    public partial class productinventory : Form
    {
        public productinventory()
        {
            InitializeComponent();
        }
        executeQuery ex;

        private void button5_Click(object sender, EventArgs e)
        {


            string time = DateTime.Now.ToShortTimeString();
            bool falgenum = false;

            if (cmdproduct  .Text == string.Empty)
            {
                MessageBox.Show("لطفا کالا را انتخاب کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                cmdproduct.Focus();
            }
            ex = new executeQuery();
            if ( ex.executscaler("select number from productinventory  where product =" + cmdproduct.SelectedValue + " and inventory =" + cmdinventory.SelectedValue) !=null ) 
            {
                ex = new executeQuery();
                int InventoryNum = int.Parse(ex.executscaler("select number from productinventory  where product =" + cmdproduct.SelectedValue + " and inventory =" + cmdinventory.SelectedValue).ToString());
                if (InventoryNum > 0)
                {
                    int newNum = InventoryNum + int.Parse(txtnumber.Text);
                    ex = new executeQuery();
                    ex.executnonQuery("update productinventory set number =" + newNum + " where product = " + cmdproduct.SelectedValue + " and inventory = " + cmdinventory.SelectedValue);
                    MessageBox.Show("این کالا قبلا در این انبار ثبت شده است .");
                    MessageBox.Show(" تعداد کالا در انبار  " + cmdinventory.SelectedValue + " ویرایش شد. ");

                }
              }
            else
            {
                string s = $"insert into [dbo].[productinventory] (Product,inventory,number,KeapingPlace,ProductPoint) values ({ cmdproduct.SelectedValue },{cmdinventory.SelectedValue },{txtnumber.Text },{cmdKeapingPlace .SelectedValue },{txtPointProduct .Text })";
                ex = new executeQuery();
                ex.executnonQuery(s);
                MessageBox.Show("درج انجام شد .");

            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            SqlConnection conn = new SqlConnection("data Source=DESKTOP-FP1JKF9\\AMIR; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand("select * from productinventory where code= " + dataGridView1.CurrentRow.Cells[0].Value, conn);
  
            conn.Open();
            SqlDataReader c = com.ExecuteReader();
            
            if (c.Read())
            {
                txtcode.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cmdproduct.SelectedValue = c[1];
                cmdinventory.SelectedValue = c[2];
                txtnumber .Text = c[3].ToString();

            }


            c.Close();

            btnDelet.Enabled = btnEdit.Enabled = true;
            panel2.Visible = false;
            conn.Close();
            label2.Visible = txtcode.Visible = true;
        }

        private void productinventory_Load(object sender, EventArgs e)
        {


            string a = "select * from product ";
            ex = new executeQuery();
            ex.set(a, cmdproduct, "proname", "code");
            string b = "select * from inventory ";
            ex = new executeQuery();
            ex.set(b,  cmdinventory, "title", "code");
            string c = "KeapingPlaceSelect";
            ex = new executeQuery();
            ex.set(c, cmdKeapingPlace , "title", "code",CommandType.StoredProcedure );


        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string a = "select  [dbo].[productinventory].code,[dbo].[product].proname,[dbo].[inventory].title,[productinventory].number,KeapingPlace.title as KeapingPlacetitle,ProductPoint  from [dbo].[productinventory] left join [dbo].[product] on [dbo].[productinventory].product=product.code left join [inventory] on [dbo].[productinventory].inventory=inventory.code left join [KeapingPlace] on [dbo].[productinventory].KeapingPlace=KeapingPlace.code  ";
            ex = new executeQuery();
            ex.report(a, dataGridView1);

        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            string d = "delete [dbo].[productinventory] where code = " + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(d);
            btnDelet.Enabled = btnEdit.Enabled = false;
            MessageBox.Show("حذف انجام شد .");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ex = new executeQuery();
            if (!string.IsNullOrEmpty(ex.executscaler("select number from productinventory  where product =" + cmdproduct.SelectedValue + " and inventory =" + cmdinventory.SelectedValue).ToString()))
            {
                ex = new executeQuery();
                int InventoryNum = int.Parse(ex.executscaler("select number from productinventory  where product =" + cmdproduct.SelectedValue + " and inventory =" + cmdinventory.SelectedValue).ToString());
                if (InventoryNum > 0)
                {
                    int newNum = InventoryNum + int.Parse(txtnumber.Text);
                    ex = new executeQuery();
                    ex.executnonQuery("update productinventory set number =" + newNum + " where product = " + cmdproduct.SelectedValue + " and inventory = " + cmdinventory.SelectedValue);
                    MessageBox.Show("این کالا قبلا در این انبار ثبت شده است .");
                    MessageBox.Show(" تعداد کالا در انبار  " + cmdinventory.SelectedValue + " ویرایش شد. ");

                    string d = "delete [dbo].[productinventory] where code = " + dataGridView1.CurrentRow.Cells[0].Value;
                    ex = new executeQuery();
                    ex.executnonQuery(d);

                }
            }

            else
            {
                string b = "update [dbo].[productinventory]  set product=" + cmdproduct.SelectedValue + ",ProductPoint=" + txtPointProduct .Text  + ",KeapingPlace=" + cmdKeapingPlace .SelectedValue  + ",inventory=" + cmdinventory.SelectedValue + ", number=" + txtnumber.Text + "  where [code]=" + dataGridView1.CurrentRow.Cells[0].Value;
                ex = new executeQuery();
                ex.executnonQuery(b);


                MessageBox.Show("ویرایش انجام شد .");
            }

            btnDelet.Enabled = btnEdit.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtcode.Text = string.Empty;
            cmdproduct.SelectedValue = -1;
            cmdinventory.SelectedValue = -1;
      

            btnDelet.Enabled = panel2.Visible = btnEdit.Enabled =label2.Visible = txtcode.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void calendarcontrol1_Load(object sender, EventArgs e)
        {

        }

        private void cmdinventory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

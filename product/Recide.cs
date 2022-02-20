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
    public partial class Recide : baseForm
    {
        public Recide()
        {
            InitializeComponent();
        }
        executeQuery ex;
        int i = 1, j = 0;
        int countDeletNum=0;
        public int index2;
        string id;
        int lastnumber;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Recide_Load(object sender, EventArgs e)
        {
            string a = "select * from inventory ";
            ex = new executeQuery();
            ex.set(a,  cmdinventory , "title", "code");

            string b = "select [codesup],[supplier].[name]+' '+[supplier].family as supplername from [supplier] ";
            ex = new executeQuery();
            ex.set(b, cmdsupplier , "supplername", "codesup");
            cmdproduct.Enabled = false;
            txtDate.SetText  = staticuser.date;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Add(i, txtunmber.Text, cmdproduct.MyID, cmdproduct.MyText, cmdunit.MyID, cmdunit.MyText);
            i++;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            i = 1;
            if (cmdproduct.MyText  == string.Empty)
            {
     
                MessageBox.Show("لطفا کالا را وارد کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                txtRecidenumber .Focus();
            }

            string s = "insert into [Recide] ([Recide].[date],recideNumber,suppliercode ,[inventorycode]) values ('" + cmdDate.mycurrentdate    +"'," + txtRecidenumber.Text + ","+ cmdsupplier.SelectedValue + ","+cmdinventory .SelectedValue + ");";
            ex = new executeQuery();
            var a = ex.executnonQuery(s);

            if (a>0)
            {
                ex = new executeQuery();
                var NumberInventory = ex.executscaler("select number  from productinventory  where inventory=" + cmdinventory.SelectedValue + "  and  product =" + cmdproduct.MyID);


                for (int i=0; i<=dataGridView1.Rows.Count -1 ;i++)
                {

                    ex = new executeQuery();
                    var maxval = ex.executscaler("select max(code) from [dbo].[Recide]");
                    string productdb = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string unitdb = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    int txtnumberdb = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());

                    ex = new executeQuery();
                      if( ex.executnonQuery("insert into recideDetailes ([recideCodeDetail],[product], [unit],[number])values (" + maxval + "," + productdb + "," + unitdb + "," + txtnumberdb + ")") >0)
                       {

                        ex = new executeQuery();
                        var NumberRecide = ex.executscaler("select sum(number)  from  recideDetailes  inner join recide on recideDetailes .recideCodeDetail =Recide .code  where recideDetailes.product =" +cmdproduct .MyID +" and  inventorycode =" + cmdinventory.SelectedValue  );


                        ex = new executeQuery();
                         if (!string.IsNullOrEmpty(NumberRecide.ToString()) && !string.IsNullOrEmpty(NumberInventory.ToString()))
                          {
                            int newNum = int.Parse(NumberInventory.ToString()) + int.Parse(NumberRecide.ToString());
                            ex.executnonQuery("update  productinventory set number =" + newNum +" where product =" + cmdproduct.MyID + " and  inventory=" + cmdinventory.SelectedValue);
                            MessageBox.Show(".تغییر تعداد کالا های انبار انجام شد ");
                        }
                    }

                    }

       
                    MessageBox.Show("درج انجام شد ");
                    
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {


         cmdproduct.Enabled = btndeletedeltail.Visible =  btnDelet.Visible = btnEdit.Visible = txtcode.Visible = label8.Visible = panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string q = "select Recide.[code],Recide.[date],[recideNumber],supplier.name +' '+supplier.family as suppliername,inventory.title,(select count( recideDetailes.code) from recideDetailes where recideDetailes.recideCodeDetail  =Recide.code )as number from [dbo].[Recide] left join supplier  on recide.suppliercode=supplier.codesup left join inventory on recide.inventorycode=inventory.code left join recideDetailes on recide.code=recideDetailes.recideCodeDetail";
            ex = new executeQuery();
            ex.bindingsource(q,bindingNavigator1  ,dataGridView2 );

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void dataGridView2_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.ForeColor =SystemColors.GrayText ;
            index2 = e.ColumnIndex;
            textBox2.Text= "فیلتر بر اساس :"+    dataGridView2.Columns[index2].HeaderText;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.ForeColor == Color.Black )
                ex.dataview1.RowFilter = "convert(" + dataGridView2.Columns[index2].DataPropertyName + ",System.String) like '%" + textBox2.Text + "%'";


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
 
            textBox2.ForeColor = SystemColors.GrayText  ;
            textBox2.Text = "فیلتر بر اساس :" + dataGridView2.Columns[index2].HeaderText;
            textBox2.Focus();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
            textBox2.Text = string.Empty;
            textBox2.Focus();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            countDeletNum = 0;
           btndeletedeltail .Visible = btnDelet.Enabled  = btnEdit.Enabled  = true;
            do
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    dataGridView1.Rows.Remove(item);
                }


            } while (dataGridView1.Rows.Count > 0);

            SqlDataReader a;
            txtcode.Visible = label8.Visible =!( panel2.Visible= false );
             id= dataGridView2.CurrentRow.Cells[0].Value.ToString();

            ex = new executeQuery();
            a = ex.executeReader("select Recide.suppliercode,inventory.code  from recide inner join inventory on Recide.inventorycode = inventory.code  where Recide.code=" + id  );
            if(a.Read())
            {
                txtcode.Text = id;
                txtDate.SetText  = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                txtRecidenumber.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();

                cmdsupplier.SelectedValue = a[0];
                cmdinventory.SelectedValue = a[1];
            }
            a.Close();
           

            ex = new executeQuery();
            a = ex.executeReader("select recideDetailes.code ,recideDetailes.number ,recideDetailes .product ,Product.proname  ,recideDetailes .unit ,unitt.name from recideDetailes inner join Product on recideDetailes.product =Product.code inner join unitt on recideDetailes.unit =unitt .code where recideCodeDetail=" + id);

            while (a.Read ())
            {
                dataGridView1.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), a[5].ToString());

            }
            a.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            i = 0;
            if (txtRecidenumber.Text == string.Empty)
            {
                MessageBox.Show("لطفا کد رسید را وارد کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                txtRecidenumber.Focus();
            }

            //  اپدیت تعداد کالا های رسید دیتیل  
            ex = new executeQuery();
            var NumberInventory = ex.executscaler("select number from productinventory  where inventory=" + cmdinventory.SelectedValue + "  and  product =" + cmdproduct.MyID);

            ex = new executeQuery();
            lastnumber =int.Parse ( ex.executscaler("select number  from  recideDetailes  inner join recide on recideDetailes.recideCodeDetail =Recide .code  where recideDetailes.product =" + cmdproduct.MyID + " and  inventorycode=" + cmdinventory.SelectedValue).ToString()  + " and recideCodeDetail=" +txtcode.Text );

            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {


            }
            ex = new executeQuery();
            if (!string.IsNullOrEmpty(NumberInventory.ToString()) && !string.IsNullOrEmpty(lastnumber.ToString()))
            {
                int newInventoryNum = int.Parse(NumberInventory.ToString()) - lastnumber;
                int newnum = int.Parse(NumberInventory.ToString()) + int.Parse(txtunmber.Text);

                ex.executnonQuery("update   productinventory set number =" + newnum + " where recideDetailes.product = " + cmdproduct.MyID + " and  inventorycode = " + cmdinventory.SelectedValue);
                MessageBox.Show(".تغییر تعداد کالا های انبار انجام شد ");

            }
            //  اپدیت رسید 
            string s = "update  [Recide]  set [Recide].[date]='" + cmdDate .mycurrentdate + "',recideNumber=" + txtRecidenumber.Text + ", suppliercode =" + cmdsupplier.SelectedValue + ",[inventorycode]=" + cmdinventory.SelectedValue + "where  Code=" + id;
            ex = new executeQuery();

    
            var result = ex.executnonQuery(s);
            int  result2=0;

            //  اپدیت رسید دیتیل 
            if (result  > 0)
            {

                DataTable t3 = new DataTable();
                ex = new executeQuery();
                ex.executnonQuery("delete * from [recideDetailes]  where recideCodeDetail =" + id );


                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    string productdb = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string unitdb = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string txtnumberdb = dataGridView1.Rows[i].Cells[1].Value.ToString();

                        ex = new executeQuery();
                        result2 = ex.executnonQuery("insert into  recideDetailes  ([recideCodeDetail],[product], [unit],[number]) values (" + id + "," + productdb + "," + unitdb + "," + txtunmber.Text + ");");
                    
                }
                if (result2 > 0)
                    MessageBox.Show("ویرایش انجام شد ");

            }
            
        }

        private void ViewProductDetail(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            if (e.ColumnIndex == 5)
            {
                veiwDataGrideproduct veiw = new veiwDataGrideproduct(id);
                veiw.Show();
            }
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {

            ex = new executeQuery();
            ex.executnonQuery("delete from [recideDetailes]  where recideCodeDetail =" + id);

                ex = new executeQuery();
                ex.executnonQuery("delete  from Recide where recide.code =" + id);

            MessageBox.Show("حذف انجام شد ");

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdproduct.MyText  = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmdunit.MyText = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtunmber.Text  = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            btndeletedeltail.Visible = true;
        }

        private void cmdunit_Mytextchange_event(object sender, EventArgs e)
        {

        }

        private void myunituserControl2_Load(object sender, EventArgs e)
        {

        }

        private void cmdproduct_Mytextchange_event(object sender, EventArgs e)
        {

        }

        private void cmdunit_Mytextchange_event_1(object sender, EventArgs e)
        {

        }

        private void cmdinventory_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmdproduct.MyDB = "productinventory inner join product on productinventory.product=product.code  where productinventory.inventory=" + cmdinventory.SelectedValue;
            cmdproduct.Enabled = true;
        }

        private void btndeletedeltail_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index );
            countDeletNum++;
        }
    }
}

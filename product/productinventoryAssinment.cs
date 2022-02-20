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
    public partial class inventoryAssinment : Form
    {
        public inventoryAssinment()
        {
            InitializeComponent();
        }
        executeQuery ex;
        int i = 1;
        int countDeletNum = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            bool falgenum = false;
            i = 1;

            if (cmdproduct.Text == string.Empty)
            {
                MessageBox.Show("لطفا کالا را انتخاب کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                cmdproduct.Focus();
            }
            // کنترل موجودی
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                string productdb = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string unitdb = dataGridView1.Rows[i].Cells[4].Value.ToString();
                int numberdb = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                int inventoryCode = int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                ex = new executeQuery();
                int inventoryNum = ex.executnonQuery("select number  from productinventory   where productinventory .product =" + productdb + " and  inventory  =" + inventoryCode);

                if (string.IsNullOrEmpty(inventoryNum.ToString()))
                {
                    MessageBox.Show("' کالای " + dataGridView2.Rows[i].Cells[3].Value.ToString() + ". در انبار وجود ندارد '");
                    return;
                }



                if (!string.IsNullOrEmpty(txtnumber.Text) && !string.IsNullOrEmpty(inventoryNum.ToString()))
                {
                    if (string.IsNullOrEmpty(txtnumber.Text))
                    {
                        MessageBox.Show("تعداد کالا را وارد کنید.");
                        return;
                    }

                    if (inventoryNum == 0)
                    {
                        MessageBox.Show("'  تعداد کالای  " + dataGridView2.Rows[i].Cells[3].Value.ToString() + ". در انبار 0 است '");
                        falgenum = true;
                    }
                    else if (inventoryNum < numberdb)
                    {
                        MessageBox.Show("' تعداد کالای " + dataGridView2.Rows[i].Cells[3].Value.ToString() + " در انبار  کمتر از حواله است .'");
                        falgenum = true;
                    }
                    if (falgenum == true)
                        return;


                    string s = "insert into inventoryAssembel ([suppliercode] ,inventorycode ,[date] ,[time] ) values (" + cmdproduct.MyID + "," + cmdinventory.MyID + ",'" + cmddate .mycurrentdate + "','" + cmdtime.mycurrentTime  + "')";
                    ex = new executeQuery();
                    var inventoryAssembel = ex.executnonQuery(s);

                    int b = 0;
                    if (inventoryAssembel > 0)
                    {


                        ex = new executeQuery();
                        ex.executnonQuery("update   productinventory set number = number -" + numberdb + " where product = " + productdb + " and  inventory= " + inventoryCode);
                        MessageBox.Show(".تغییر تعداد کالای" + cmdproduct.MyText + "انبار انجام شد ");

                        ex = new executeQuery();
                        var MaxCode = ex.executscaler("select max(code) from [dbo].[inventoryAssembel]");

                        ex = new executeQuery();
                        ex.executnonQuery("insert into inventoryAssembeldetaial ([AssembelCodeDetail],[product], [unit],[number])values (" + MaxCode + "," + productdb + "," + unitdb + "," + numberdb + ")");


                        MessageBox.Show("درج انجام شد ");

                    }
                }


            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            countDeletNum = 0;
            txtcode.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmdproduct.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cmdinventory.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            btnDelet.Enabled = btnEdit.Enabled = true;
            panel2.Visible = false;

            label2.Visible = txtcode.Visible = true;
        }

        private void productinventoryAssinment_Load(object sender, EventArgs e)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string a = "select [inventoryAssembel].code,[dbo].[inventory].title as inventorynsme,[inventory].code ,product.code  ,supplier.[name]  + ' '+ supplier.family as supplierName ,[inventoryAssembel].[date],[inventoryAssembel].[time]  from [dbo].[inventoryAssembel] left join [inventory] on [dbo].[inventoryAssembel]. inventorycode =inventory.code inner join supplier on [inventoryAssembel].suppliercode =supplier.codesup  inner join inventoryAssembeldetaial  on inventoryAssembel .code  =inventoryAssembeldetaial.AssembelCodeDetail   inner join Product  on inventoryAssembeldetaial .product =Product .code ";
            ex = new executeQuery();
            ex.report(a, dataGridView1);

        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            string d = "delete [dbo].[productinventoryAssinment] where code = " + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(d);
            btnDelet.Enabled = btnEdit.Enabled = false;
            MessageBox.Show("حذف انجام شد .");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cmdproduct .MyText == string.Empty)
            {
                MessageBox.Show("لطفا کد رسید را وارد کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                cmdproduct.Focus();
            }
            //  اپدیت تعداد کالا های رسید دیتیل  
            ex = new executeQuery();
            var NumberInventory = ex.executscaler("select number  from productinventory  where inventory=" + cmdinventory.MyID  + "  and  product =" + cmdproduct.MyID);

            ex = new executeQuery();
            int  lastnumber = int.Parse(ex.executscaler("select number  from  recideDetailes  inner join recide on recideDetailes.recideCodeDetail =Recide .code  where recideDetailes.product =" + cmdproduct.MyID + " and  inventorycode =" + cmdinventory.MyID ).ToString());

            ex = new executeQuery();
            if (!string.IsNullOrEmpty(NumberInventory.ToString()) && !string.IsNullOrEmpty(lastnumber.ToString()))
            {
                int newInventoryNum = int.Parse(NumberInventory.ToString()) - lastnumber;
                int newnum = int.Parse(NumberInventory.ToString()) + int.Parse(txtcode .Text);

                //ex.executnonQuery("update   productinventory set number =" + newnum + " where recideDetailes.product = " + cmdproduct.MyID + " and  inventorycode = " + cmdinventory.SelectedValue);
                //MessageBox.Show(".تغییر تعداد کالا های انبار انجام شد ");

            }
            //  اپدیت رسید 
            string s = "update  [Recide]  set [Recide].[date]='" + txtcode .Text + "',recideNumber=" + txtnumber  .Text + ", suppliercode =" + cmdsupplier.MyID  + ",[inventorycode]=" + cmdinventory.MyID  + "where  Code=" ;
            ex = new executeQuery();


            var result = ex.executnonQuery(s);
            int result2 = 0;

            //  اپدیت رسید دیتیل 
            if (result > 0)
            {

                DataTable t3 = new DataTable();
                ex = new executeQuery();
                //ex.executnonQuery("delete * from [recideDetailes]  where recideCodeDetail =" + id);


                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    string productdb = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string unitdb = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string txtnumberdb = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    ex = new executeQuery();
                    result2 = ex.executnonQuery("insert into  recideDetailes  ([recideCodeDetail],[product], [unit],[number]) values (" + txtcode  + "," + productdb + "," + unitdb + "," + txtnumber .Text + ");");

                }
                if (result2 > 0)
                    MessageBox.Show("ویرایش انجام شد ");

            }

            btnDelet.Enabled = btnEdit.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = 1;
            foreach (TextBox a in Controls)
                a.Text = string.Empty;

            btnDelet.Enabled = panel2.Visible = btnEdit.Enabled = label2.Visible = txtcode.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void calendarcontrol1_Load(object sender, EventArgs e)
        {

        }

        private void cmdinventory_Mytextchange_event(object sender, EventArgs e)
        {
            cmdproduct.MyText = "";
            cmdproduct.Enabled = true;
            cmdproduct.MyDB = "productinventory inner join product on productinventory.product=product.code  where  inventory=" + cmdinventory .MyID ;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btndeletedeltail_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            countDeletNum++;
        }

        private void cmdinventory_Load(object sender, EventArgs e)
        {

        }

        private void cmdproduct_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            dataGridView2.Rows.Add(i, txtnumber .Text, cmdproduct.MyID, cmdproduct.MyText,cmdinventory .MyID ,cmdinventory.MyText , cmdUnit .MyID, cmdUnit.MyText);
            i++;


        }
    }
}

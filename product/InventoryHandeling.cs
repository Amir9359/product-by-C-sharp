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
    public partial class InventoryHandeling : Form
    {
        public InventoryHandeling()
        {
            InitializeComponent();
        }
        executeQuery ex;
        int i = 1;
        int countDeletNum = 0;
        int id=0;
        private void button5_Click(object sender, EventArgs e)
        {
        
            i = 1;

            if (cmdproduct.MyText == string.Empty)
            {
                MessageBox.Show("لطفا کالا را انتخاب کنید !", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                cmdproduct.Focus();
            }

                    string s = $"insert into InventoryHandeling (Title,inventoryCode ,[date] ) values (N'{txtname.Text}',{ cmdinventory.MyID },'{ cmddate .mycurrentdate }')";
                    ex = new executeQuery();
                    var inventoryAssembel = ex.executnonQuery(s);

            for (int i = 0; i <= dataGridView2.Rows.Count -1; i++)
            {
                if (inventoryAssembel > 0)
                {

                    string productdb = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    string unitdb = dataGridView2.Rows[i].Cells[6].Value.ToString();
                    int numberdb = int.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());
                    int inventoryCode = int.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString());

                    ex = new executeQuery();
                    var MaxCode = ex.executscaler("select max(code) from [dbo].[InventoryHandeling]");

                    ex = new executeQuery();
                    ex.executnonQuery($"insert into InventoryHandelingDetail ([InventoryHandelingCode],[product], [unit],[number])values ({MaxCode },{productdb},{unitdb},{numberdb})");

                    ex = new executeQuery();
                    ex.executnonQuery($"update  productinventory set number = number -{numberdb} where product ={productdb } and  inventory={inventoryCode}");


                }

            }

            MessageBox.Show("درج انجام شد ");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            countDeletNum = 0;
            txtcode .Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmdproduct.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cmdinventory.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            btnContradiction.Enabled = true;
            panel2.Visible = false;


        }

        private void productInventoryHandeling_Load(object sender, EventArgs e)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string a = "select ih.code,ih.title as IHDTitile,IH.Date,inventory.title,(select count(IHD.code) from InventoryHandelingDetail as IHD inner join InventoryHandeling on IHD.InventoryHandelingCode = InventoryHandeling.code  where IHD.InventoryHandelingCode = IH.code ) as countNumber from InventoryHandeling as IH inner join inventory on  IH.inventoryCode = inventory.code where Ih.inventoryCode = inventory.code";
            ex = new executeQuery();
            ex.report(a, dataGridView1);

        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            string d = "delete [dbo].[productInventoryHandeling] where code = " + dataGridView1.CurrentRow.Cells[0].Value;
            ex = new executeQuery();
            ex.executnonQuery(d);
          btnContradiction.Enabled = false;
            MessageBox.Show("حذف انجام شد .");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = 1;
            foreach (TextBox a in Controls)
                a.Text = string.Empty;

        panel2.Visible  = label2.Visible = txtcode.Visible = false;
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnContradiction_Click(object sender, EventArgs e)
        {
            InventoryHandelingContradiction IHL = new InventoryHandelingContradiction(id);
            IHL.ShowDialog();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.ColumnIndex ==4)
            {
               id =int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                btnContradiction_Click(null, null);

            }
        }
    }
}

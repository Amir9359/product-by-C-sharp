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
    public interface IMyInterface
    {
        int myproperties { get; set; }
        int myproperties2 { get; set; }
        void MyMethod();
        void MyMethod(int a);
    }
    public partial class InventoryHandelingContradiction : Form 
    {
        int id;
        public InventoryHandelingContradiction()
        {
            InitializeComponent();
            
        }
        // Populates a TreeView control with example nodes. 


        public InventoryHandelingContradiction( int idInventoryHandeling)
        {
            InitializeComponent();
            id = idInventoryHandeling;

        }
        executeQuery ex;
        int i = 1;
        int countDeletNum = 0;
        private void button5_Click(object sender, EventArgs e)
        { 
            // برای رسید ویا حواله کردن هرکدام را در یک لیست دخیره کرده سپس رسید یا حواله میکنیم.

            List<Details> Recide = new List<Details>();
            List<Details> Assinment = new List<Details>();

            int inventoryCode = int .Parse (ex.executscaler("select inventoryCode  from InventoryHandeling where code= " + id).ToString());

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int number = int.Parse(dataGridView1.Rows[i].Cells["Column9"].Value.ToString());
                ex = new executeQuery();
                if (number < 0)
                {
                    ex = new executeQuery();
                    var reader = ex.executeReader("select Product, unit from [InventoryHandelingDetail] where code=" + dataGridView1.CurrentRow.Cells["Column1"].Value.ToString());
                    if (reader.Read())
                    {
                        Details recidedetail = new Details();
                        recidedetail.Number = -number;
                        recidedetail.Product = int.Parse(reader[0].ToString());
                        recidedetail.Unitcode = int.Parse(reader[1].ToString());
                        Recide.Add(recidedetail);
                    }

                    reader.Close();
                }

                else if (number > 0)
                {
                    ex = new executeQuery();
                    var reader = ex.executeReader("select Product,unit from [InventoryHandelingDetail] where code=" + dataGridView1.CurrentRow.Cells["Column1"].Value.ToString());
                    if (reader.Read())
                    {
                        int number1 = Math.Abs(number);
                        Details AssimentDetail = new Details();
                        AssimentDetail.Number = number1;
                        AssimentDetail.Product = int.Parse(reader[0].ToString());
                        AssimentDetail.Unitcode = int.Parse(reader[1].ToString());
                        Assinment.Add(AssimentDetail);
                        }
                    reader.Close();
                    }
                }
            


            #region ثبت حواله 
            if (Assinment.Count > 0)
            {
                string s = $"insert into [inventoryAssembel] ([Recide].[date],[Recide].[time],suppliercode ,[inventorycode],Discription) values ('{DateTime.Now.DateToShamsi() }','{DateTime.Now.TimeOfDay.ToString().Substring(0, 5)}',{staticuser.usercode} ,{inventoryCode},N' سند اضافی وکسورات' )";
                ex = new executeQuery();
                var a = ex.executnonQuery(s);
                if (a > 0)
                {
                    for (int j = 0; j < Assinment.Count; j++)
                    {
                        ex = new executeQuery();
                        var maxval =int.Parse ( ex.executscaler("select max(code) from [dbo].[inventoryAssembel]").ToString());
                        int productdb = Assinment[j].Product;
                        int unitdb = Assinment[j].Unitcode;
                        int numberdb = Assinment[j].Number;

                        ex = new executeQuery();
                        if (ex.executnonQuery($"insert into inventoryAssembeldetaial ([AssembelCodeDetail],[product],[unit],[number]) values ({ maxval},{ productdb },{unitdb},{numberdb})") > 0)
                        {
                            ex = new executeQuery();
                            ex.executnonQuery($"update  productinventory set number=number + {numberdb} where product ={productdb}  and  inventory={ inventoryCode}");

                        }

                    }
                }
            }
            #endregion

            #region ثبت رسید 
            if (Recide.Count > 0)
            {
                string s = $"insert into [Recide] ([Recide].[date],[Recide].[time],suppliercode ,[inventorycode],Discription) values ('{DateTime.Now.DateToShamsi() }','{DateTime.Now.TimeOfDay.ToString().Substring(0, 5)}'," + staticuser.usercode + "," + inventoryCode + ",N' سند اضافی وکسورات');";
                ex = new executeQuery();
                var a = ex.executnonQuery(s);

                if (a > 0)
                {
                    for (int j = 0; j < Recide.Count; j++)
                    {
                        ex = new executeQuery();
                        var maxval = int.Parse(ex.executscaler("select max(code) from [dbo].[Recide]").ToString());
                        int productdb = Recide[j].Product;
                        int unitdb = Recide[j].Unitcode;
                        int numberdb = Recide[j].Number;

                        ex = new executeQuery();
                        if (ex.executnonQuery("insert into recideDetailes ([recideCodeDetail],[product], [unit],[number]) values (" + maxval + "," + productdb + "," + unitdb + "," + numberdb + ")") > 0)
                        {
                            ex = new executeQuery();
                            ex.executnonQuery($"update productinventory set number=number - {numberdb} where product={productdb}  and  inventory={inventoryCode} ");

                        }
                    }
                }
            }
            #endregion

        }



        private void productContradiction_Load(object sender, EventArgs e)
        {

            button1_Click(null, null);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string a = "SELECT   IH.code,  dbo.Product.proname,dbo.unitt.name, dbo.inventory.title, IH.Date,IH.title AS TitleHandeling,  IHD.number ,(select number from productinventory where product =ihd.Product and inventory =ih.inventoryCode ) As InventoryNumber,ihd.number -(select number from productinventory where product =ihd.Product and inventory =ih.inventoryCode ) as Contradiction from dbo.InventoryHandeling as IH INNER JOIN dbo.InventoryHandelingDetail as IHD ON IH.code = IHD.InventoryHandelingCode INNER JOIN  dbo.inventory ON IH.inventoryCode = dbo.inventory.code INNER JOIN dbo.Product ON IHD.Product = dbo.Product.code INNER JOIN dbo.unitt ON IHD.Product = dbo.unitt.code where IH .code =" + id ;
            ex = new executeQuery();
            ex.report(a, dataGridView1);

        }



        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
                }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.Tag = "ویژگی ----------  ";
            MessageBox.Show(e.Node.Text);
            MessageBox.Show(e.Node.Tag .ToString() + e.Node.Text );
            

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }



        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
    public class Details
    {
        public int Product { get; set; }
        public int Unitcode { get; set; }
        public int Number { get; set; }

    }
}

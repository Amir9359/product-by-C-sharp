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
    public partial class ReportinventoryAsseimentDetail  : baseForm
    {
        public ReportinventoryAsseimentDetail ()
        {
            InitializeComponent();
        }
        executeQuery ex;
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            ex = new executeQuery();
            ex.bindingsource("select * ,(select sum(number) from recideDetailes inner join Recide on recideDetailes.recideCodeDetail =Recide.code where product = U.product   and [date] +' ' +[time]<=U .[date]  + ' ' +U.[time])  -   isnull((select sum(number)  from inventoryAssembeldetaial  inner join inventoryAssembel  on inventoryAssembeldetaial.AssembelCodeDetail  =inventoryAssembel.code  where  product= u.product  and [date]+' ' +[time]  <=U.[date] + ' ' +U.[time]),0) as SumNumber from  (select RI .code,RAD .product   ,Product.proname , (select  inventory.title from inventory  left join Recide  on inventory . code =Recide.inventorycode  where recide.code =RAD.recideCodeDetail  ) as InventoryTitle ,unitt.[name] as Unit ,N'رسید' as Type, RAD.number  as ProductNumber ,0 as AssimentNumber, RI.[date]  ,RI.[time] from recideDetailes as RAD left join Recide as RI on RAD.recideCodeDetail=RI.code  left join Product on RAD.product=Product .code  left join unitt on RAD.unit =unitt.code    union   select INSD .code,INSD .product ,Product.proname , (select inventory.title from inventory  left join inventoryAssembel  on inventory.code =inventoryAssembel.inventorycode  where  AssembelCodeDetail  = inventoryAssembel.code ) as InventoryAssimentTitle ,unitt.[name] as Unit ,N'حواله' as Type, 0 as productNumber,INSD.number as AssimentNumber , INS .[date]  ,INS.[time] from inventoryAssembeldetaial as  INSD  left join inventoryAssembel  as INS  on AssembelCodeDetail=INS.code left join Product on INSD.product=Product .code   left join unitt on INSD.unit =unitt.code) as U order By date,time",  bindingNavigator1, dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false ;
        }

        private void ReportinventoryAsseimentDetail_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
            //string a = "Amir";
            //string encrypt = a.Encrypt(a);
            //MessageBox.Show(encrypt);
            //MessageBox.Show(a.Decrypt(encrypt));
            //int c = 23442222;
            //string d = c.setai();
            //MessageBox.Show (c.setai());

            //MessageBox.Show(d.replaceSeta());
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            #region where
            string where = string.Empty;


            if (!string.IsNullOrEmpty(FromDate.mycurrentdate  ) )
            {
                if(string .IsNullOrEmpty( where ))
                where = "where recide.date >= '" + FromDate.mycurrentdate + "'";
                else
                    where += "AND  recide.date >= '" + FromDate.mycurrentdate + "'";
            }

            if (!string.IsNullOrEmpty(ToDate .mycurrentdate ) )
            {
                if (string.IsNullOrEmpty(where))
                    where = "where recide.date <= '" + ToDate.mycurrentdate + "'";
                else
                    where += "And recide.date <= '" + ToDate.mycurrentdate + "'";

            }


            if(myunituserControl1.MyID >0)
            {
                if (string.IsNullOrEmpty(where))
                    where = "where dbo.inventory.code =" + myunituserControl1.MyID;
                else
                    where += "And dbo.inventory.code =" + myunituserControl1.MyID;

            }
            

            #endregion

            ex = new executeQuery();
            ex.bindingsource("SELECT  dbo.recideDetailes.code, dbo.Product.proname AS product, dbo.unitt.name AS unit, dbo.Recide.date, dbo.Recide.code AS RecideCode, dbo.recideDetailes.number, dbo.supplier.name + ' ' + dbo.supplier.family AS supplierName,dbo.inventory.title AS InventoryName from dbo.recideDetailes INNER JOIN dbo.Product ON dbo.recideDetailes.product = dbo.Product.code INNER JOIN dbo.unitt ON dbo.recideDetailes.unit = dbo.unitt.code INNER JOIN dbo.Recide ON dbo.recideDetailes.recideCodeDetail = dbo.Recide.code INNER JOIN dbo.supplier ON dbo.Recide.suppliercode = dbo.supplier.codesup INNER JOIN dbo.inventory ON dbo.Recide.inventorycode = dbo.inventory.code "+ where , bindingNavigator1, dataGridView1);
        }

        private void myunituserControl1_Mytextchange_event(object sender, EventArgs e)
        {

        }
    }
}

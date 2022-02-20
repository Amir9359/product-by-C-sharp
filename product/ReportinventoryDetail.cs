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
    public partial class ReportinventoryDetail : baseForm
    {
        public ReportinventoryDetail()
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
            ex.bindingsource("SELECT  dbo.recideDetailes.code, dbo.Product.proname AS product, dbo.unitt.name AS unit, dbo.Recide.date, dbo.Recide.code AS RecideCode, dbo.recideDetailes.number, dbo.supplier.name + ' ' + dbo.supplier.family AS supplierName,dbo.inventory.title AS InventoryName from dbo.recideDetailes INNER JOIN dbo.Product ON dbo.recideDetailes.product = dbo.Product.code INNER JOIN dbo.unitt ON dbo.recideDetailes.unit = dbo.unitt.code INNER JOIN dbo.Recide ON dbo.recideDetailes.recideCodeDetail = dbo.Recide.code INNER JOIN dbo.supplier ON dbo.Recide.suppliercode = dbo.supplier.codesup INNER JOIN dbo.inventory ON dbo.Recide.inventorycode = dbo.inventory.code order by date,time",  bindingNavigator1, dataGridView1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false ;
        }

        private void ReportinventoryDetail_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            #region where
            string where = string.Empty;


            if (!string.IsNullOrEmpty(FromDate .mycurrentdate ) )
            {
                if(string .IsNullOrEmpty( where ))
                where = "where recide.date >= '" + FromDate .mycurrentdate + "'";
                else
                    where += "AND  recide.date >= '" + FromDate .mycurrentdate + "'";
            }

            if (!string.IsNullOrEmpty(ToDate .mycurrentdate ) )
            {
                if (string.IsNullOrEmpty(where))
                    where = "where recide.date <= '" + ToDate .mycurrentdate + "'";
                else
                    where += "And recide.date <= '" + ToDate .mycurrentdate + "'";

            }


            if(myunituserControl1.MyID >0)
            {
                if (string.IsNullOrEmpty(where))
                    where = "where dbo.inventory.code =" + myunituserControl1.MyID ; 
                else
                    where += "And dbo.inventory.code =" + myunituserControl1.MyID ; 

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

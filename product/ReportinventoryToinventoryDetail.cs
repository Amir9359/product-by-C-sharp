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
    public partial class ReportinventoryToinventoryDetail : baseForm
    {
        public ReportinventoryToinventoryDetail()
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
            ex.bindingsource("SELECT    dbo.InventoryToinventory.code, dbo.Product.proname, dbo.unitt.name, dbo.InventoryToinventory.Date, dbo.InventoryToinventory.Time, dbo.InventoryToinventoryDetail.number, inventory_1.title AS FrominventoryToinventory,  dbo.inventory.title AS ToinventoryToinventory From dbo.InventoryToinventory INNER JOIN dbo.InventoryToinventoryDetail ON dbo.InventoryToinventory.code = dbo.InventoryToinventoryDetail.InventoryToinventoryCode INNER JOIN dbo.Product ON dbo.InventoryToinventoryDetail.product = dbo.Product.code INNER JOIN dbo.unitt ON dbo.InventoryToinventoryDetail.unit = dbo.unitt.code INNER JOIN dbo.inventory ON dbo.InventoryToinventory.ToInventory = dbo.inventory.code INNER JOIN dbo.inventory AS inventory_1 ON dbo.InventoryToinventory.FromInventory = inventory_1.code ",  bindingNavigator1, dataGridView1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false ;
        }

        private void ReportinventoryToinventoryDetail_Load(object sender, EventArgs e)
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


            if (!string.IsNullOrEmpty(fromdate.mycurrentdate))
            {
                if (string.IsNullOrEmpty(where))
                    where = "where InventoryToinventory.date >='" + fromdate.mycurrentdate + "'";
                else
                    where += " AND  InventoryToinventory.date >= '" + fromdate.mycurrentdate + "'";
            }

            if (!string.IsNullOrEmpty(ToDate.mycurrentdate))
            {
                if (string.IsNullOrEmpty(where))
                    where = "where InventoryToinventory.date <= '" + ToDate.mycurrentdate + "'";
                else
                    where += " And InventoryToinventory.date <= '" + ToDate.mycurrentdate + "'";

            }


            if (inventory.MyID > 0)
            {
                if (string.IsNullOrEmpty(where))
                    where = "where dbo.InventoryToinventorydetail.inventory =" + inventory.MyID;
                else
                    where += " And dbo.InventoryToinventorydetail.inventory=" + inventory.MyID;

            }


            #endregion

            ex = new executeQuery();
            ex.bindingsource("SELECT    dbo.InventoryToinventory.code, dbo.Product.proname, dbo.unitt.name, dbo.InventoryToinventory.Date, dbo.InventoryToinventory.Time, dbo.InventoryToinventoryDetail.number, inventory_1.title AS FrominventoryToinventory,  dbo.inventory.title AS ToinventoryToinventory From dbo.InventoryToinventory INNER JOIN dbo.InventoryToinventoryDetail ON dbo.InventoryToinventory.code = dbo.InventoryToinventoryDetail.InventoryToinventoryCode INNER JOIN dbo.Product ON dbo.InventoryToinventoryDetail.product = dbo.Product.code INNER JOIN dbo.unitt ON dbo.InventoryToinventoryDetail.unit = dbo.unitt.code INNER JOIN dbo.inventory ON dbo.InventoryToinventory.ToInventory = dbo.inventory.code INNER JOIN dbo.inventory AS inventory_1 ON dbo.InventoryToinventory.FromInventory = inventory_1.code " + where, bindingNavigator1, dataGridView1);
        }

        private void myunituserControl1_Mytextchange_event(object sender, EventArgs e)
        {

        }
    }
}

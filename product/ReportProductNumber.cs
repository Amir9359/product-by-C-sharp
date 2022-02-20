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
    public partial class ReportProductNumber : baseForm
    {
        public ReportProductNumber()
        {
            InitializeComponent();
        }
        executeQuery ex;
        public int index2;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void inventoryAssembely_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {


            //ex = new executeQuery();
            //ex.executnonQuery("");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
          


        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            ex = new executeQuery();
            ex.report   ("select sum([dbo].[recideDetailes].number ) as sumNumber ,[dbo].[Product].proname from recideDetailes inner join [Product] on recideDetailes.product =Product.code group by [Product].proname", dataGridView2 );

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

        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}

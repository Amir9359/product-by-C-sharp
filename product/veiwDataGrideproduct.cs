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
    public partial class veiwDataGrideproduct : baseForm
    {
        string code;
        public veiwDataGrideproduct(string code)
        {
            this.code = code;
            InitializeComponent();
            Text = "شماره رسید : "+code ;
        }
        executeQuery ex;
        private void veiwDataGrideproduct_Load(object sender, EventArgs e)
        {
            ex = new executeQuery();
            ex.report("select Product.proname,unitt.[name]  , recideDetailes.code ,recide.recideNumber ,recideDetailes.number  from recideDetailes left join Product on recideDetailes.[product]=product.code left join unitt on  recideDetailes.[unit] =unitt.code left join  recide on recideDetailes.recideCodeDetail =recide.code   where recideCodeDetail=" + code,dataGridView1 );
        }
    }
}

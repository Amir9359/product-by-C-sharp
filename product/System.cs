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
    public partial class system : Form
    {
        public system()
        {
            InitializeComponent();
        }
        executeQuery ex;
        private void تغییرواحدمصرفیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unit unit = new unit();
            ex = new executeQuery();
            ex.form(unit, this);
  
        }

        private void تغییرمشخصاتکالاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            productManage product = new productManage();
            ex = new executeQuery();
            ex.form(product , this);

        }

        private void Product_Load(object sender, EventArgs e)
        {

            ex = new executeQuery();
            ex.date_time(toolStripLabel2,toolStripLabel4);
            staticuser.date = toolStripLabel2.Text;

        }

        private void مسشخصاتانبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inventory inventor = new inventory();
            ex = new executeQuery();
            ex.form(inventor , this);
        }

        private void وروداطلاعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void کالادرانبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            productinventory proinv = new productinventory();
            ex = new executeQuery();
            ex.form(proinv , this);

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ایجادکاربرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user  use = new user ();
            ex = new executeQuery();
            ex.form(use , this);

        }

        private void Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void شهرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            city pro = new city();
            ex = new executeQuery();
            ex.form (pro, this);
        }

        private void استانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            province cit = new province();
            ex = new executeQuery();
            ex.form(cit, this);
        }

        private void تغییررمزعبورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword change = new ChangePassword();
            ex = new executeQuery();
            ex.form(change, this);
        }

        private void تامیینکننندهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supplier  supp = new supplier ();
            ex = new executeQuery();
            ex.form(supp , this);
        }

        private void رسیددرانبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recide  recide = new Recide ();
            ex = new executeQuery();
            ex.form(recide , this);
        }

        private void کشورToolStripMenuItem_Click(object sender, EventArgs e)
        {

            country countr = new country();
            ex = new executeQuery();
            ex.form(countr, this);
        }

        private void حوالهانبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inventoryAssinment frm2 = new inventoryAssinment();
            ex = new executeQuery();
            ex.form(frm2, this);
        }

        private void تعدادکالادرانبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportProductNumber frm2 = new ReportProductNumber();
            ex = new executeQuery();
            ex.form(frm2, this);
        }

        private void گزارشاقلامرسیدانبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportinventoryDetail frm2 = new ReportinventoryDetail();
            ex = new executeQuery();
            ex.form(frm2, this);
        }

        private void کاردکسکالاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportinventoryAsseimentDetail  assiment = new ReportinventoryAsseimentDetail();
            ex = new executeQuery();
            ex.form(assiment, this);
        }

        private void انباربهانبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryToinventory  assiment0 = new InventoryToinventory();
            ex = new executeQuery();
            ex.form(assiment0, this);
        }

        private void گزارشاقلامانباردرانبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportinventoryToinventoryDetail   assiment1 = new ReportinventoryToinventoryDetail();
            ex = new executeQuery();
            ex.form(assiment1, this);
        }

        private void انبارگردانیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryHandeling  assiment2 = new InventoryHandeling();
            ex = new executeQuery();
            ex.form(assiment2, this);
        }

        private void محلنگهداریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeapingPlace assiment3 = new KeapingPlace();
            ex = new executeQuery();
            ex.form(assiment3, this);
        }
    }
}

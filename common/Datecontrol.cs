using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace product
{
    public partial class Datecontrol : UserControl
    {
        public Datecontrol()
        {
            InitializeComponent();
        }
        string currentdate;
        mydate  date = new mydate  ();
        string date1;
        private void button4_Click(object sender, EventArgs e)
        {
            date.ShowDialog();
            currentdate = textBox1.Text = date.fulldate;
        }
        public string mycurrentdate { get{ return currentdate;  } set { currentdate = value ; } }
        public string SetText { get { return textBox1.Text ; } set { textBox1 .Text  = value; } }



    }
}

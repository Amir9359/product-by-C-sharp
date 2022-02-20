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
    public partial class TimeControl : UserControl
    {
        public TimeControl()
        {
            InitializeComponent();
        }
        string currentTime;
        DateForm date = new DateForm ();
        string date1;
        private void button4_Click(object sender, EventArgs e)
        {
            date.ShowDialog();
            currentTime = textBox1.Text = date.Time;
        }
        public string mycurrentTime{ get { return currentTime; } set { currentTime = value; } }
        public string SetText { get { return textBox1.Text ; } set { textBox1 .Text  = value; } }

    }
}

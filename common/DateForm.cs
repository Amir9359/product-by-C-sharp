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
    public partial class DateForm : baseForm
    {
        public string  ReccentTime;

        public DateForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReccentTime = numericUpDown1.Value.ToString() + ":" + numericUpDown2.Value.ToString();
            Close();
        }
        public string Time { get { return ReccentTime; } set{ ReccentTime = value; } }

    }
}

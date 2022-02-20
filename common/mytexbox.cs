using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace product
{
    public partial class mytexbox : TextBox
    {


        private void mytexbox_Enter(object sender, EventArgs e)
        {
            BackColor = Color.Yellow;
        }

        private void mytexbox_Leave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }
    }
}

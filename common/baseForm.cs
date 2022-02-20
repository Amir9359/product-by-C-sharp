using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace product
{
    public partial class baseForm : Form
    {
        public  baseForm()
        {
            InitializeComponent();
        }
        public  string  ClassName{ get; set; }
        public string classText { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string classDiscription()
        {
            return ClassName + "  " + classText;
        }
        public virtual  string FullName()
        {
            return name  + "  " + family ;
        }


    }
}

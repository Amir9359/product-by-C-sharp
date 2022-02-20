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
    public partial class myunituserControl : UserControl
    {
        public event mydelegate  Mytextchange_event=null ;
        public event mydelegate textBox = null;
        private string title;
        private string name;
        private string mydb;
        private string myfildecode="code";
        private int   id;
        public myunituserControl()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView list = new listView("select "+ myfildecode + " as code,"+title +" as title from "+mydb );
            list.Text = name;
            list.ShowDialog();
            id = list.MyID ;
            textBox2.Text = list.textform;

        }
        public string  Mytitle { get { return title; } set { title = value; } }
        public string  MyFormname { get { return name ; } set { name  = value; } }
        public string  MyDB { get { return mydb ; } set { mydb  = value; } }
        public string myFildeCode { get { return myfildecode; } set { myfildecode  = value; } }
        public string MyText { get { return textBox2.Text; } set { textBox2.Text = value; } }

        public int MyID { get { return id; } set { id = value; } }

        private void myunituserControl_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {if (Mytextchange_event!=null)
            Mytextchange_event(this, e);
        }
    }
}

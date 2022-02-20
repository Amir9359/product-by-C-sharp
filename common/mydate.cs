using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace product
{

    public partial class mydate : baseForm
    {
        string date1 = string.Empty;
        public mydate()
        {
            InitializeComponent();
        }
        string   a;
        private void button30_Click(object sender, EventArgs e)
        {
             a = ((Button)sender).Text;
            Close();
        }
        public string  fulldate { get { return date1 = year.Value.ToString("0000") + "/" +( int.Parse(month.SelectedIndex.ToString("00"))+1 )+"/"+  a;  } set { date1 = value; } }
        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (month.SelectedIndex > 5)
                button31.Visible = false;
        }

        private void mydate_Load(object sender, EventArgs e)
        {

            PersianCalendar s = new PersianCalendar();
            month.SelectedIndex = s.GetMonth(DateTime.Now )-1;
            year.Value  = s.GetYear (DateTime.Now) ;
            foreach (var b in Controls)
                if(b.GetType()==typeof(Button ))
                if (((Button )b).Text == s.GetDayOfMonth(DateTime.Now).ToString())
                        ((Button)b).BackColor = Color.Yellow;
        }
    }
}

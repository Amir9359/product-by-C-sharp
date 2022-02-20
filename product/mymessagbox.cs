using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using common;

namespace product
{
    public partial class mymessagbox : baseForm
    {
        public mymessagbox()
        {
            InitializeComponent();
        }
        public static DialogResult mymessagebox(string text = default (string ), string caption=default(string ),mymessageboxbuttons buttons=  mymessageboxbuttons.تایید , mymessageboxicon messageBoxIcon = mymessageboxicon.هشدار , mymessageboxdefaltbuttons defaltbuttons = mymessageboxdefaltbuttons.تایید )
        {
            mymessagbox messagebox = new mymessagbox();
            messagebox.label1.Text = text;
            messagebox.Text = caption;
            switch (buttons)
            {
                case mymessageboxbuttons.تایید:
                    messagebox.btnok.Visible = true;
                    break;
                case mymessageboxbuttons.بلی_خیر:
                    messagebox.btnno .Visible = messagebox.btnyes .Visible = true;
                    break;
                case mymessageboxbuttons.هیجکدام :
                    messagebox.btnok.Visible=messagebox.btnno.Visible = messagebox.btnyes.Visible = false ;
                    break;
            }
            switch (messageBoxIcon)
            {
                case mymessageboxicon.خطا:
                    messagebox.pictureBox1.Image = Properties .Resources.download;
                    break;
                case mymessageboxicon.سوال :
                    messagebox.pictureBox1.Image = Properties.Resources.download  ;
                    break;
                case mymessageboxicon.هشدار :
                    messagebox.pictureBox1.Image = Properties.Resources._2654;
                    break;
          
            }
            switch (defaltbuttons)
            {
                case mymessageboxdefaltbuttons.تایید:
                    messagebox.btnok.Focus();
                    break;
                case mymessageboxdefaltbuttons.بلی:
                    messagebox.btnyes.Focus();
                    break;
                case mymessageboxdefaltbuttons.خیر:
                    messagebox.btnno.Focus();
                    break;

            }
            return messagebox.ShowDialog () ;
        }

        private void mymessagbox_Load(object sender, EventArgs e)
        {

        }

        private void btnno_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnyes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

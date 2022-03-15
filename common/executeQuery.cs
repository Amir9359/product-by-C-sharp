using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace product
{

    public  class executeQuery 
    {

        public DataView dataview1;
        public DataTable t1;
        public int executnonQuery(string comand)
        {
            SqlConnection conn = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand();

            int a = -1;
            try
            {
                conn.Open();

                com.CommandText = comand;
                com.Connection = conn;
                a = com.ExecuteNonQuery();

            }
            catch (Exception ex)
            {


            }

            finally
            {

                conn.Close();

            }
            return a;
          }
        public object executscaler(string comand)
        {
            SqlConnection conn = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand();

            conn.Open();

            com.CommandText = comand;
            com.Connection = conn;
            var x = com.ExecuteScalar();

            conn.Close();
            return x;
        }

        public void report(string s, DataGridView dataGridView)
        {


            SqlConnection con = new SqlConnection("data Source=.; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable t1 = new DataTable();

            com.CommandText = s;
            con.Open();
            com.Connection = con;
            da.SelectCommand = com;
            da.Fill(t1);
            com.ExecuteNonQuery();
            con.Close();
            dataview1 = new DataView(t1);
            dataGridView.DataSource = dataview1;


        }
        public SqlDataReader executeReader(string query)
        {
            SqlConnection conn = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader a = com.ExecuteReader();
            return a;
            conn.Close();

        }
        // t1 که بالا معرفی کرده ایم که از این به بعد میتوانیم به اندسترسی داشته باشیم چون پرشده است .
        public  DataTable executeDataTabel(string query)
        {
        SqlConnection con = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
        SqlCommand com = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        t1 = new DataTable();

            com.CommandText = query;
            con.Open();
            com.Connection = con;
            da.SelectCommand = com;
            da.Fill(t1);
            com.ExecuteReader();
            con.Close();
            return t1;

        }
        public void bindingsource(string s, BindingNavigator bindingn, DataGridView dataGridView)
        {


            SqlConnection con = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable t1 = new DataTable();
            BindingSource bs = new BindingSource();



            com.CommandText = s;
            con.Open();
            com.Connection = con;
            da.SelectCommand = com;
            da.Fill(t1);
            com.ExecuteNonQuery();
            con.Close();
            dataview1 = new DataView(t1);
            bs.DataSource = dataview1;
            bindingn.BindingSource = bs;
            dataGridView.DataSource = bs;

        }
        public void form(Form frm, Form th)
        {

            frm.MdiParent = th;
            frm.Show();
        }

        public void set(string s, DataGridView dataGridView, ComboBox comb, string displayMember, string valuemember)
        {


            SqlConnection con = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();
             t1 = new DataTable();
            com.CommandText = s;
            con.Open();
            com.Connection = con;
            da.SelectCommand = com;
            da.Fill(t1);
            com.ExecuteNonQuery();
            con.Close();
            dataGridView.DataSource = t1;

            comb.DataSource = t1;
            comb.DisplayMember = displayMember;
            comb.ValueMember = valuemember;
        }
        public void set(string s, ComboBox comb, string displayMember, string valuemember, CommandType commandType=CommandType.Text )
        {

            //comb.Items .Clear();
            SqlConnection con = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            SqlCommand com = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable t2 = new DataTable();
            com.CommandType = commandType;
            com.CommandText = s;
            con.Open();
            com.Connection = con;
            da.SelectCommand = com;
            da.Fill(t2);
            com.ExecuteNonQuery();
            con.Close();

            comb.DataSource = t2;
            comb.DisplayMember = displayMember;
            comb.ValueMember = valuemember;
        }
        public void date_time(ToolStripLabel t1, ToolStripLabel t2)
        {
            PersianCalendar persian = new PersianCalendar();
            string year = persian.GetYear(DateTime.Now).ToString();
            string month = persian.GetMonth(DateTime.Now).ToString().PadLeft(2,'0');
            string day = persian.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0');
            string date = year + "/" + month + "/" + day;
            string time = DateTime.Now.ToShortTimeString();

            t2.Text = time;
            t1.Text = date;
        }
    }

}

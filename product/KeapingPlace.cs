using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace product
{
    public partial class KeapingPlace : baseForm
    {
        public KeapingPlace()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data Source=.;  uid=Amir1;pwd=nFadHh99; initial catalog=productDb;integrated security=true;");
            if(con.State ==ConnectionState.Closed )
            con.Open();
            SqlCommand com = new SqlCommand();
            SqlParameter p1 = new SqlParameter("@Title",txtnumber.Text  );

            com.CommandType = CommandType.StoredProcedure ;
            com.Parameters.Add(p1);
            com.CommandText = "KeapingPlaceinsert";
     
            com.Connection = con;

            if (com.ExecuteNonQuery() > 0)
            MessageBox.Show("درج انجام شد .");

            con.Close();
        }
    }
}

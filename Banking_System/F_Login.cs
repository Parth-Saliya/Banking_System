using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class F_Login : Form
    {
        public F_Login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking_System.Properties.Settings.BankConnectionString"].ConnectionString);

        public void conopen()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void conclose()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conopen();


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id,name,branch.Branch_id,Role,branch_name from userTb inner join branch on branch.branch_id = userTb.branch_id where Name = '" + UserName.Text + "' AND Pass = '" + PassWord.Text + "'";

            cmd.ExecuteNonQuery();

            DataTable dtl = new DataTable();
            SqlDataAdapter dal = new SqlDataAdapter(cmd);
            dal.Fill(dtl);
            if (dtl.Rows.Count == 1)
            {
                string id = dtl.Rows[0][0].ToString();
                string name = dtl.Rows[0][1].ToString();
                string Branch_id = dtl.Rows[0][2].ToString();
                string Role = dtl.Rows[0][3].ToString();
                F_Dash fd = new F_Dash();
                ((F_Dash)this.ParentForm).lbuid.Text = dtl.Rows[0][0].ToString();
                ((F_Dash)this.ParentForm).lbuname.Text = dtl.Rows[0][1].ToString();
                ((F_Dash)this.ParentForm).lbbid.Text = dtl.Rows[0][2].ToString();
                ((F_Dash)this.ParentForm).lburole.Text = dtl.Rows[0][3].ToString();
                ((F_Dash)this.ParentForm).lbbranch.Text = dtl.Rows[0][4].ToString();
                

                fd.lbuid.Text = dtl.Rows[0][0].ToString();
               
                this.Close();

            }
            else
            {

                MessageBox.Show("Username and password dont match try again");
                UserName.Clear();
                PassWord.Clear();

            }
            con.Close();
        }

        private void F_Login_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class F_Branch : Form
    {
        public F_Branch()
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

        public void add()
        {
        
            conopen();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into user (branch_code,branch_name,branch_add) values('" + txtcode.Text + "', '" + txtname.Text + "', '" + txtadd.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DispData()
        {
            conopen();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select branch_id,branch_code,branch_name,branch_add from user order by branch_id desc";
            cmd.ExecuteNonQuery();
            DataTable dtc = new DataTable();
            SqlDataAdapter dac = new SqlDataAdapter(cmd);
            dac.Fill(dtc);
            dataGridView1.DataSource = dtc;
            con.Close();

        }

        public void clear()
        {
            txtid.Clear();
            txtcode.Clear();
            txtname.Clear();
            txtadd.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtcode.Text != "" && txtname.Text != "" && txtadd.Text != "")
            {
                add();
                DispData();
                clear();
                txtcode.Focus();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtid.Text = row.Cells[0].Value.ToString();
                txtcode.Text = row.Cells[1].Value.ToString();
                txtname.Text = row.Cells[2].Value.ToString();
                txtadd.Text = row.Cells[3].Value.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Really Want to Update Item ??", txtid.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (txtid.Text != "" && txtcode.Text != "" && txtname.Text != "" && txtadd.Text != "")
                {

                    conopen();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE branch SET branch_code ='" + txtcode.Text + "', branch_name ='" + txtname.Text + "', branch_add ='" + txtadd.Text + "' where (branch_id ='" + txtid.Text + "')";

                    cmd.ExecuteNonQuery();
                    con.Close();
                    DispData();
                    MessageBox.Show("Data Updated!!");
                }else
                {
                    MessageBox.Show("Fill all detail");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Really Want to DELETE CUSTOMER ??", txtname.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (txtid.Text != "")
                {
                    conopen();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from user where id='" + txtid.Text + "'";

                    cmd.ExecuteNonQuery();

                    con.Close();
                    DispData();
                    MessageBox.Show("Branch deleted successfully");
                    clear();
                }
                else
                {
                    MessageBox.Show("Please Select All Details Properly Which You Want To Delete !!");
                }
            }
        }
    }
}

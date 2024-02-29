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
    public partial class F_User : Form
    {
        public F_User()
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
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void F_User_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDataSet1.Branch' table. You can move, or remove it, as needed.
            this.branchTableAdapter.Fill(this.bankDataSet1.Branch);

            DispData();
        }

        public void add()
        {
           
            conopen();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into UserTb (branch_id,name,pass,role) values('" + cbbranch.SelectedValue + "', '" + txtname.Text + "', '" + txtpass.Text + "', '" + cbrole.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbbranch.Text != "" && txtname.Text != "" && txtpass.Text != "" && cbrole.Text != "")
            {
                add();
                DispData();
                clear();
                cbbranch.Focus();

            }else
            {
                MessageBox.Show("Fill All Detail");
            }
        }

        public void clear()
        {
            txtid.Clear();
            cbbranch.ResetText();
            txtname.Clear();
            txtpass.Clear();
            cbrole.ResetText();
        }

        public void DispData()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id,branch_id,name,pass,role from userTb order by id desc";
            cmd.ExecuteNonQuery();
            DataTable dtc = new DataTable();
            SqlDataAdapter dac = new SqlDataAdapter(cmd);
            dac.Fill(dtc);
            dataGridView1.DataSource = dtc;
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Really Want to Update Item ??", txtid.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (txtid.Text != "" && cbbranch.Text != "" && txtname.Text != "" && txtpass.Text != "" && cbrole.Text != "")
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE userTb SET name ='" + txtname.Text + "', pass ='" + txtpass.Text + "', role ='" + cbrole.Text + "' where (id ='" + txtid.Text + "')";

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtid.Text = row.Cells[0].Value.ToString();
                cbbranch.Text = row.Cells[1].Value.ToString();
                txtname.Text = row.Cells[2].Value.ToString();
                txtpass.Text = row.Cells[3].Value.ToString();
                cbrole.Text = row.Cells[4].Value.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Really Want to DELETE CUSTOMER ??", txtname.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (txtid.Text != "")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from userTb where id='" + txtid.Text + "'";

                    cmd.ExecuteNonQuery();

                    con.Close();
                    DispData();
                    MessageBox.Show("User deleted successfully");
                    clear();
                }
                else
                {
                    MessageBox.Show("Please Select All Details Properly Which You Want To Delete !!");
                }
            }
        }

        private void cbbranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class F_Dash : Form
    {
        F_Login fl = new F_Login();
        public F_Dash()
        {
            InitializeComponent();

           
            fl.MdiParent = this;
            fl.Show();
            fl.Location = panel1.Location;
           // panel3.Visible = false;
            panel1.Visible = false;


            panel3.Height = button1.Height;
            panel3.Top = button1.Top;

          
            lbldate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
            
        }

        private void F_Dash_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }
       
        private void button1_Click_1(object sender, EventArgs e)
        {
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panel3.Top != button2.Top)
            {
                panel3.Height = button2.Height;
                panel3.Top = button2.Top;

                closeForm();

                F_FD fd = new F_FD();
                fd.MdiParent = this;
                fd.Show();
                fd.Location = panel1.Location;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbuid_TextChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;

            if(lburole.Text =="Admin")
            {
                button6.Enabled = true;
            }
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
           
        }

        public void closeForm()
        {
            
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "F_Dash")
                    Application.OpenForms[i].Close();
            }
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (panel3.Top != button1.Top)
            {
                panel3.Height = button1.Height;
                panel3.Top = button1.Top;

                closeForm();

                Form1 fs = new Form1();
                fs.MdiParent = this;
                fs.Show();
                fs.Location = panel1.Location;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel3.Top != button3.Top)
            {
                panel3.Height = button3.Height;
                panel3.Top = button3.Top;

                closeForm();

                F_Shared fsh = new F_Shared();
                fsh.MdiParent = this;
                fsh.Show();
                fsh.Location = panel1.Location;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel3.Top != button4.Top)
            {
                panel3.Height = button4.Height;
                panel3.Top = button4.Top;

                closeForm();

                F_Investment fi = new F_Investment();
                fi.MdiParent = this;
                fi.Show();
                fi.Location = panel1.Location;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panel3.Top != button5.Top)
            {
                panel3.Height = button5.Height;
                panel3.Top = button5.Top;

                closeForm();

                F_Loan flo = new F_Loan();
                flo.MdiParent = this;
                flo.Show();
                flo.Location = panel1.Location;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (panel3.Top != button6.Top)
            {
                panel3.Height = button6.Height;
                panel3.Top = button6.Top;

                closeForm();

                F_Investment fi = new F_Investment();
                fi.MdiParent = this;
                fi.Show();
                fi.Location = panel1.Location;
            }
        }
    }
}

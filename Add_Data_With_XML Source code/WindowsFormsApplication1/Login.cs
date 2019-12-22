using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == " your username")
            {
                txtUser.Clear();
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtPwd_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text == " your password")
            {
                txtPwd.Clear();
                txtPwd.ForeColor = Color.Black;
                txtPwd.PasswordChar = '*';
            }
        }

        private void PressEnter(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtUser.Text == "admin" && txtPwd.Text == "12345azert")
                {
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.Show();
                }
                else if (txtUser.Text == "kilya" && txtPwd.Text == "12345")
                {
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show(
                        "your username or password was incorrect !",
                        " -- Message Ereur --",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                        );
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // this.Cursor = Cursors.WaitCursor;
            if (txtUser.Text == "admin" && txtPwd.Text == "12345azert")
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
            else if (txtUser.Text == "kilya" && txtPwd.Text == "12345")
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                MessageBox.Show(
                    "your username or password was incorrect !",
                    " -- Message Ereur --",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressEnter(e);
            pictureBox3.Visible = true;
            pictureys2.Visible = true;
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressEnter(e);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtPwd.PasswordChar = '\0';
            // or :
            //txtPwd.PasswordChar = char.Parse("\0");
            pictureBox3.Visible = false;
            //pictureys2.Visible = true;
        }

        private void pictureys2_Click(object sender, EventArgs e)
        {
            txtPwd.PasswordChar = char.Parse("*");
            pictureBox3.Visible = true;
        }
    }
}

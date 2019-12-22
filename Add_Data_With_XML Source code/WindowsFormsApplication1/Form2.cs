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
    public partial class Form2 : Form
    {
        DataSet DS = new DataSet(); // Data Set
        public Form2()
        {
            InitializeComponent();
            DS.ReadXml("mydata.xml");
            dataGridView1.DataSource = DS.Tables[0];
        }

        // -- Start Methode --
            // Not Enter a Key Number 
            private static void Not_KeyNumber(KeyPressEventArgs e)
            {
                if (e.KeyChar > 48 && e.KeyChar < 57)
                {
                    e.Handled = false;
                }
            }
            // Not Enter a Key STring
            private static void Not_KeyString(KeyPressEventArgs e)
            {
                if (e.KeyChar < 48 || e.KeyChar > 57)
                {
                    e.Handled = true;
                }
            }
            // Show Message Added Succesfully
            private static void Message_Add()
            {
                MessageBox.Show(
                    "Data added successfully ...",
                    " -- Message --",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
            // Clear All textBox
            private void Clear_textBox()
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            // Color white default of All label 
            private void Color_White()
            {
                label1.ForeColor = Color.MediumAquamarine;
                label2.ForeColor = Color.MediumAquamarine;
                label3.ForeColor = Color.MediumAquamarine;
                label4.ForeColor = Color.MediumAquamarine;
            }
        // -- End Methode --

        // -- Start Button Add Data --
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != textBox5.Text)
            {
                label1.ForeColor = Color.MediumAquamarine;
                if (textBox2.Text != textBox5.Text)
                {
                    label2.ForeColor = Color.MediumAquamarine;
                    if (textBox3.Text != textBox5.Text)
                    {
                        label3.ForeColor = Color.MediumAquamarine;
                        if (textBox4.Text != textBox5.Text)
                        {
                            label4.ForeColor = Color.MediumAquamarine;
                            DataRow r = DS.Tables[0].NewRow();
                            r[0] = textBox1.Text;
                            r[1] = textBox2.Text;
                            r[2] = textBox3.Text;
                            r[3] = textBox4.Text;

                            DS.Tables[0].Rows.Add(r);
                            DS.WriteXml("mydata.xml");

                            Message_Add();
                            Clear_textBox();
                        }
                        else
                        {
                            label4.ForeColor = Color.DarkRed;
                            MessageBox.Show(
                                "Please complete data of Bedroom ...",
                                " -- Message --",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Exclamation
                                );
                        }
                    }
                    else
                    {
                        label3.ForeColor = Color.DarkRed;
                        MessageBox.Show(
                            "Please complete data of Age ...",
                            " -- Message --",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Exclamation
                            );
                    }
                }
                else
                {
                    label2.ForeColor = Color.DarkRed;
                    MessageBox.Show(
                        "Please complete data of Last name ...",
                        " -- Message --",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Exclamation
                        );
                }
            }
            else
            {
                label1.ForeColor = Color.DarkRed;
                MessageBox.Show(
                    "Please complete data of Name ...",
                    " -- Message --",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation
                    );
            }
        }
        // -- End Button Add Data --

        // -- Start Button Close --
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to close this Programme !",
                " -- Confirmation --",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation
                );
            if (result == DialogResult.OK)
                Application.Exit();
        }
        // -- End Button Close --

        // -- Start Button Escape --
        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                WindowState = FormWindowState.Minimized;
        }        
        // -- End Button Escape --

        // -- Start Button Logout --
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }
        // -- End Button Logout --

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Not_KeyString(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Not_KeyNumber(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Not_KeyNumber(e);
        }
    }
}

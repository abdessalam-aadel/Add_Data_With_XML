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
    public partial class Form1 : Form
    {
        DataSet DS = new DataSet(); // Data Set
        public Form1()
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
            // Show Message Delete Succesfully
            private static void Message_Del()
            {
                MessageBox.Show(
                    "Data to be deleted successfully ...",
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
            // Color white defeult of All label 
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
            label6.Visible = false;
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

        // -- Start Button Delete Data --
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                if (textBox1.Text == DS.Tables[0].Rows[i][0].ToString())
                {
                    if (textBox2.Text == DS.Tables[0].Rows[i][1].ToString())
                    {
                        if (textBox3.Text == DS.Tables[0].Rows[i][2].ToString())
                        {
                            if (textBox4.Text == DS.Tables[0].Rows[i][3].ToString())
                            {
                                label6.Visible = false;
                                DialogResult result = MessageBox.Show(
                                "Are you sure you want to delete this Current Row !",
                                " -- Confirmation --",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Exclamation
                                );
                                if (result == DialogResult.Yes)
                                {
                                    DS.Tables[0].Rows[i].Delete();
                                    DS.WriteXml("mydata.xml");
                                    Message_Del();
                                    Clear_textBox();
                                    Color_White();
                                }
                                else
                                    label6.Visible = false;

                            }
                            else
                            {
                                label6.Visible = true;
                                label6.Text = "You have changed" + Environment.NewLine + "Data of Bedroom !";
                            }
                        }
                        else
                        {
                            label6.Visible = true;
                            label6.Text = "You have changed" + Environment.NewLine + "Data of Age !";
                        }
                    }
                    else
                    {
                        label6.Visible = true;
                        label6.Text = "You have changed" + Environment.NewLine + "Data of Last name !";
                    }
                }
                else
                {
                    label6.Visible = true;
                }
            }    
           
        }
        // -- End Button Delete Data --

        // -- Start Button Update Data --
        private void update_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                if (textBox1.Text == DS.Tables[0].Rows[i][0].ToString())
                {
                    DataRow r = DS.Tables[0].Rows[i];
                    r[0] = textBox1.Text;
                    r[1] = textBox2.Text;
                    r[2] = textBox3.Text;
                    r[3] = textBox4.Text;

                    DS.WriteXml("mydata.xml");
                    MessageBox.Show("Update successfully !", " -- Message --");
                    Clear_textBox();
                    label6.Visible = false;
                    Color_White();
                }
            }
        }
        // -- Start Button Update Data --

        // -- Start Button Save Change in Data Grid View --
        private void button4_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            Color_White();
            DS.Tables[0].Rows[0].AcceptChanges();
            DS.WriteXml("mydata.xml");
        }
        // -- Start Button Save Change in Data Grid View --

        // -- Start Button Quiter --
        private void button3_Click(object sender, EventArgs e)
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
        // -- End Button Quiter --

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Not_KeyNumber(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Not_KeyNumber(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Not_KeyString(e);
        }
        
        // Show Data of dataGridView in TextBox
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();   
        }
        // Form Closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show(
            //    "Are you sur to close this Programme ! ",
            //    "Confirmation",
            //    MessageBoxButtons.OKCancel,
            //    MessageBoxIcon.Exclamation
            //    );
            //if (result == DialogResult.Cancel)
            //{
            //    e.Cancel = true;
            //}
        }

        // -- Start Button Escape --
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                WindowState = FormWindowState.Minimized;
        }
        // -- End Button Escape --

        // -- Start Button Logout --
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }
        // -- End Button Logout --
    }
}

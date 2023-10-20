using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BloodBank
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox_name.Text != "" && this.textBox_pass.Text != "" && this.textBox_phone.Text != "" && this.textBox_age.Text != "" && this.textBox_bg.Text != "" && this.textBox_email.Text != "" && this.textBox_loc.Text != "")
            {
                Database.register(this.textBox_name.Text, this.textBox_bg.Text, this.textBox_loc.Text, this.textBox_age.Text,this.textBox_phone.Text ,this.textBox_email.Text ,this.textBox_pass.Text, "donordata");
            }
            else
            {
                MessageBox.Show("Are you missing any box?? insert all boxes!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox_rname.Text != "" && this.textBox_rPass.Text != "" && this.textBox_rphone.Text != "" && this.textBox_rage.Text != "" && this.textBox_rbg.Text != "" && this.textBox_remail.Text != "" && this.textBox_rloc.Text != "")
            {
                Database.register(this.textBox_rname.Text, this.textBox_rbg.Text, this.textBox_rloc.Text, this.textBox_rage.Text,this.textBox_rphone.Text ,this.textBox_remail.Text ,this.textBox_rPass.Text, "recieverdata");
            }
            else
            {
                MessageBox.Show("Are you missing any box?? insert all boxes! please");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
    }
}

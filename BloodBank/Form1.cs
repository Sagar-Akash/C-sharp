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
using System.Threading;
namespace BloodBank
{
    public partial class Form1 : Form
    {

      
        public Form1()
        {
         
            InitializeComponent();
       
        }
 
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Green;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Green;
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Green;
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Green;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration obj = new Registration();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] acknowlegment = Database.login("recieverdata", textBox2.Text, textBox1.Text);

            if (acknowlegment == null)
            {
                label4.Visible = true;
                MessageBox.Show("UserName/Password error!");

            }
            else if (acknowlegment[0] != "")
            {
                Profile obj = new Profile(acknowlegment[1], acknowlegment[2]);
                obj.Show();
                this.Hide();
            }
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration obj = new Registration();
            obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] acknowlegment = Database.login("donordata", textBox_phone.Text, textBox_Passs.Text);

            if (acknowlegment[0] != " ") 
            {
                donor_profile obj = new donor_profile(Convert.ToInt32(acknowlegment[0]));
                obj.Show();
                this.Hide();
            }
            else
            {
                label4.Visible = true;
                MessageBox.Show("UserName/Password error ui!");
            }

        }
    }
}

using System;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            {
                if (txtUsername.Text == "admin" && txtPassword.Text == "123")
                {
                    this.Hide();
                    Form2 calcForm = new Form2();

                    calcForm.FormClosed += (s, args) => this.Close();
                    calcForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
            }


        }
    }
}
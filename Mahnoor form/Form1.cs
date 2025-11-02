using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mahnoor_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Simple username & password check
            if (username == "admin" && password == "1234")
            {
                // Open HomePage and hide this form
                HomePage home = new HomePage(username);
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Invalid username or password!",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

    }
}
}

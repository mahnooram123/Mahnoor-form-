using Mahnoor_form;
using System;
using System.Windows.Forms;

namespace WinFormsLoginApp   // ✅ Must match Program.cs namespace
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Simple username & password check
            if (username == "admin" && password == "1234")
            {
                // Open HomePage and hide login form
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

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Ensures the app closes properly when LoginForm is closed
            Application.Exit();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(484, 244);
            this.Name = "LoginForm";
            this.ResumeLayout(false);

        }
    }
}

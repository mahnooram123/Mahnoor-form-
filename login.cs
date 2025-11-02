using System;
using System.Windows.Forms;

namespace Booksystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Event handlers
        private void btnLogin_Click(object? sender, EventArgs e)
        {
            var user = txtUsername.Text.Trim();
            var pass = txtPassword.Text;

            if (user == "admin" && pass == "admin")
            {
                this.Hide();
                var dash = new DashboardForm();
                dash.FormClosed += (s, args) => this.Close();
                dash.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Try admin / admin", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        // Manual InitializeComponent (no Designer needed)
        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnExit = new Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Size = new System.Drawing.Size(360, 30);
            this.lblTitle.Text = "Library Login";

            // lblUsername
            this.lblUsername.Location = new System.Drawing.Point(12, 60);
            this.lblUsername.Size = new System.Drawing.Size(80, 23);
            this.lblUsername.Text = "Username:";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(100, 57);
            this.txtUsername.Size = new System.Drawing.Size(200, 23);

            // lblPassword
            this.lblPassword.Location = new System.Drawing.Point(12, 95);
            this.lblPassword.Size = new System.Drawing.Size(80, 23);
            this.lblPassword.Text = "Password:";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(100, 92);
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(100, 135);
            this.btnLogin.Size = new System.Drawing.Size(90, 30);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(210, 135);
            this.btnExit.Size = new System.Drawing.Size(90, 30);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new EventHandler(this.btnExit_Click);

            // LoginForm
            this.ClientSize = new System.Drawing.Size(384, 191);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "LoginForm";
            this.Text = "Library Login";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Fields (manual, null-forgiving to remove warnings)
        private Label lblTitle = null!;
        private Label lblUsername = null!;
        private Label lblPassword = null!;
        private TextBox txtUsername = null!;
        private TextBox txtPassword = null!;
        private Button btnLogin = null!;
        private Button btnExit = null!;
    }
}
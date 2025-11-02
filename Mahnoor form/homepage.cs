using System;
using System.Windows.Forms;
using System.Drawing;  // Needed for color customization

namespace WinFormsLoginApp   // ✅ Must match the same namespace as LoginForm.cs
{
    public partial class HomePage : Form
    {
        private string _username;  // To store the logged-in user's name

        // Constructor that receives the username from LoginForm
        public HomePage(string username)
        {
            InitializeComponent();
            _username = username;
        }

        // When HomePage loads
        private void HomePage_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {_username}! 👋";

            // Set background color (change it for originality)
            this.BackColor = Color.LightSeaGreen;

            // Optional: Set title text
            this.Text = $"Home - {_username}";
        }

        // Logout button click
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Open login form again and close homepage
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        // Profile button click
        private void btnProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Profile Page — (You can design this later)", "Profile");
        }

        // Settings button click
        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings Page — (You can design this later)", "Settings");
        }

        // Ensures app closes if this form is closed directly
        private void HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}

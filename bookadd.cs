using Booksytsem;
using System;
using System.Windows.Forms;

namespace Booksystem
{
    public partial class AddBookForm : Form
    {
        public event EventHandler<Book> BookAdded;

        // Controls
        private Label lblAddTitle = null!;
        private Label lblBookTitle = null!;
        private Label lblBookAuthor = null!;
        private TextBox txtBookTitle = null!;
        private TextBox txtBookAuthor = null!;
        private Button btnAdd = null!;
        private Button btnCancel = null!;

        public AddBookForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            var title = txtBookTitle.Text.Trim();
            var author = txtBookAuthor.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a book title.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var book = LibraryData.AddBook(title, author);
            BookAdded?.Invoke(this, book);
            MessageBox.Show("Book added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            lblAddTitle = new Label();
            lblBookTitle = new Label();
            lblBookAuthor = new Label();
            txtBookTitle = new TextBox();
            txtBookAuthor = new TextBox();
            btnAdd = new Button();
            btnCancel = new Button();

            // Form properties
            this.ClientSize = new System.Drawing.Size(364, 191);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "AddBookForm";
            this.Text = "Add New Book";

            // lblAddTitle
            lblAddTitle.Text = "Add New Book";
            lblAddTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblAddTitle.Location = new System.Drawing.Point(12, 9);
            lblAddTitle.Size = new System.Drawing.Size(360, 25);

            // lblBookTitle
            lblBookTitle.Text = "Title:";
            lblBookTitle.Location = new System.Drawing.Point(12, 50);
            lblBookTitle.Size = new System.Drawing.Size(60, 23);

            // txtBookTitle
            txtBookTitle.Location = new System.Drawing.Point(80, 47);
            txtBookTitle.Size = new System.Drawing.Size(260, 23);

            // lblBookAuthor
            lblBookAuthor.Text = "Author:";
            lblBookAuthor.Location = new System.Drawing.Point(12, 90);
            lblBookAuthor.Size = new System.Drawing.Size(60, 23);

            // txtBookAuthor
            txtBookAuthor.Location = new System.Drawing.Point(80, 87);
            txtBookAuthor.Size = new System.Drawing.Size(260, 23);

            // btnAdd
            btnAdd.Text = "Add Book";
            btnAdd.Location = new System.Drawing.Point(80, 130);
            btnAdd.Size = new System.Drawing.Size(90, 30);
            btnAdd.Click += new EventHandler(btnAdd_Click);

            // btnCancel
            btnCancel.Text = "Cancel";
            btnCancel.Location = new System.Drawing.Point(210, 130);
            btnCancel.Size = new System.Drawing.Size(90, 30);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            // Add controls to form
            this.Controls.Add(lblAddTitle);
            this.Controls.Add(lblBookTitle);
            this.Controls.Add(txtBookTitle);
            this.Controls.Add(lblBookAuthor);
            this.Controls.Add(txtBookAuthor);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnCancel);
        }
    }
}
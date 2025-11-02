using Booksystem;
using Booksytsem;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Booksystem
{
    public partial class DashboardForm : Form
    {
        private BindingList<Book> booksBinding;

        public DashboardForm()
        {
            InitializeComponent();
            LoadBooksGrid();
        }

        private void LoadBooksGrid()
        {
            // bind to a BindingList so grid updates when list objects change
            booksBinding = new BindingList<Book>(LibraryData.Books);
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.DataSource = booksBinding;
            // define columns if not already defined
            dgvBooks.Columns.Clear();

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                ReadOnly = true
            });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                ReadOnly = true,
                Width = 200
            });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Author",
                HeaderText = "Author",
                ReadOnly = true,
                Width = 150
            });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Availability",
                HeaderText = "Status",
                ReadOnly = true
            });
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            var add = new AddBookForm();
            add.BookAdded += (s, book) =>
            {
                // refresh binding
                booksBinding.ResetBindings();
            };
            add.ShowDialog();
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            var borrow = new BorrowBookForm();
            borrow.ShowDialog();
            booksBinding.ResetBindings();
        }

        private void btnViewBorrowed_Click(object sender, EventArgs e)
        {
            var view = new ViewBorrowedForm();
            view.ShowDialog();
            booksBinding.ResetBindings();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // LoginForm was hidden and will close when Dashboard closed
        }

        private void InitializeComponent()
        {
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnBorrowBook = new System.Windows.Forms.Button();
            this.btnViewBorrowed = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();



            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDashboardTitle.Location = new System.Drawing.Point(12, 9);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(600, 25);
            this.lblDashboardTitle.Text = "Main Dashboard";


            this.btnAddBook.Location = new System.Drawing.Point(16, 45);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(110, 35);
            this.btnAddBook.Text = "Add Book";
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);

            this.btnBorrowBook.Location = new System.Drawing.Point(136, 45);
            this.btnBorrowBook.Name = "btnBorrowBook";
            this.btnBorrowBook.Size = new System.Drawing.Size(110, 35);
            this.btnBorrowBook.Text = "Borrow Book";
            this.btnBorrowBook.Click += new System.EventHandler(this.btnBorrowBook_Click);



            this.btnViewBorrowed.Location = new System.Drawing.Point(256, 45);
            this.btnViewBorrowed.Name = "btnViewBorrowed";
            this.btnViewBorrowed.Size = new System.Drawing.Size(140, 35);
            this.btnViewBorrowed.Text = "View Borrowed Books";
            this.btnViewBorrowed.Click += new System.EventHandler(this.btnViewBorrowed_Click);



            this.btnLogout.Location = new System.Drawing.Point(420, 45);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 35);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.dgvBooks.Location = new System.Drawing.Point(16, 95);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.Size = new System.Drawing.Size(640, 300);
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.ClientSize = new System.Drawing.Size(680, 420);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewBorrowed);
            this.Controls.Add(this.btnBorrowBook);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.lblDashboardTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DashboardForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnBorrowBook;
        private System.Windows.Forms.Button btnViewBorrowed;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvBooks;
    }
}
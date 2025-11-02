
using Booksytsem;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Booksystem
{
    public partial class BorrowBookForm : Form
    {
        private BindingList<Book> availableBinding;

        public BorrowBookForm()
        {
            InitializeComponent();
            LoadAvailableBooks();
        }

        private void LoadAvailableBooks()
        {
            var avail = LibraryData.Books.Where(b => b.Availability == "Available").ToList();
            availableBinding = new BindingList<Book>(avail);
            dgvAvailableBooks.AutoGenerateColumns = false;
            dgvAvailableBooks.DataSource = availableBinding;

            dgvAvailableBooks.Columns.Clear();
            dgvAvailableBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID" });
            dgvAvailableBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "Title", Width = 220 });
            dgvAvailableBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Author", HeaderText = "Author", Width = 170 });
        }

        private void btnBorrowSelected_Click(object? sender, EventArgs e)
        {
            if (dgvAvailableBooks.CurrentRow == null)
            {
                MessageBox.Show("Select a book to borrow.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var book = dgvAvailableBooks.CurrentRow.DataBoundItem as Book;
            if (book == null) return;

            var ok = LibraryData.BorrowBook(book.Id);
            if (ok)
            {
                MessageBox.Show($"'{book.Title}' borrowed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAvailableBooks(); // refresh list
            }
            else
            {
                MessageBox.Show("Could not borrow the selected book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelBorrow_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.lblBorrowTitle = new Label();
            this.dgvAvailableBooks = new DataGridView();
            this.btnBorrowSelected = new Button();
            this.btnCancelBorrow = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBorrowTitle
            this.lblBorrowTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBorrowTitle.Location = new System.Drawing.Point(12, 9);
            this.lblBorrowTitle.Size = new System.Drawing.Size(400, 25);
            this.lblBorrowTitle.Text = "Borrow Book";
            // 
            // dgvAvailableBooks
            this.dgvAvailableBooks.Location = new System.Drawing.Point(16, 45);
            this.dgvAvailableBooks.Size = new System.Drawing.Size(520, 260);
            this.dgvAvailableBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableBooks.ReadOnly = true;
            this.dgvAvailableBooks.AllowUserToAddRows = false;
            // 
            // btnBorrowSelected
            this.btnBorrowSelected.Location = new System.Drawing.Point(120, 320);
            this.btnBorrowSelected.Size = new System.Drawing.Size(120, 35);
            this.btnBorrowSelected.Text = "Borrow Selected";
            this.btnBorrowSelected.Click += new EventHandler(this.btnBorrowSelected_Click);
            // 
            // btnCancelBorrow
            this.btnCancelBorrow.Location = new System.Drawing.Point(280, 320);
            this.btnCancelBorrow.Size = new System.Drawing.Size(90, 35);
            this.btnCancelBorrow.Text = "Cancel";
            this.btnCancelBorrow.Click += new EventHandler(this.btnCancelBorrow_Click);
            // 
            // BorrowBookForm
            this.ClientSize = new System.Drawing.Size(560, 370);
            this.Controls.Add(this.btnCancelBorrow);
            this.Controls.Add(this.btnBorrowSelected);
            this.Controls.Add(this.dgvAvailableBooks);
            this.Controls.Add(this.lblBorrowTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "BorrowBookForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableBooks)).EndInit();
            this.ResumeLayout(false);
        }

        // Fields
        private Label lblBorrowTitle = null!;
        private DataGridView dgvAvailableBooks = null!;
        private Button btnBorrowSelected = null!;
        private Button btnCancelBorrow = null!;
    }
}

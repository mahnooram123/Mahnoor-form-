using Booksytsem;
using System.Collections.Generic;
using System.Linq;

namespace Booksystem
{
    public static class LibraryData
    {
        public static List<Book> Books { get; private set; } = new List<Book>();
        public static List<Book> BorrowedBooks { get; private set; } = new List<Book>();

        private static int nextId = 1;

        public static void InitializeSampleBooks()
        {
            // add some sample books only if list empty
            if (Books.Any()) return;

            AddBook("C# Programming", "Author A");
            AddBook("Introduction to Databases", "Author B");
            AddBook("Algorithms Unlocked", "Author C");
            AddBook("Discrete Mathematics", "Author D");
        }

        public static Book AddBook(string title, string author)
        {
            var book = new Book
            {
                Id = nextId++,
                Title = title,
                Author = author,
                IsAvailable = true
            };
            Books.Add(book);
            return book;
        }

        public static bool BorrowBook(int bookId)
        {
            var book = Books.Find(b => b.Id == bookId);
            if (book == null || !book.IsAvailable) return false;
            book.IsAvailable = false;
            BorrowedBooks.Add(book);
            return true;
        }

        public static bool ReturnBook(int bookId)
        {
            var book = BorrowedBooks.Find(b => b.Id == bookId);
            if (book == null) return false;
            book.IsAvailable = true;
            BorrowedBooks.Remove(book);
            return true;
        }
    }
}
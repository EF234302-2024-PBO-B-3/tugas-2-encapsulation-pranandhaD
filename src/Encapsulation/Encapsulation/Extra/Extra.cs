using System;
using System.Collections.Generic;

namespace Encapsulation.Extra
{
    public class Book
    {
        public string ISBN { get; }
        public string Title { get; }
        public string Author { get; }
        public bool IsAvailable { get; private set; }

        public Book(string isbn, string title, string author)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            IsAvailable = true;
        }

        public void BorrowBook()
        {
            IsAvailable = false;
        }

        public void ReturnBook()
        {
            IsAvailable = true;
        }
    }

    public class Library
    {
        private List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
        }

        public void AddBook(string isbn, string title, string author)
        {
            if (string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("ISBN, title, and author must not be empty.");
            }

            if (_books.Exists(b => b.ISBN == isbn))
            {
                throw new ArgumentException("A book with this ISBN already exists in the library.");
            }

            _books.Add(new Book(isbn, title, author));
        }

        public bool BorrowBook(string isbn)
        {
            var book = _books.Find(b => b.ISBN == isbn);
            if (book != null && book.IsAvailable)
            {
                book.BorrowBook();
                return true;
            }
            return false;
        }

        public bool ReturnBook(string isbn)
        {
            var book = _books.Find(b => b.ISBN == isbn);
            if (book != null && !book.IsAvailable)
            {
                book.ReturnBook();
                return true;
            }
            return false;
        }

        public List<Book> GetAvailableBooks()
        {
            return _books.FindAll(b => b.IsAvailable);
        }

        public int GetTotalBooks()
        {
            return _books.Count;
        }
    }
}
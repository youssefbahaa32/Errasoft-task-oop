using System;
using System.Collections.Generic;

namespace Errasoft_task_oop
{
    class Book
    {
        string title;
        string author;
        int isbn;
        bool available;

        public Book(string title, string author, int isbn, bool available = true)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.available = available;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public bool Av
        {
            get { return available; }
            set { available = value; }
        }
    }

    class Library
    {
        List<Book> books = new List<Book>();

        public void Add(Book book)
        {
            books.Add(book);
        }

        public Book Search(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == title)
                    return books[i];
            }
            return null;
        }

        public bool Borrow(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == title && books[i].Av)
                {
                    books[i].Av = false;
                    return true;
                }
            }
            return false;
        }

        public bool Return(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == title && !books[i].Av)
                {
                    books[i].Av = true;
                    return true;
                }
            }
            return false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", 978074325));
            library.Add(new Book("To Kill a Mockingbird", "Harper Lee", 90061120));
            library.Add(new Book("1984", "George Orwell", 97804515));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.Borrow("Gatsby");
            library.Borrow("1984");
            library.Borrow("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.Return("Gatsby");
            library.Return("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}

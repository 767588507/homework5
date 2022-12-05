using System;
using BooksDB;
using System.Linq;
using System.Collections.Generic;

namespace BookDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            BookDAL sd = new BookDAL();
            foreach (Book x in sd.GetAllBooks())
            {
                Console.WriteLine($"书名为{x.Title},作者是{x.Author}");
            }
            Book b = new Book();
            b.Title = "水浒传";
            b.Author = "施耐庵";

            sd.InsertBook(b);
            foreach (Book x in sd.GetAllBooks())
            {
                Console.WriteLine($"学书名为{x.Title},作者是{x.Author}");
            }

            //sd.DeleteBook(b);
            //foreach (Book x in sd.GetAllBooks())
            //{
            //    Console.WriteLine($"书名为{x.Title},作者是{x.Author}");
            //}
        }
    }
    public class BookDAL
    {
        public bool InsertBook(Book b)
        {
            try
            {
                using (BooksContext db = new BooksContext())
                {
                    db.Books.Add(b);
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteBook(Book b)
        {
            try
            {
                using (BooksContext db = new BooksContext())
                {
                    var temp = db.Books.Find(new object[] { b.Id });
                    db.Books.Remove(temp);
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateBook(Book olds, Book news)
        {
            try
            {
                using (BooksContext db = new BooksContext())
                {
                    var temp = db.Books.Find(new object[] { olds.Id });
                    temp = news;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Book> GetAllBooks()
        {
            try
            {
                using (BooksContext db = new BooksContext())
                {
                    return db.Books.ToList<Book>();
                }
            }
            catch
            {
                return null;
            }
        }
        public Book SelectBook(string _Title)
        {
            try
            {
                using (BooksContext db = new BooksContext())
                {
                    var temp = (from b in db.Books
                                where b.Title == _Title
                                select b).FirstOrDefault();

                    return temp;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using GoodBooks.Data.Database;
using GoodBooks.Data.Models;

namespace GoodBooks.Services
{
    public class BookService : IBookService
    {
        private readonly GoodBooksDbContext db;

        public BookService(GoodBooksDbContext db)
        {
            this.db = db;
        }

        public void AddBook(Book book)
        {
            db.Add(book);
            db.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {            
            db.Books.Remove(GetBookById(bookId));
            db.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            return db.Books.Find(bookId);
        }
    }
}

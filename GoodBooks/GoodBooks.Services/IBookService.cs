using System.Collections.Generic;
using GoodBooks.Data.Models;

namespace GoodBooks.Services
{
    public interface IBookService
    {
        public void AddBook(Book book);
        public IEnumerable<Book> GetAllBooks();
        public Book GetBookById(int bookId);
        public void UpdateBook(Book book);
        public void DeleteBook(int bookId);
    }
}
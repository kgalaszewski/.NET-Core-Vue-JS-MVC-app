using System.Collections.Generic;
using GoodBooks.Data.Models;

namespace GoodBooks.Services
{
    public interface IBookService
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetBookById(int bookId);
        public void AddBook(Book book);
        public void DeleteBook(int bookId);
    }
}
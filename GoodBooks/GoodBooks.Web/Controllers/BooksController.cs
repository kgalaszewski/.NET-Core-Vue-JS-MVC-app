using GoodBooks.Data.Models;
using GoodBooks.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodBooks.Web.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // CREATE 
        [HttpPost("/api/books")]
        public IActionResult CreateBook(Book book)
        {
            bookService.AddBook(book);
            return Ok($"Created book with Id : {book?.Id}");
        }

        // READ
        [HttpGet("/api/books")]
        public IActionResult GetBooks()
        {
            return Ok(bookService.GetAllBooks());
        }

        [HttpGet("/api/books/{Id}")]
        public IActionResult GetBookById(int Id)
        {
            return Ok(bookService.GetBookById(Id));
        }

        // UPDATE
        [HttpPut("/api/books")]
        public IActionResult UpdateBook(Book book)
        {
            bookService.UpdateBook(book);
            return Ok(book);
        }

        // DELETE
        [HttpDelete("/api/books/{Id}")]
        public IActionResult DeleteBook(int Id)
        {
            bookService.DeleteBook(Id);
            return Ok($"Deleted book with Id {Id}");
        }
    }
}
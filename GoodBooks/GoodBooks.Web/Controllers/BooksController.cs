using Microsoft.AspNetCore.Mvc;

namespace GoodBooks.Web.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("/api/books")]
        public IActionResult GetBooks()
        {
            return Ok("Books");
        }
    }
}

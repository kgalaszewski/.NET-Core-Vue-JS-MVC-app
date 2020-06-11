using GoodBooks.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodBooks.Data.Database
{
    public class GoodBooksDbContext : DbContext
    {
        public GoodBooksDbContext()
        {

        } 

        public GoodBooksDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
    }
}
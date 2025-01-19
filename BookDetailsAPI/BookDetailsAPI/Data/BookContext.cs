using BookDetailsAPI.Models;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace BookDetailsAPI.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<BookDetailsAPI.Models.Book> Books { get; set; }
    }
}

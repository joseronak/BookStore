using Microsoft.EntityFrameworkCore;

namespace BookStoreTry.Models
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Transactions> Transactions { get; set; }


    }
}

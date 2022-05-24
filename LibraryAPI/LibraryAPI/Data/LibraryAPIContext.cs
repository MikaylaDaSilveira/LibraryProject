using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;

namespace LibraryAPI.Data
{
    public class LibraryAPIContext : DbContext //change to libraryContext
    {
        public LibraryAPIContext(DbContextOptions<LibraryAPIContext> options) : base(options)
        {
        }
        public DbSet<BookInfo> BookInfos { get; set; }
        public DbSet<BookStock> BookStocks { get; set; }

        //collection of todoItems in database, change to BDSet<LibraryItem> LibraryItems, need to create a libraryItem class too
    }
}

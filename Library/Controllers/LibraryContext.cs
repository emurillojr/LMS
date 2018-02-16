using Library.Models;
using Microsoft.EntityFrameworkCore; // DbContext

namespace Library.Controllers
{
    public class LibraryContext : DbContext  // inherits from entity frameworks DbContext abstract base class
    {
        // constructor to pass Context Options to
        public LibraryContext(DbContextOptions options) : base(options) { } // take options and pass to base class constructor
        // added DbSet for all the tables / public DBSet for each of the entity models defined
       // public DbSet<Book> Books { get; set; } // not a table  - inside / part of LibraryAsset since it inherits that class
       // public DbSet<Video> Videos { get; set; } // not a table  - inside / part of LibraryAsset since it inherits that class
        public DbSet<Branch> LibraryBranches { get; set; }
        public DbSet<Patron> Patrons { get; set; } // Created a set of DB Entity that can work with 'Patron' instances in a table, Patron object
        public DbSet<Asset> LibraryAssets { get; set; }
    }
}

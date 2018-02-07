using LibraryData.Models; // access to objects
using Microsoft.EntityFrameworkCore; // DbContext

namespace LibraryData
{
    public class LibraryContext: DbContext  // abstract base class provided by entity framework, inherit DbContext 
    {
        // constructor
        public LibraryContext(DbContextOptions options) : base(options) { } // take options and pass to base class constructor
        // added DbSet for all the tables
        public DbSet<Book> Books { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        public DbSet<LibraryBranch> LibraryBranches { get; set; }
        public DbSet<BranchHours> BranchHours { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<Patron> Patrons { get; set; } // Created a set of DB Entity that can work with 'Patron' instances in a table, Patron object
        public DbSet<Status> Statuses { get; set; }
        public DbSet<LibraryAsset> LibraryAssets { get; set; }
        public DbSet<Hold> Holds { get; set; }
    }
}

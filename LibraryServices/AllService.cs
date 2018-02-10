using LibraryData; // LibraryContext
using LibraryData.Models;  // ICheckout
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class AllService : IAll
    {
        private LibraryContext _context; // reference to DBContext

        public AllService(LibraryContext context) // constructor 
        {
            _context = context;
        }

        public IEnumerable<Patron> GetAllPatrons()
        {
            return _context.Patrons // returns collection of all patrons in database
                .Include(patron => patron.LibraryCard) // include in query Library Card entity
                .Include(patron => patron.HomeLibraryBranch); // include in query Home Library Branch entity           
        }

        public IEnumerable<LibraryBranch> GetAllLibraryBranches()
        {
            return _context.LibraryBranches
                .Include(b => b.Patrons)
                .Include(b => b.LibraryAssets);
        }

        public IEnumerable<LibraryAsset> GetAllLibraryAssets()
        {
            return _context.LibraryAssets // returns collection of all assets in database
                .Include(asset => asset.Status) // include entity - in query the status
                .Include(asset => asset.Location); // include entity - in query the location
        }

        //public string GetType(int id)
        //{
        //    var book = _context.LibraryAssets.OfType<Book>()
        //        .Where(b => b.Id == id);

        //    //return book.Any() ? "Book" : "Video" : "Magazine" : "Newspaper";
        //    return book.Any() ? "Book" : "Video";
        //}
    }
}

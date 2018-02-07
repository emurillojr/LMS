using LibraryData; // implement interface
using LibraryData.Models; // implement interface
using Microsoft.EntityFrameworkCore; // .Include
using System.Collections.Generic;
using System.Linq; // .FirstOrDefault

namespace LibraryServices
{
    public class PatronService : IPatron // implement interface
    {
        private LibraryContext _context; // reference to DBContext

        public PatronService(LibraryContext context) // constructor 
        {
            _context = context;
        }

        public void Add(Patron newPatron)
        {
            _context.Add(newPatron); // add an instance of a new patron
            _context.SaveChanges(); // commit changes to the database
        }

        public Patron Get(int id)
        {
            return 
                //_context.Patrons
                //.Include(patron => patron.LibraryCard)
                //.Include(patron => patron.HomeLibraryBranch)
                GetAll()
                .FirstOrDefault(patron => patron.Id == id);  // return null otherwise first instance of collection
        }

        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons // returns collection of all patrons in database
                .Include(patron => patron.LibraryCard) // include in query Library Card entity
                .Include(patron => patron.HomeLibraryBranch); // include in query Home Library Branch entity           
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int patronId)
        {
            var cardId = Get(patronId).LibraryCard.Id;
                //_context.Patrons  // get patron
                //.Include(patron => patron.LibraryCard)  // include in query Library Card entity
                //.FirstOrDefault(patron => patron.Id == patronId) 
                //.LibraryCard.Id; // get library card id

            return _context.CheckoutHistories
                .Include(co => co.LibraryCard)
                .Include(co => co.LibraryAsset)
                .Where(co => co.LibraryCard.Id == cardId)
                .OrderByDescending(co => co.CheckedOut);
        }

        public IEnumerable<Checkout> GetCheckouts(int patronId)
        {
            var cardId = Get(patronId).LibraryCard.Id;
                //_context.Patrons  // get patron
                //.Include(patron => patron.LibraryCard)  // include in query Library Card entity
                //.FirstOrDefault(patron => patron.Id == patronId)
                //.LibraryCard.Id; // get library card id

            return _context.Checkouts
                .Include(co => co.LibraryCard)
                .Include(co => co.LibraryAsset)
                .Where(co => co.LibraryCard.Id == cardId);
        }

        public IEnumerable<Hold> GetHolds(int patronId)
        {
            var cardId = Get(patronId).LibraryCard.Id;

            return _context.Holds
                .Include(h => h.LibraryCard)
                .Include(h => h.LibraryAsset)
                .Where(h => h.LibraryCard.Id == cardId)
                .OrderByDescending(h => h.HoldPlaced);
        }
    }
}

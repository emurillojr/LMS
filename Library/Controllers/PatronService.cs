using Library.Interfaces;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    public class PatronService : IPatron // implement interface
    {
        private LibraryContext _context; // reference to DBContext

        public PatronService(LibraryContext context) // constructor 
        {
            _context = context;
        }
        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons // returns collection of all patrons in database
                .Include(patron => patron.HomeLibraryBranch); // include in query Home Library Branch entity           
        }

        Patron IPatron.Get(int id)
        {
            return _context.Patrons
                .Include(patron => patron.HomeLibraryBranch).FirstOrDefault(patron => patron.Id == id);
        }

        IEnumerable<Patron> IPatron.GetAll()
        {
            return  _context.Patrons // returns collection of all patrons in database
                .Include(patron => patron.HomeLibraryBranch); // include in query Home Library Branch entity 
        }
    }
}

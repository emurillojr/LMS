using Library.Interfaces;
using Library.Models;
using Library.Models.Asset;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    public class LibraryBranchService : ILibraryBranch
    {
        private LibraryContext _context; // private field to store the context.

        public LibraryBranchService(LibraryContext context)
        {
            _context = context;
        }

        LibraryBranch ILibraryBranch.Get(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.Patrons)
                .Include(b => b.LibraryAssets).FirstOrDefault(b => b.Id == branchId);
        }

        IEnumerable<LibraryBranch> ILibraryBranch.GetAll()
        {
            return _context.LibraryBranches
                .Include(b => b.Patrons)
                .Include(b => b.LibraryAssets);
        }

        IEnumerable<LibraryAsset> ILibraryBranch.GetAssets(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.LibraryAssets)
                .FirstOrDefault(b => b.Id == branchId)
                .LibraryAssets;
        }

        IEnumerable<Patron> ILibraryBranch.GetPatrons(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.Patrons)
                .FirstOrDefault(b => b.Id == branchId)
                .Patrons;
        }
    }
}

using Library.Interfaces;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    public class BranchService : IBranch
    {
        private LibraryContext _context; // private field to store the context.

        public BranchService(LibraryContext context)
        {
            _context = context;
        }

        Branch IBranch.Get(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.Patrons)
                .Include(b => b.LibraryAssets).FirstOrDefault(b => b.Id == branchId);
        }

        IEnumerable<Branch> IBranch.GetAll()
        {
            return _context.LibraryBranches
                .Include(b => b.Patrons)
                .Include(b => b.LibraryAssets);
        }

        IEnumerable<Asset> IBranch.GetAssets(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.LibraryAssets)
                .FirstOrDefault(b => b.Id == branchId)
                .LibraryAssets;
        }

        IEnumerable<Patron> IBranch.GetPatrons(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.Patrons)
                .FirstOrDefault(b => b.Id == branchId)
                .Patrons;
        }
    }
}

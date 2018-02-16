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

        //public string GetAddress(int id)
        //{
        //    return _context.LibraryBranches
        //            .FirstOrDefault(a => a.Id == id).Address;
        //}

        //public string GetPhoneNumber(int id)
        //{
        //    return _context.LibraryBranches
        //             .FirstOrDefault(a => a.Id == id).Telephone;
        //}

        Branch IBranch.Get(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.Patrons)
                .Include(b => b.LibraryAssets).FirstOrDefault(b => b.Id == branchId);
        }

        //IEnumerable<Branch> IBranch.GetAddress(int id)
        //{
        //    return _context.LibraryBranches
        //        .Include(b => b.Address);
        //}

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

        //IEnumerable<Branch> IBranch.GetPhoneNumber(int id)
        //{
        //    return _context.LibraryBranches
        //        .Include(b => b.Telephone);
        //}
    }
}

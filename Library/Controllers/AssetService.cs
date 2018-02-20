using Library.Interfaces;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    public class AssetService : IAsset // implement IAsset interface
    {
        private LibraryContext _context; // private reference to DBContext in LibraryContext class
        public AssetService(LibraryContext context) // constructor that takes in LibraryContext aka DBContext - gives access to all the methods on DBContext. 
        {
            _context = context;
        }

        public IEnumerable<Asset> GetAll()
        {
            return _context.LibraryAssets // returns collection of all assets in database
                .Include(asset => asset.Location); // include entity - in query the location
        }

        public Asset GetById(int id)
        {
            return
                GetAll()
                .FirstOrDefault(asset => asset.Id == id);  // return null otherwise first instance of collection
        }

        public Branch GetCurrentLocation(int id)
        {
            return _context.LibraryAssets
                .FirstOrDefault(asset => asset.Id == id).Location;
        }

        public string GetDeweyIndex(int id) // return dewey index of asset type book
        {
            if (_context.LibraryAssets.Any(book => book.Id == id))
            {
                return _context.LibraryAssets
                    .FirstOrDefault(book => book.Id == id).DeweyIndex;
            }
            else return "";
        }

        public string GetIsbn(int id) // return isbn of asset type book
        {
            if (_context.LibraryAssets.Any(a => a.Id == id))
            {
                return _context.LibraryAssets
                    .FirstOrDefault(a => a.Id == id).ISBN;
            }
            else return "";
        }

        public string GetTitle(int id)
        {
            return _context.LibraryAssets
                .FirstOrDefault(a => a.Id == id).Title;
        }

        public string GetAuthorOrDirector(int id)
        {
            return _context.LibraryAssets
                .FirstOrDefault(a => a.Id == id).Author;
        }
    }
}

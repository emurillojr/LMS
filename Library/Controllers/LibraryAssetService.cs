using Library.Interfaces;
using Library.Models;
using Library.Models.Asset;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    public class LibraryAssetService : ILibraryAsset // implement ILibraryAsset interface
    {
        private LibraryContext _context; // private reference to DBContext
        public LibraryAssetService(LibraryContext context) // constructor that takes in context - gives access to all the methods on DBContext. 
        {
            _context = context;
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets // returns collection of all assets in database
                .Include(asset => asset.Location); // include entity - in query the location
        }

        public LibraryAsset GetById(int id)
        {
            return
                GetAll()
                .FirstOrDefault(asset => asset.Id == id);  // return null otherwise first instance of collection
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return _context.LibraryAssets.FirstOrDefault(asset => asset.Id == id).Location;
        }

        public string GetDeweyIndex(int id) // return dewey index of asset type book
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(book => book.Id == id).DeweyIndex;
            }
            else return "";
        }

        public string GetIsbn(int id) // return isbn of asset type book
        {
            if (_context.Books.Any(a => a.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(a => a.Id == id).ISBN;
            }
            else return "";
        }

        public string GetTitle(int id)
        {
            return _context.Books
                    .FirstOrDefault(a => a.Id == id).Title;
        }

        public string GetType(int id)
        {
            var book = _context.LibraryAssets.OfType<Book>()
                .Where(b => b.Id == id);
            return book.Any() ? "Book" : "Video";
        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets.OfType<Book>()
                .Where(asset => asset.Id == id).Any();

            var isVideo = _context.LibraryAssets.OfType<Video>()
                .Where(asset => asset.Id == id).Any();

            return isBook ?
                _context.Books.FirstOrDefault(book => book.Id == id).Author :
                _context.Videos.FirstOrDefault(video => video.Id == id).Director
                ?? "Unknown";
        }
    }
}

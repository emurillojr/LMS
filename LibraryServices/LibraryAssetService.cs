using LibraryData; // implement interface
using LibraryData.Models;  // implement interface
using Microsoft.EntityFrameworkCore; // .Include
using System.Collections.Generic;
using System.Linq; // .Any . FirstOrDefault

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset // implement ILibraryAsset interface
    {

        private LibraryContext _context; // private reference to DBContext
        public LibraryAssetService(LibraryContext context) // constructor that takes in context - gives access to all the methods on DBContext. 
        {
            _context = context;
        }
        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset); // add an instance of a new asset
            _context.SaveChanges(); // commit changes to the database
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets // returns collection of all assets in database
                .Include(asset => asset.Status) // include entity - in query the status
                .Include(asset => asset.Location); // include entity - in query the location
        }

        public LibraryAsset GetById(int id)
        {
            return
                //_context.LibraryAssets
                //.Include(asset => asset.Status)
                //.Include(asset => asset.Location)
                GetAll()
                .FirstOrDefault(asset => asset.Id == id);  // return null otherwise first instance of collection
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return GetById(id).Location;
            //return _context.LibraryAssets.FirstOrDefault(asset => asset.Id == id).Location;
        }

        public string GetDeweyIndex(int id) // return dewey index of asset type book
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(book => book.Id == id).DeweyIndex;
            }
            //var isBook = _context.LibraryAssets.OfType<Book>().Where(a => a.Id = id).Any();
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

            //return book.Any() ? "Book" : "Video" : "Magazine" : "Newspaper";
            return book.Any() ? "Book" : "Video";
        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets.OfType<Book>()
                .Where(asset => asset.Id == id).Any();

            var isVideo = _context.LibraryAssets.OfType<Video>()
                .Where(asset => asset.Id == id).Any();

            //var isMag = _context.LibraryAssets.OfType<Magazine>()
            //    .Where(asset => asset.Id = id).Any();

            //var isNewsPaper = _context.LibraryAssets.OfType<Newspaper>()
            //    .Where(asset => asset.Id = id).Any();

            return isBook ?
                _context.Books.FirstOrDefault(book => book.Id == id).Author :
                _context.Videos.FirstOrDefault(video => video.Id == id).Director
                ?? "Unknown";

            // null coalescing operator:
            // a ?? b   (return a if its not bull, ortherwise return b)
        }
    }
}

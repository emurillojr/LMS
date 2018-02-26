using Library.Interfaces;
using Library.ViewModels.Asset;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Library.Controllers
{
    public class AssetController : Controller // inherit from Controller base class
    {
        private IAsset _assets;
        public AssetController(IAsset assets) // contructor  
        {
            _assets = assets;
        }

        public IActionResult Index(string sortOrder, string searchString)
        {
            //var assetModels = _assets.GetAll();  // list of entire catalog of library assets
            var assetModels = from c in _assets.GetAll().ToList() select c;
            ViewData["CurrentFilter"] = searchString;
            ViewData["TitleSortParm"] = sortOrder == "title" ? "title_desc" : "title";
            ViewData["AuthorSortParm"] = sortOrder == "author" ? "author_desc" : "author";
            ViewData["ISBNSortParm"] = sortOrder == "isbn" ? "isbn_desc" : "isbn"; ;

            if (!String.IsNullOrEmpty(searchString))
            {
                assetModels = assetModels.Where(c => c.Title.ToUpper().Contains(searchString.ToUpper())
                                            || c.Author.ToUpper().Contains(searchString.ToUpper())
                                            || c.ISBN.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "title":
                    assetModels = assetModels.OrderBy(s => s.Title.ToUpper());
                    break;
                case "title_desc":
                    assetModels = assetModels.OrderByDescending(s => s.Title.ToUpper());
                    break;
                case "author":
                    assetModels = assetModels.OrderBy(s => s.Author.ToUpper());
                    break;
                case "author_desc":
                    assetModels = assetModels.OrderByDescending(s => s.Author.ToUpper());
                    break;
                case "isbn":
                    assetModels = assetModels.OrderBy(s => s.ISBN);
                    break;
                case "isbn_desc":
                    assetModels = assetModels.OrderByDescending(s => s.ISBN);
                    break;
                default:
                    assetModels = assetModels.OrderBy(s => s.Id);
                    break;
            }
           

            var listingResult = assetModels
                .Select(a => new AssetIndexListingModel
                {
                    Id = a.Id,
                    ImageUrl = "/images/" + a.ImageUrl,
                    AuthorOrDirector = _assets.GetAuthorOrDirector(a.Id),
                    Title = a.Title,
                    ISBN = _assets.GetIsbn(a.Id)
                });

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };

            return View(model);
        }

        public IActionResult Detail(int id)  // localhost:#####/Asset/Detail/123    controller/Action/Id#
        {
            var asset = _assets.GetById(id);  // returns asset from database by id

            var model = new AssetDetailModel
            {
                AssetId = id,
                Title = asset.Title,
                Year = asset.Year,
                Cost = asset.Cost,
                ImageUrl = "/images/"+ asset.ImageUrl,
                AuthorOrDirector = _assets.GetAuthorOrDirector(id), // use Asset Service to get AuthorOrDirector
                DeweyCallNumber = _assets.GetDeweyIndex(id),  // use Asset Service to get GetDeweyIndex
                ISBN = _assets.GetIsbn(id), // use Asset Service to get ISBN
                CurrentLocation = _assets.GetCurrentLocation(id).Name
            };

            return View(model);
        }
    }
}

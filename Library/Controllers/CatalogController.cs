using Library.Interfaces;
using Library.ViewModels.Catalog;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Controllers
{
    public class CatalogController : Controller // inherit from Controller base class
    {
        private ILibraryAsset _assets;
        public CatalogController(ILibraryAsset assets) // contructor  
        {
            _assets = assets;
        }

        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();  // list of entire catalog of library assets

            var listingResult = assetModels
                .Select(a => new AssetIndexListingModel
                {
                    Id = a.Id,
                    ImageUrl = a.ImageUrl,
                    AuthorOrDirector = _assets.GetAuthorOrDirector(a.Id),
                    DeweyCallNumber = _assets.GetDeweyIndex(a.Id),
                    Title = a.Title,
                    Type = _assets.GetType(a.Id)
                });

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };

            return View(model);
        }

        public IActionResult Detail(int id)  // localhost:#####/Catalog/Detail/123    controller / Action / Id
        {
            var asset = _assets.GetById(id);  // returns asset from database

            var model = new AssetDetailModel
            {
                AssetId = id,
                Title = asset.Title,
                Type = _assets.GetType(id),
                Year = asset.Year,
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _assets.GetAuthorOrDirector(id), // use Library Asset Service to get AuthorOrDirector
                DeweyCallNumber = _assets.GetDeweyIndex(id),  // use Library Asset Service to get GetDeweyIndex
                ISBN = _assets.GetIsbn(id), // use Library Asset Service to get ISBN
            };

            return View(model);
        }
    }
}

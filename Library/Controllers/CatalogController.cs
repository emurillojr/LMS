using Library.Models.Catalog; // AssetDetailModel
using LibraryData;  // ILibraryAsset
using Microsoft.AspNetCore.Mvc; // Controller
using System.Linq;  // .Select

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
                .Select(result => new AssetIndexListingModel  
                {
                    Id = result.Id,
                    ImageUrl = result.ImageUrl,
                    AuthorOrDirector = _assets.GetAuthorOrDirector(result.Id),
                    DeweyCallNumber = _assets.GetDeweyIndex(result.Id),
                    Title = result.Title,
                    Type = _assets.GetType(result.Id)
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
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _assets.GetAuthorOrDirector(id), // use Library Asset Service to get AuthorOrDirector
                CurrentLocation = _assets.GetCurrentLocation(id).Name, // use Library Asset Service to get CurrentLocation name
                DeweyCallNumber = _assets.GetDeweyIndex(id),  // use Library Asset Service to get GetDeweyIndex
                ISBN = _assets.GetIsbn(id) // use Library Asset Service to get ISBN
            };

            return View(model);
        }
    }
}

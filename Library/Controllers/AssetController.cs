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

        public IActionResult Index(string searchString)
        {
            //var assetModels = _assets.GetAll();  // list of entire catalog of library assets
            var assetModels = from c in _assets.GetAll().ToList() select c;
            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                assetModels = assetModels.Where(c => c.Title.ToUpper().Contains(searchString.ToUpper()));
            }

            var listingResult = assetModels
                .Select(a => new AssetIndexListingModel
                {
                    Id = a.Id,
                    ImageUrl = a.ImageUrl,
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
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _assets.GetAuthorOrDirector(id), // use Asset Service to get AuthorOrDirector
                DeweyCallNumber = _assets.GetDeweyIndex(id),  // use Asset Service to get GetDeweyIndex
                ISBN = _assets.GetIsbn(id), // use Asset Service to get ISBN
                CurrentLocation = _assets.GetCurrentLocation(id).Name
            };

            return View(model);
        }
    }
}

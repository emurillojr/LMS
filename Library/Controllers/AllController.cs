using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.All;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
    public class AllController : Controller
    {

        private IAll _all;

        // create a constructor takes AllService
        public AllController(IAll all)
        {
            // save AllService param off into a private field  to have access in the rest of the controller
            _all = all;
        }


        public IActionResult Index()
        {

            ViewBag.Message = "All testing Index";

            var patrons = _all.GetAllPatrons().Select(all => new AllDetailModel // stores all patrons
            {
                PatronFirstName = all.FirstName,
                PatronLastName = all.LastName,
            });

            var branchs = _all.GetAllLibraryBranches().Select(all => new AllDetailModel
            {
                BranchName = all.Name,
                //AssetType = all.GetType().ToString()
            });

            var assets = _all.GetAllLibraryAssets().Select(all => new AllDetailModel
            {
                AssetTitle = all.Title,
                AssetType = all.GetType().ToString(),
            });

            var assetsList = new List<SelectListItem>();
            assetsList.Add(new SelectListItem { Text = "Book", Value = "Book" });
            assetsList.Add(new SelectListItem { Text = "Video", Value = "Video" });
            assetsList.Add(new SelectListItem { Text = "Magazine", Value = "Magazine" });
            assetsList.Add(new SelectListItem { Text = "Newspaper", Value = "Newspaper" });

            var model = new AllIndexModel()
            {
                Alls = patrons,
                Alls1 = branchs,
                Alls2 = assets


            };

            model.AssetsList = assetsList;


            return View(model);
        }
    }
}


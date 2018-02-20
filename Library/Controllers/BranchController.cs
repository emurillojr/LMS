using Library.Interfaces;
using Library.ViewModels.Branch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Library.Controllers
{
    public class BranchController : Controller // inherit from Controller base class
    {
        private IBranch _branch;

        // create a constructor takes branchservice
        public BranchController(IBranch branch)
        {
            // save branchService param off into a private field  to have access in the rest of the controller
            _branch = branch;
        }

        public IActionResult Index(string sortOrder, string searchString)
        {
            var branchModels = from c in _branch.GetAll().ToList() select c;
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["AddressSortParm"] = sortOrder == "address" ? "address_desc" : "address";
            ViewData["TelephoneSortParm"] = sortOrder == "telephone" ? "telephone_desc" : "telephone"; ;

            if (!String.IsNullOrEmpty(searchString))
            {
                branchModels = branchModels.Where(c => c.Name.ToUpper().Contains(searchString.ToUpper())
                                                || c.Address.ToUpper().Contains(searchString.ToUpper())
                                                || c.Telephone.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name":
                    branchModels = branchModels.OrderBy(s => s.Name.ToUpper());
                    break;
                case "name_desc":
                    branchModels = branchModels.OrderByDescending(s => s.Name.ToUpper());
                    break;
                case "address":
                    branchModels = branchModels.OrderBy(s => s.Address.ToUpper());
                    break;
                case "address_desc":
                    branchModels = branchModels.OrderByDescending(s => s.Address.ToUpper());
                    break;
                case "telephone":
                    branchModels = branchModels.OrderBy(s => s.Telephone);
                    break;
                case "telephone_desc":
                    branchModels = branchModels.OrderByDescending(s => s.Telephone);
                    break;
                default:
                    branchModels = branchModels.OrderBy(s => s.Id);
                    break;
            }

            var branches = branchModels
                .Select(branch => new BranchDetailModel

                {
                    Id = branch.Id,
                    Name = branch.Name,
                    Address = branch.Address,
                    Telephone = branch.Telephone
                });

            var model = new BranchIndexModel()
            {
                Branches = branches
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var branch = _branch.Get(id);
            var model = new BranchDetailModel
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
                Telephone = branch.Telephone,
                Description = branch.Description,
                OpenedDate = branch.OpenDate.ToString("yyyy-MM-dd"),
                NumberOfAssets = _branch.GetAssets(id).Count(),
                NumberOfPatrons = _branch.GetPatrons(id).Count(),
                TotalAssetValue = _branch.GetAssets(id).Sum(a => a.Cost),
                ImageUrl = "/images/"+branch.ImageUrl,
            };

            return View(model);
        }
    }
}

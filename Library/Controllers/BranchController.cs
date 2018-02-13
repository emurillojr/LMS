﻿using Library.Interfaces;
using Library.ViewModels.Branch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Library.Controllers
{
    public class BranchController : Controller // inherit from Controller base class
    {
        private ILibraryBranch _branch;

        // create a constructor takes branchservice
        public BranchController(ILibraryBranch branch)
        {
            // save branchService param off into a private field  to have access in the rest of the controller
            _branch = branch;
        }

        public IActionResult Index()
        {
            var branches = _branch.GetAll().Select(branch => new BranchDetailModel
            {
                Id = branch.Id,
                Name = branch.Name,
                //IsOpen = _branch.IsBranchOpen(branch.Id),
                NumberOfAssets = _branch.GetAssets(branch.Id).Count(),
                NumberOfPatrons = _branch.GetPatrons(branch.Id).Count()
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
                ImageUrl = branch.ImageUrl,
                //HoursOpen = _branch.GetBranchHours(id)
            };

            return View(model);
        }

        public ActionResult ListofBranches(string searchString)
        {
            // https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page

            //var branch = _branch.GetAll().ToList();  // list of entire catalog of library assets

            var branch = from b in _branch.GetAll().ToList() select b;

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                branch = branch.Where(b => b.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(branch);
        }
    }
}

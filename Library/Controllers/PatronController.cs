using Library.Interfaces;
using Library.ViewModels.Patron;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Library.Controllers
{
    public class PatronController : Controller // inherit from Controller base class
    {
        private IPatron _patron;

        public PatronController(IPatron patron)  // constructor
        {
            _patron = patron;
        }

        public IActionResult Index(string sortOrder, string searchString)
        {
            //var allPatrons = _patron.GetAll(); // stores all patrons
            var allPatrons = from c in _patron.GetAll().ToList() select c;
            ViewData["CurrentFilter"] = searchString;
            ViewData["LastNameSortParm"] = sortOrder == "lastname" ? "lastname_desc" : "lastname";
            ViewData["FirstNameSortParm"] = sortOrder == "firstname" ? "firstname_desc" : "firstname";
            ViewData["HomeLibraryBranchSortParm"] = sortOrder == "homelibbranch" ? "homelibbranch_desc" : "homelibbranch";

            if (!String.IsNullOrEmpty(searchString))
            {
                allPatrons = allPatrons.Where(c => c.LastName.ToUpper().Contains(searchString.ToUpper())
                                            || c.FirstName.ToUpper().Contains(searchString.ToUpper())
                                            || c.FullName.ToUpper().Contains(searchString.ToUpper())
                                            || c.HomeLibraryBranch.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "lastname":
                    allPatrons = allPatrons.OrderBy(s => s.LastName.ToUpper());
                    break;
                case "lastname_desc":
                    allPatrons = allPatrons.OrderByDescending(s => s.LastName.ToUpper());
                    break;
                case "firstname":
                    allPatrons = allPatrons.OrderBy(s => s.FirstName.ToUpper());
                    break;
                case "firstname_desc":
                    allPatrons = allPatrons.OrderByDescending(s => s.FirstName.ToUpper());
                    break;
                case "homelibbranch":
                    allPatrons = allPatrons.OrderBy(s => s.HomeLibraryBranch.Name.ToUpper());
                    break;
                case "homelibbranch_desc":
                    allPatrons = allPatrons.OrderByDescending(s => s.HomeLibraryBranch.Name.ToUpper());
                    break;
                default:
                    allPatrons = allPatrons.OrderBy(s => s.Id);
                    break;
            }

            var patronModels = allPatrons
                .Select(p => new PatronDetailModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Address = p.Address,
                    Telephone = p.TelephoneNumber,
                    HomeLibraryBranch = p.HomeLibraryBranch.Name
                }).ToList();

            var model = new PatronIndexModel()
            {
                Patrons = patronModels
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var patron = _patron.Get(id);

            var model = new PatronDetailModel
            {
                Id = id,
                LastName = patron.LastName,
                FirstName = patron.FirstName,
                Address = patron.Address,
                HomeLibraryBranch = patron.HomeLibraryBranch.Name,
                Telephone = patron.TelephoneNumber,
                DateOfBirth = patron.DateOfBirth
            };

            return View(model);
        }
    }
}


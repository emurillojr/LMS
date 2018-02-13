using Library.Interfaces;
using Library.ViewModels.Patron;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var allPatrons = _patron.GetAll(); // stores all patrons

            var patronModels = allPatrons
                .Select(p => new PatronDetailModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
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
                LastName = patron.LastName,
                FirstName = patron.FirstName,
                Address = patron.Address,
                HomeLibraryBranch = patron.HomeLibraryBranch.Name,
                Telephone = patron.TelephoneNumber,
            };

            return View(model);
        }
    }
}


using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var allPatrons = _patron.GetAll();

            var patronModels = allPatrons
                .Select(p => new PatronDetailModel
                {
                    Id = p.Id,
                    LastName = p.LastName,
                    FirstName = p.FirstName,
                    LibraryCardId = p.LibraryCard.Id,
                    OverdueFees = p.LibraryCard.Fees,
                    HomeLibrary = p.HomeLibraryBranch.Name
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
                Gender = patron.Gender,
                HomeLibrary = patron.HomeLibraryBranch.Name,
                MemberSince = patron.LibraryCard.Created,
                OverdueFees = patron.LibraryCard.Fees,
                LibraryCardId = patron.LibraryCard.Id,
                Telephone = patron.Telephone,
                AssetsCheckedOut = _patron.GetCheckouts(id).ToList() ?? new List<Checkout>(),
                CheckoutHistory = _patron.GetCheckoutHistory(id),
                Holds = _patron.GetHolds(id)
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}

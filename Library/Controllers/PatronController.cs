﻿using Library.Interfaces;
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

        public IActionResult Index(string searchString)
        {
            //var allPatrons = _patron.GetAll(); // stores all patrons
            var allPatrons = from c in _patron.GetAll().ToList() select c;
            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                allPatrons = allPatrons.Where(c => c.LastName.ToUpper().Contains(searchString.ToUpper()));
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


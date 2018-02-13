using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Controllers
{
    public class PatronsCRUDController : Controller
    {
        private readonly LibraryContext _context;

        public PatronsCRUDController(LibraryContext context)
        {
            _context = context;
        }

        // GET: PatronsCRUD
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patrons.ToListAsync());
        }

        // GET: PatronsCRUD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron = await _context.Patrons
                .SingleOrDefaultAsync(m => m.Id == id);
            if (patron == null)
            {
                return NotFound();
            }

            return View(patron);
        }

        // GET: PatronsCRUD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatronsCRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,DateOfBirth,TelephoneNumber")] Patron patron)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patron);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patron);
        }

        // GET: PatronsCRUD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron = await _context.Patrons.SingleOrDefaultAsync(m => m.Id == id);
            if (patron == null)
            {
                return NotFound();
            }
            return View(patron);
        }

        // POST: PatronsCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,DateOfBirth,TelephoneNumber")] Patron patron)
        {
            if (id != patron.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patron);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatronExists(patron.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patron);
        }

        // GET: PatronsCRUD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron = await _context.Patrons
                .SingleOrDefaultAsync(m => m.Id == id);
            if (patron == null)
            {
                return NotFound();
            }

            return View(patron);
        }

        // POST: PatronsCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patron = await _context.Patrons.SingleOrDefaultAsync(m => m.Id == id);
            _context.Patrons.Remove(patron);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatronExists(int id)
        {
            return _context.Patrons.Any(e => e.Id == id);
        }
    }
}

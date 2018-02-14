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
    public class LibraryBranchesCRUDController : Controller
    {
        private readonly LibraryContext _context;

        public LibraryBranchesCRUDController(LibraryContext context)
        {
            _context = context;
        }

        // GET: LibraryBranchesCRUD
        public async Task<IActionResult> Index()
        {
            return View(await _context.LibraryBranches.ToListAsync());
        }

        // GET: LibraryBranchesCRUD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryBranch = await _context.LibraryBranches
                .SingleOrDefaultAsync(m => m.Id == id);
            if (libraryBranch == null)
            {
                return NotFound();
            }

            return View(libraryBranch);
        }

        // GET: LibraryBranchesCRUD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LibraryBranchesCRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Telephone,Description,OpenDate,ImageUrl")] Branch libraryBranch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libraryBranch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libraryBranch);
        }

        // GET: LibraryBranchesCRUD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryBranch = await _context.LibraryBranches.SingleOrDefaultAsync(m => m.Id == id);
            if (libraryBranch == null)
            {
                return NotFound();
            }
            return View(libraryBranch);
        }

        // POST: LibraryBranchesCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Telephone,Description,OpenDate,ImageUrl")] Branch libraryBranch)
        {
            if (id != libraryBranch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libraryBranch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryBranchExists(libraryBranch.Id))
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
            return View(libraryBranch);
        }

        // GET: LibraryBranchesCRUD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryBranch = await _context.LibraryBranches
                .SingleOrDefaultAsync(m => m.Id == id);
            if (libraryBranch == null)
            {
                return NotFound();
            }

            return View(libraryBranch);
        }

        // POST: LibraryBranchesCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libraryBranch = await _context.LibraryBranches.SingleOrDefaultAsync(m => m.Id == id);
            _context.LibraryBranches.Remove(libraryBranch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryBranchExists(int id)
        {
            return _context.LibraryBranches.Any(e => e.Id == id);
        }
    }
}

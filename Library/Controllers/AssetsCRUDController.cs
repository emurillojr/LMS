using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class AssetsCRUDController : Controller
    {
        private readonly LibraryContext _context;

        public AssetsCRUDController(LibraryContext context)
        {
            _context = context;
        }

        // GET: AssetsCRUD
        public async Task<IActionResult> Index()
        {
            return View(await _context.LibraryAssets.ToListAsync());
        }

        // GET: AssetsCRUD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryAsset = await _context.LibraryAssets
            .SingleOrDefaultAsync(m => m.Id == id);
            if (libraryAsset == null)
            {
                return NotFound();
            }

            return View(libraryAsset);
        }

        // GET: AssetsCRUD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetsCRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Title, Year, Cost, ImageUrl, NumberOfCopies, ISBN, Author, DeweyIndex, LocationId")] Asset libraryAsset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libraryAsset);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Asset");
            }
            return View(libraryAsset);
        }

        // GET: AssetsCRUD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryAsset = await _context.LibraryAssets.SingleOrDefaultAsync(m => m.Id == id);
            if (libraryAsset == null)
            {
                return NotFound();
            }
            return View(libraryAsset);
        }

        // POST: AssetsCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Title, Year, Cost, ImageUrl, NumberOfCopies, ISBN, Author, DeweyIndex, LocationId")] Asset libraryAsset)
        {
            if (id != libraryAsset.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libraryAsset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryAssetExists(libraryAsset.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Asset");
            }
            return View(libraryAsset);
        }

        // GET: AssetsCRUD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryAsset = await _context.LibraryAssets
                .SingleOrDefaultAsync(m => m.Id == id);
            if (libraryAsset == null)
            {
                return NotFound();
            }

            return View(libraryAsset);
        }

        // POST: AssetsCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libraryAsset = await _context.LibraryAssets.SingleOrDefaultAsync(m => m.Id == id);
            _context.LibraryAssets.Remove(libraryAsset);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "Asset");
        }

        private bool LibraryAssetExists(int id)
        {
            return _context.LibraryAssets.Any(e => e.Id == id);
        }
    }
}

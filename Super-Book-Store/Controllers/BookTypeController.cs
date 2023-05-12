using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Super_Book_Store.Models;

namespace Super_Book_Store.Controllers
{
    public class BookTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookType
        public async Task<IActionResult> Index()
        {
              return _context.BookType != null ? 
                          View(await _context.BookType.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BookType'  is null.");
        }

        // GET: BookType/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BookType == null)
            {
                return NotFound();
            }

            var bookType = await _context.BookType
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (bookType == null)
            {
                return NotFound();
            }

            return View(bookType);
        }

        // GET: BookType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,BookName,BookTypeName")] BookType bookType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookType);
        }

        // GET: BookType/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BookType == null)
            {
                return NotFound();
            }

            var bookType = await _context.BookType.FindAsync(id);
            if (bookType == null)
            {
                return NotFound();
            }
            return View(bookType);
        }

        // POST: BookType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BookID,BookName,BookTypeName")] BookType bookType)
        {
            if (id != bookType.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookTypeExists(bookType.BookID))
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
            return View(bookType);
        }

        // GET: BookType/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BookType == null)
            {
                return NotFound();
            }

            var bookType = await _context.BookType
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (bookType == null)
            {
                return NotFound();
            }

            return View(bookType);
        }

        // POST: BookType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BookType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BookType'  is null.");
            }
            var bookType = await _context.BookType.FindAsync(id);
            if (bookType != null)
            {
                _context.BookType.Remove(bookType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookTypeExists(string id)
        {
          return (_context.BookType?.Any(e => e.BookID == id)).GetValueOrDefault();
        }
    }
}

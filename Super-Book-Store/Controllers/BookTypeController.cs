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
            var applicationDbContext = _context.BookType.Include(b => b.Kho).Include(b => b.Language);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookType == null)
            {
                return NotFound();
            }

            var bookType = await _context.BookType
                .Include(b => b.Kho)
                .Include(b => b.Language)
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
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookName");
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageName");
            return View();
        }

        // POST: BookType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,BookNameID,BookTypeNew,AuthorName,LanguageID")] BookType bookType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookName", bookType.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageName", bookType.LanguageID);
            return View(bookType);
        }

        // GET: BookType/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookName", bookType.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageName", bookType.LanguageID);
            return View(bookType);
        }

        // POST: BookType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,BookNameID,BookTypeNew,AuthorName,LanguageID")] BookType bookType)
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
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookName", bookType.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageName", bookType.LanguageID);
            return View(bookType);
        }

        // GET: BookType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookType == null)
            {
                return NotFound();
            }

            var bookType = await _context.BookType
                .Include(b => b.Kho)
                .Include(b => b.Language)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        private bool BookTypeExists(int id)
        {
          return (_context.BookType?.Any(e => e.BookID == id)).GetValueOrDefault();
        }
    }
}

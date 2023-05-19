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
    public class LanguageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Language
        public async Task<IActionResult> Index()
        {
              return _context.Language != null ? 
                          View(await _context.Language.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Language'  is null.");
        }

        // GET: Language/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Language == null)
            {
                return NotFound();
            }

            var language = await _context.Language
                .FirstOrDefaultAsync(m => m.LanguageID == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // GET: Language/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Language/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LanguageID,LanguageName")] Language language)
        {
            if (ModelState.IsValid)
            {
                _context.Add(language);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        // GET: Language/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Language == null)
            {
                return NotFound();
            }

            var language = await _context.Language.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }

        // POST: Language/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LanguageID,LanguageName")] Language language)
        {
            if (id != language.LanguageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(language);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageExists(language.LanguageID))
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
            return View(language);
        }

        // GET: Language/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Language == null)
            {
                return NotFound();
            }

            var language = await _context.Language
                .FirstOrDefaultAsync(m => m.LanguageID == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // POST: Language/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Language == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Language'  is null.");
            }
            var language = await _context.Language.FindAsync(id);
            if (language != null)
            {
                _context.Language.Remove(language);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageExists(string id)
        {
          return (_context.Language?.Any(e => e.LanguageID == id)).GetValueOrDefault();
        }
    }
}

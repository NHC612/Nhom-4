using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Super_Book_Store.Data;
using Super_Book_Store.Models;

namespace Super_Book_Store.Controllers
{
    public class NhaXuatBanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhaXuatBanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NhaXuatBan
        public async Task<IActionResult> Index()
        {
              return _context.NhaXuatBan != null ? 
                          View(await _context.NhaXuatBan.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NhaXuatBan'  is null.");
        }

        // GET: NhaXuatBan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NhaXuatBan == null)
            {
                return NotFound();
            }

            var nhaXuatBan = await _context.NhaXuatBan
                .FirstOrDefaultAsync(m => m.NXBName == id);
            if (nhaXuatBan == null)
            {
                return NotFound();
            }

            return View(nhaXuatBan);
        }

        // GET: NhaXuatBan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaXuatBan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NXBName,Address")] NhaXuatBan nhaXuatBan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaXuatBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaXuatBan);
        }

        // GET: NhaXuatBan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NhaXuatBan == null)
            {
                return NotFound();
            }

            var nhaXuatBan = await _context.NhaXuatBan.FindAsync(id);
            if (nhaXuatBan == null)
            {
                return NotFound();
            }
            return View(nhaXuatBan);
        }

        // POST: NhaXuatBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NXBName,Address")] NhaXuatBan nhaXuatBan)
        {
            if (id != nhaXuatBan.NXBName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaXuatBan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaXuatBanExists(nhaXuatBan.NXBName))
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
            return View(nhaXuatBan);
        }

        // GET: NhaXuatBan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NhaXuatBan == null)
            {
                return NotFound();
            }

            var nhaXuatBan = await _context.NhaXuatBan
                .FirstOrDefaultAsync(m => m.NXBName == id);
            if (nhaXuatBan == null)
            {
                return NotFound();
            }

            return View(nhaXuatBan);
        }

        // POST: NhaXuatBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NhaXuatBan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NhaXuatBan'  is null.");
            }
            var nhaXuatBan = await _context.NhaXuatBan.FindAsync(id);
            if (nhaXuatBan != null)
            {
                _context.NhaXuatBan.Remove(nhaXuatBan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaXuatBanExists(string id)
        {
          return (_context.NhaXuatBan?.Any(e => e.NXBName == id)).GetValueOrDefault();
        }
    }
}

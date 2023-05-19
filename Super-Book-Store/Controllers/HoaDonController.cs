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
    public class HoaDonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoaDonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoaDon
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HoaDon.Include(h => h.KhachHang).Include(h => h.Kho).Include(h => h.Language);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HoaDon/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HoaDon == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDon
                .Include(h => h.KhachHang)
                .Include(h => h.Kho)
                .Include(h => h.Language)
                .FirstOrDefaultAsync(m => m.HoaDonID == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // GET: HoaDon/Create
        public IActionResult Create()
        {
            ViewData["KhachHangName"] = new SelectList(_context.Set<KhachHang>(), "KhachHangID", "KhachHangID");
            ViewData["BookNameID"] = new SelectList(_context.Set<Kho>(), "BookID", "BookID");
            ViewData["LanguageID"] = new SelectList(_context.Set<Language>(), "LanguageID", "LanguageID");
            return View();
        }

        // POST: HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoaDonID,KhachHangName,BookNameID,LanguageID,Address")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhachHangName"] = new SelectList(_context.Set<KhachHang>(), "KhachHangID", "KhachHangID", hoaDon.KhachHangName);
            ViewData["BookNameID"] = new SelectList(_context.Set<Kho>(), "BookID", "BookID", hoaDon.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Set<Language>(), "LanguageID", "LanguageID", hoaDon.LanguageID);
            return View(hoaDon);
        }

        // GET: HoaDon/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HoaDon == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDon.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            ViewData["KhachHangName"] = new SelectList(_context.Set<KhachHang>(), "KhachHangID", "KhachHangID", hoaDon.KhachHangName);
            ViewData["BookNameID"] = new SelectList(_context.Set<Kho>(), "BookID", "BookID", hoaDon.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Set<Language>(), "LanguageID", "LanguageID", hoaDon.LanguageID);
            return View(hoaDon);
        }

        // POST: HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HoaDonID,KhachHangName,BookNameID,LanguageID,Address")] HoaDon hoaDon)
        {
            if (id != hoaDon.HoaDonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.HoaDonID))
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
            ViewData["KhachHangName"] = new SelectList(_context.Set<KhachHang>(), "KhachHangID", "KhachHangID", hoaDon.KhachHangName);
            ViewData["BookNameID"] = new SelectList(_context.Set<Kho>(), "BookID", "BookID", hoaDon.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Set<Language>(), "LanguageID", "LanguageID", hoaDon.LanguageID);
            return View(hoaDon);
        }

        // GET: HoaDon/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HoaDon == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDon
                .Include(h => h.KhachHang)
                .Include(h => h.Kho)
                .Include(h => h.Language)
                .FirstOrDefaultAsync(m => m.HoaDonID == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // POST: HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HoaDon == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HoaDon'  is null.");
            }
            var hoaDon = await _context.HoaDon.FindAsync(id);
            if (hoaDon != null)
            {
                _context.HoaDon.Remove(hoaDon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonExists(string id)
        {
          return (_context.HoaDon?.Any(e => e.HoaDonID == id)).GetValueOrDefault();
        }
    }
}

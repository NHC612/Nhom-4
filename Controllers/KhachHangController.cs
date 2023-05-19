using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Super_Book_Store.Data;
using Super_Book_Store.Models;
using Super_Book_Store.Models.Process;

namespace Super_Book_Store.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess strPro = new StringProcess();

        public KhachHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KhachHang
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KhachHang.Include(k => k.Kho).Include(k => k.Language);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KhachHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang
                .Include(k => k.Kho)
                .Include(k => k.Language)
                .FirstOrDefaultAsync(m => m.KhachHangID == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // GET: KhachHang/Create
        public IActionResult Create()
        {
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookID");
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageID");

        }

        // POST: KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KhachHangID,KhachHangName,Sex,BookNameID,LanguageID,PhoneNumber,Address")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookID", khachHang.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageID", khachHang.LanguageID);
            return View(khachHang);
        }

        // GET: KhachHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookID", khachHang.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageID", khachHang.LanguageID);
            return View(khachHang);
        }

        // POST: KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("KhachHangID,KhachHangName,Sex,BookNameID,LanguageID,PhoneNumber,Address")] KhachHang khachHang)
        {
            if (id != khachHang.KhachHangID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(khachHang.KhachHangID))
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
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookID", khachHang.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageID", khachHang.LanguageID);
            return View(khachHang);
        }

        // GET: KhachHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang
                .Include(k => k.Kho)
                .Include(k => k.Language)
                .FirstOrDefaultAsync(m => m.KhachHangID == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // POST: KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KhachHang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.KhachHang'  is null.");
            }
            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang != null)
            {
                _context.KhachHang.Remove(khachHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachHangExists(string id)
        {
          return (_context.KhachHang?.Any(e => e.KhachHangID == id)).GetValueOrDefault();
        }
    }
}

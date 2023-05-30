using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Super_Book_Store.Models;
using Super_Book_Store.Models.Process;

namespace Super_Book_Store.Controllers
{
    public class DonHangController : Controller
    {
        private readonly ApplicationDbContext _context;
        StringProcess DH = new StringProcess();


        public DonHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DonHang
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DonHang.Include(d => d.KhachHang).Include(d => d.Kho).Include(d => d.Language).Include(d => d.NhanVien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DonHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.KhachHang)
                .Include(d => d.Kho)
                .Include(d => d.Language)
                .Include(d => d.NhanVien)
                .FirstOrDefaultAsync(m => m.DonHangID == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHang/Create
        public IActionResult Create()
        {
             // Sinh ma tu dong
            var newID = "";
            if(_context.DonHang.Count() == 0){
                newID = "DH01";
            }
            else{
                var DHH = _context.DonHang.OrderByDescending(x=>x.DonHangID).First().DonHangID;
                newID = DH.AutoGenerateKey(DHH);
            }
            ViewBag.DonHangID = newID;
            // end
            ViewData["KhachHangName"] = new SelectList(_context.KhachHang, "KhachHangID", "KhachHangID");
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookID");
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageID");
            ViewData["NhanVienName"] = new SelectList(_context.NhanVien, "NhanVienID", "NhanVienID");
            return View();
        }

        // POST: DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonHangID,KhachHangName,BookNameID,LanguageID,NhanVienName,Address")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhachHangName"] = new SelectList(_context.KhachHang, "KhachHangID", "KhachHangID", donHang.KhachHangName);
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookID", donHang.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageID", donHang.LanguageID);
            ViewData["NhanVienName"] = new SelectList(_context.NhanVien, "NhanVienID", "NhanVienID", donHang.NhanVienName);
            return View(donHang);
        }

        // GET: DonHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["KhachHangName"] = new SelectList(_context.KhachHang, "KhachHangID", "KhachHangID", donHang.KhachHangName);
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookID", donHang.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageID", donHang.LanguageID);
            ViewData["NhanVienName"] = new SelectList(_context.NhanVien, "NhanVienID", "NhanVienID", donHang.NhanVienName);
            return View(donHang);
        }

        // POST: DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DonHangID,KhachHangName,BookNameID,LanguageID,NhanVienName,Address")] DonHang donHang)
        {
            if (id != donHang.DonHangID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.DonHangID))
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
            ViewData["KhachHangName"] = new SelectList(_context.KhachHang, "KhachHangID", "KhachHangID", donHang.KhachHangName);
            ViewData["BookNameID"] = new SelectList(_context.Kho, "BookID", "BookID", donHang.BookNameID);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageID", donHang.LanguageID);
            ViewData["NhanVienName"] = new SelectList(_context.NhanVien, "NhanVienID", "NhanVienID", donHang.NhanVienName);
            return View(donHang);
        }

        // GET: DonHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.KhachHang)
                .Include(d => d.Kho)
                .Include(d => d.Language)
                .Include(d => d.NhanVien)
                .FirstOrDefaultAsync(m => m.DonHangID == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DonHang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DonHang'  is null.");
            }
            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang != null)
            {
                _context.DonHang.Remove(donHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(string id)
        {
          return (_context.DonHang?.Any(e => e.DonHangID == id)).GetValueOrDefault();
        }
    }
}

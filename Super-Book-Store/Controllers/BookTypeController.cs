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
    public class BookTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        StringProcess mdt = new StringProcess();

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
        public async Task<IActionResult> Details(string id)
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
            // Sinh ma tu dong
            var newID = "";
            if(_context.BookType.Count() == 0){
                // khởi tạo 1 mã mới
                newID = "Number01";
            }
            else{
                // lấy ra được ID mới nhất 
                // OrderByDescending :  lấy giá trị giảm dần trong chuỗi
                var testNe = _context.BookType.OrderByDescending(x=>x.BookID).First().BookID;
                // sinh mã tự động dựa trên ID mới nhất

                newID = mdt.AutoGenerateKey(testNe);
            }
            ViewBag.BookID = newID;
            // end
            ViewData["TypeBook"] = new SelectList(_context.Kho, "BookID", "TypeBook");
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageName");
            return View();
        }

        // POST: BookType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,TypeBook,BookTypeNew,AuthorName,LanguageID")] BookType bookType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeBook"] = new SelectList(_context.Kho, "BookID", "TypeBook", bookType.TypeBook);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageName", bookType.LanguageID);
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
            ViewData["TypeBook"] = new SelectList(_context.Kho, "BookID", "TypeBook", bookType.TypeBook);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageName", bookType.LanguageID);
            return View(bookType);
        }

        // POST: BookType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BookID,TypeBook,BookTypeNew,AuthorName,LanguageID")] BookType bookType)
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
            ViewData["TypeBook"] = new SelectList(_context.Kho, "BookID", "TypeBook", bookType.TypeBook);
            ViewData["LanguageID"] = new SelectList(_context.Language, "LanguageID", "LanguageName", bookType.LanguageID);
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

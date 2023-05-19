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
    public class KhoController : Controller
    {
        private readonly ApplicationDbContext _context;

        private ExcelProcess _excelProcess = new ExcelProcess();

        public KhoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kho
        public async Task<IActionResult> Index()
        {
              return _context.Kho != null ? 
                          View(await _context.Kho.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Kho'  is null.");
        }

        // GET: Kho/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Kho == null)
            {
                return NotFound();
            }

            var kho = await _context.Kho
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (kho == null)
            {
                return NotFound();
            }

            return View(kho);
        }

        // GET: Kho/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,BookName,NumberbBook,BookStoreExists,InventoryBook,ExportBook")] Kho kho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kho);
        }

        // GET: Kho/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Kho == null)
            {
                return NotFound();
            }

            var kho = await _context.Kho.FindAsync(id);
            if (kho == null)
            {
                return NotFound();
            }
            return View(kho);
        }

        // POST: Kho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BookID,BookName,NumberbBook,BookStoreExists,InventoryBook,ExportBook")] Kho kho)
        {
            if (id != kho.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoExists(kho.BookID))
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
            return View(kho);
        }

        // GET: Kho/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Kho == null)
            {
                return NotFound();
            }

            var kho = await _context.Kho
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (kho == null)
            {
                return NotFound();
            }

            return View(kho);
        }

        // POST: Kho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Kho == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Kho'  is null.");
            }
            var kho = await _context.Kho.FindAsync(id);
            if (kho != null)
            {
                _context.Kho.Remove(kho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoExists(string id)
        {
          return (_context.Kho?.Any(e => e.BookID == id)).GetValueOrDefault();
        }

        // uploading
          public async Task<IActionResult>Upload()
        {
            return View();
        }
        [HttpPost]
          [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file){

            if(file != null){
                string fileExtension = Path.GetExtension(file.FileName);
                if(fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("","Please choose excel file to upload!");
                }
                else{
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Upload/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        for(int i = 0; i< dt.Rows.Count; i++)
                        {
                            var kh = new Kho();
                            kh.BookID = dt.Rows[i][0].ToString();
                            kh.BookName = dt.Rows[i][1].ToString();
                            kh.NumberbBook = dt.Rows[i][2].ToString();
                            kh.BookStoreExists = dt.Rows[i][3].ToString();
                            kh.InventoryBook = dt.Rows[i][4].ToString();
                            kh.ExportBook = dt.Rows[i][5].ToString();


                            _context.Kho.Add(kh);
                        } 

                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}

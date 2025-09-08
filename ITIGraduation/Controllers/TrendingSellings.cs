using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITIGraduation.Data;
using ITIGraduation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SparkMain.Controllers
{
    [Authorize]

    public class TrendingSellingsController : Controller
    {
        private readonly SparkContext _context;

        public TrendingSellingsController(SparkContext context)
        {
            _context = context;
        }

        // GET: TrendingSellings
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrendingSellings.ToListAsync());
        }

        // GET: TrendingSellings/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trendingSelling = await _context.TrendingSellings
                .FirstOrDefaultAsync(m => m.ProudId == id);
            if (trendingSelling == null)
            {
                return NotFound();
            }

            return View(trendingSelling);
        }

        // GET: TrendingSellings/Create
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: TrendingSellings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(TrendingSelling trendingSelling,
            IFormFile? ImageFile1, IFormFile? ImageFile2, IFormFile? ImageFile3, IFormFile? ImageFile4)
        {
            if (ModelState.IsValid)
            {
                // صورة 1
                if (ImageFile1 != null && ImageFile1.Length > 0)
                {
                    var fileName = Path.GetFileName(ImageFile1.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile1.CopyToAsync(stream);
                    }
                    trendingSelling.ImagUrl = "/images/" + fileName;
                }

                // صورة 2
                if (ImageFile2 != null && ImageFile2.Length > 0)
                {
                    var fileName = Path.GetFileName(ImageFile2.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile2.CopyToAsync(stream);
                    }
                    trendingSelling.Imag2 = "/images/" + fileName;
                }

                // صورة 3
                if (ImageFile3 != null && ImageFile3.Length > 0)
                {
                    var fileName = Path.GetFileName(ImageFile3.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile3.CopyToAsync(stream);
                    }
                    trendingSelling.Imag3 = "/images/" + fileName;
                }

                // صورة 4
                if (ImageFile4 != null && ImageFile4.Length > 0)
                {
                    var fileName = Path.GetFileName(ImageFile4.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile4.CopyToAsync(stream);
                    }
                    trendingSelling.Imag4 = "/images/" + fileName;
                }

                _context.Add(trendingSelling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trendingSelling);
        }

        // GET: TrendingSellings/Edit/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trendingSelling = await _context.TrendingSellings.FindAsync(id);
            if (trendingSelling == null)
            {
                return NotFound();
            }
            return View(trendingSelling);
        }

        // POST: TrendingSellings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, TrendingSelling trendingSelling,
    IFormFile? ImageFile1, IFormFile? ImageFile2, IFormFile? ImageFile3, IFormFile? ImageFile4)
        {
            if (id != trendingSelling.ProudId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProduct = await _context.TrendingSellings.FindAsync(id);
                    if (existingProduct == null)
                    {
                        return NotFound();
                    }

                    // تحديث البيانات الأساسية
                    existingProduct.ProudName = trendingSelling.ProudName;
                    existingProduct.Size = trendingSelling.Size;
                    existingProduct.Price = trendingSelling.Price;

                    // صورة 1
                    if (ImageFile1 != null && ImageFile1.Length > 0)
                    {
                        var fileName = Path.GetFileName(ImageFile1.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile1.CopyToAsync(stream);
                        }
                        existingProduct.ImagUrl = "/images/" + fileName;
                    }

                    // صورة 2
                    if (ImageFile2 != null && ImageFile2.Length > 0)
                    {
                        var fileName = Path.GetFileName(ImageFile2.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile2.CopyToAsync(stream);
                        }
                        existingProduct.Imag2 = "/images/" + fileName;
                    }

                    // صورة 3
                    if (ImageFile3 != null && ImageFile3.Length > 0)
                    {
                        var fileName = Path.GetFileName(ImageFile3.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile3.CopyToAsync(stream);
                        }
                        existingProduct.Imag3 = "/images/" + fileName;
                    }

                    // صورة 4
                    if (ImageFile4 != null && ImageFile4.Length > 0)
                    {
                        var fileName = Path.GetFileName(ImageFile4.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile4.CopyToAsync(stream);
                        }
                        existingProduct.Imag4 = "/images/" + fileName;
                    }

                    _context.Update(existingProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.TrendingSellings.Any(e => e.ProudId == trendingSelling.ProudId))
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
            return View(trendingSelling);
        }

        // GET: TrendingSellings/Delete/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trendingSelling = await _context.TrendingSellings
                .FirstOrDefaultAsync(m => m.ProudId == id);
            if (trendingSelling == null)
            {
                return NotFound();
            }

            return View(trendingSelling);
        }

        // POST: TrendingSellings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trendingSelling = await _context.TrendingSellings.FindAsync(id);
            if (trendingSelling != null)
            {
                _context.TrendingSellings.Remove(trendingSelling);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrendingSellingExists(int id)
        {
            return _context.TrendingSellings.Any(e => e.ProudId == id);
        }
    }
}

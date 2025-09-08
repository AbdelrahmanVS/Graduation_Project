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
    public class ProductsController : Controller
    {
        private readonly SparkContext _context;

        public ProductsController(SparkContext context)
        {
            _context = context;
        }

        // GET: Products
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prouducts.ToListAsync());
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prouduct = await _context.Prouducts
                .FirstOrDefaultAsync(m => m.ProuductId == id);
            if (prouduct == null)
            {
                return NotFound();
            }

            return View(prouduct);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ProuductId,ProuductName,Size,Price")] Prouduct prouduct, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    prouduct.ImagUrl = "/images/" + fileName;
                }

                _context.Add(prouduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prouduct);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prouduct = await _context.Prouducts.FindAsync(id);
            if (prouduct == null)
            {
                return NotFound();
            }
            return View(prouduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Prouduct prouduct, IFormFile? ImageFile)
        {
            if (id != prouduct.ProuductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProduct = await _context.Prouducts.FindAsync(id);
                    if (existingProduct == null)
                        return NotFound();

                    existingProduct.ProuductName = prouduct.ProuductName;
                    existingProduct.Size = prouduct.Size;
                    existingProduct.Price = prouduct.Price;

                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        var fileName = Path.GetFileName(ImageFile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        existingProduct.ImagUrl = "/images/" + fileName;
                    }

                    _context.Update(existingProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProuductExists(prouduct.ProuductId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(prouduct);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prouduct = await _context.Prouducts
                .FirstOrDefaultAsync(m => m.ProuductId == id);
            if (prouduct == null)
            {
                return NotFound();
            }

            return View(prouduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prouduct = await _context.Prouducts.FindAsync(id);
            if (prouduct != null)
            {
                _context.Prouducts.Remove(prouduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProuductExists(int id)
        {
            return _context.Prouducts.Any(e => e.ProuductId == id);
        }
    }
}

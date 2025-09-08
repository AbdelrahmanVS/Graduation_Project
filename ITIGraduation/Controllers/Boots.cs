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
    public class BootsController : Controller
    {
        private readonly SparkContext _context;

        public BootsController(SparkContext context)
        {
            _context = context;
        }

        // GET: Boots
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boots.ToListAsync());
        }

        // GET: Boots/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boot = await _context.Boots
                .FirstOrDefaultAsync(m => m.BootId == id);
            if (boot == null)
            {
                return NotFound();
            }

            return View(boot);
        }

        // GET: Boots/Create
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Boots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([Bind("BootId,BootName,Size,Price")] Boot boot, IFormFile? ImageFile)
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

                    boot.ImagUrl = "~/images/" + fileName;
                }

                _context.Add(boot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boot);
        }

        // GET: Boots/Edit/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boot = await _context.Boots.FindAsync(id);
            if (boot == null)
            {
                return NotFound();
            }
            return View(boot);
        }

        // POST: Boots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        
        public async Task<IActionResult> Edit(int id, [Bind("BootId,BootName,Size,Price,ImagUrl")] Boot boot, IFormFile? ImageFile)
        {
            if (id != boot.BootId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingBoot = await _context.Boots.FindAsync(id);
                    if (existingBoot == null)
                    {
                        return NotFound();
                    }

                    // تحديث البيانات الأساسية
                    existingBoot.BootName = boot.BootName;
                    existingBoot.Size = boot.Size;
                    existingBoot.Price = boot.Price;

                    // لو تم رفع صورة جديدة
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        var fileName = Path.GetFileName(ImageFile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        existingBoot.ImagUrl = "/images/" + fileName;
                    }

                    _context.Update(existingBoot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BootExists(boot.BootId))
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
            return View(boot);
        }

        // GET: Boots/Delete/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boot = await _context.Boots
                .FirstOrDefaultAsync(m => m.BootId == id);
            if (boot == null)
            {
                return NotFound();
            }

            return View(boot);
        }

        // POST: Boots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boot = await _context.Boots.FindAsync(id);
            if (boot != null)
            {
                _context.Boots.Remove(boot);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BootExists(int id)
        {
            return _context.Boots.Any(e => e.BootId == id);
        }
    }
}

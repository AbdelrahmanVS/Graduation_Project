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
    public class OxfordsController : Controller
    {
        private readonly SparkContext _context;

        public OxfordsController(SparkContext context)
        {
            _context = context;
        }

        // GET: Oxfords
        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            return View(await _context.Oxfords.ToListAsync());
        }

        // GET: Oxfords/Details/5
        [AllowAnonymous]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oxford = await _context.Oxfords
                .FirstOrDefaultAsync(m => m.OxfordId == id);
            if (oxford == null)
            {
                return NotFound();
            }

            return View(oxford);
        }

        // GET: Oxfords/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oxfords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Oxford oxford, IFormFile? ImageFile)
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

                    oxford.ImagUrl = "~/images/" + fileName;
                }

                _context.Add(oxford);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oxford);
        }


        // GET: Oxfords/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oxford = await _context.Oxfords.FindAsync(id);
            if (oxford == null)
            {
                return NotFound();
            }
            return View(oxford);
        }

        // POST: Oxfords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("OxfordId,BootName,Size,Price,ImagUrl")] Oxford oxford)
        {
            if (id != oxford.OxfordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oxford);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OxfordExists(oxford.OxfordId))
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
            return View(oxford);
        }

        // GET: Oxfords/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oxford = await _context.Oxfords
                .FirstOrDefaultAsync(m => m.OxfordId == id);
            if (oxford == null)
            {
                return NotFound();
            }

            return View(oxford);
        }

        // POST: Oxfords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oxford = await _context.Oxfords.FindAsync(id);
            if (oxford != null)
            {
                _context.Oxfords.Remove(oxford);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OxfordExists(int id)
        {
            return _context.Oxfords.Any(e => e.OxfordId == id);
        }
    }
}

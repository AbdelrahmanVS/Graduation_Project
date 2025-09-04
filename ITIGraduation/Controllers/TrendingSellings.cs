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
        public async Task<IActionResult> Create([Bind("ProudId,ProudName,Size,Price,ImagUrl,Imag2,Imag3,Imag4")] TrendingSelling trendingSelling)
        {
            if (ModelState.IsValid)
            {
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

        public async Task<IActionResult> Edit(int id, [Bind("ProudId,ProudName,Size,Price,ImagUrl,Imag2,Imag3,Imag4")] TrendingSelling trendingSelling)
        {
            if (id != trendingSelling.ProudId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trendingSelling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrendingSellingExists(trendingSelling.ProudId))
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

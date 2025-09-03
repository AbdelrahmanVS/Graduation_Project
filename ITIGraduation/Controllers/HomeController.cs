using ITIGraduation.Data;
using ITIGraduation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITIGraduation.Data;
using ITIGraduation.Models;
using System.Diagnostics;

namespace SparkMain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SparkContext _context;

        public HomeController(ILogger<HomeController> logger, SparkContext context)
        {
            _logger = logger;
            this._context = context;
        }



        public IActionResult Index()
        {
            List<BestAndTrend> bestandtrend = new List<BestAndTrend> { new BestAndTrend(_context.TrendingSellings.ToList(), _context.Prouducts.ToList()) };


            return View(bestandtrend);
        }

        public async Task<IActionResult> Search(string? searchTerm)
        {
            var result = new SearchResultVM();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                result.Products = await _context.Prouducts
                    .Where(p => p.ProuductName != null && p.ProuductName.Contains(searchTerm))
                    .ToListAsync();

                result.Sports = await _context.Sports
                    .Where(s => s.SportName != null && s.SportName.Contains(searchTerm))
                    .ToListAsync();

                result.Boots = await _context.Boots
                    .Where(b => b.BootName != null && b.BootName.Contains(searchTerm))
                    .ToListAsync();

                result.TrendingSellings = await _context.TrendingSellings
                    .Where(t => t.ProudName != null && t.ProudName.Contains(searchTerm))
                    .ToListAsync();

                result.Oxfords = await _context.Oxfords
                    .Where(o => o.BootName != null && o.BootName.Contains(searchTerm))
                    .ToListAsync();
            }

            return View(result);
        }


        public IActionResult Login()
        {
            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

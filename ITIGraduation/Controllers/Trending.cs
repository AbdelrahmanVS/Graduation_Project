using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITIGraduation.Controllers
{
    public class Trending : Controller
    {
        // GET: Trending
        public ActionResult Index()
        {
            return View();
        }

        // GET: Trending/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trending/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trending/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Trending/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trending/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Trending/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trending/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

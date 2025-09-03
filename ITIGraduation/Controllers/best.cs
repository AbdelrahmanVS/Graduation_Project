using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITIGraduation.Controllers
{
    public class best : Controller
    {
        // GET: best
        public ActionResult Index()
        {
            return View();
        }

        // GET: best/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: best/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: best/Create
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

        // GET: best/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: best/Edit/5
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

        // GET: best/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: best/Delete/5
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

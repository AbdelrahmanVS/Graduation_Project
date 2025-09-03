using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITIGraduation.Controllers
{
    public class Oxfords : Controller
    {
        // GET: Oxfords
        public ActionResult Index()
        {
            return View();
        }

        // GET: Oxfords/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Oxfords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oxfords/Create
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

        // GET: Oxfords/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Oxfords/Edit/5
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

        // GET: Oxfords/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Oxfords/Delete/5
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

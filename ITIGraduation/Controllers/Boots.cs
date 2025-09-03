using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITIGraduation.Controllers
{
    public class Boots : Controller
    {
        // GET: Boots
        public ActionResult Index()
        {
            return View();
        }

        // GET: Boots/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Boots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boots/Create
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

        // GET: Boots/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Boots/Edit/5
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

        // GET: Boots/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Boots/Delete/5
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

using Microsoft.AspNetCore.Mvc;
using libraryManagementSystem.Models;
using libraryManagementSystem;

namespace libraryManagementSystem.Controllers
{
    public class ReaderController : Controller
    {
        private readonly ReaderRepository _repo;

        public ReaderController(ReaderRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var readers = _repo.GetAll();
            return View(readers);
        }

        public IActionResult Details(int id)
        {
            var reader = _repo.GetById(id);
            if (reader == null) return NotFound();
            return View(reader);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reader reader)
        {
            if (!ModelState.IsValid) return View(reader);

            _repo.Add(reader);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var reader = _repo.GetById(id);
            if (reader == null) return NotFound();
            return View(reader);
        }

        [HttpPost]
        public IActionResult Edit(Reader reader)
        {
            if (!ModelState.IsValid) return View(reader);

            _repo.Update(reader);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var reader = _repo.GetById(id);
            if (reader == null) return NotFound();
            return View(reader);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

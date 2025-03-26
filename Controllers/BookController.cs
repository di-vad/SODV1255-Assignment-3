using Microsoft.AspNetCore.Mvc;
using libraryManagementSystem.Models;
using libraryManagementSystem;

namespace libraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repo;

        public BookController(BookRepository repo)
        {
            _repo = repo;
        }

        // GET: /Book
        public IActionResult Index()
        {
            var books = _repo.GetAll();
            return View(books);
        }

        // GET: /Book/Details/5
        public IActionResult Details(int id)
        {
            var book = _repo.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // GET: /Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Book/Create
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid) return View(book);

            _repo.Add(book);
            return RedirectToAction("Index");
        }

        // GET: /Book/Edit/5
        public IActionResult Edit(int id)
        {
            var book = _repo.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: /Book/Edit/5
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid) return View(book);

            _repo.Update(book);
            return RedirectToAction("Index");
        }

        // GET: /Book/Delete/5
        public IActionResult Delete(int id)
        {
            var book = _repo.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: /Book/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

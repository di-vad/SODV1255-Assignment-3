using Microsoft.AspNetCore.Mvc;
using System;
using libraryManagementSystem.Models;
using libraryManagementSystem;

namespace libraryManagementSystem.Controllers
{
    public class BorrowingController : Controller
    {
        private readonly BorrowingRepository _borrowRepo;
        private readonly BookRepository _bookRepo;
        private readonly ReaderRepository _readerRepo;

        public BorrowingController(BorrowingRepository borrowRepo, BookRepository bookRepo, ReaderRepository readerRepo)
        {
            _borrowRepo = borrowRepo;
            _bookRepo = bookRepo;
            _readerRepo = readerRepo;
        }

        public IActionResult Index()
        {
            var borrowings = _borrowRepo.GetAll();
            return View(borrowings);
        }

        public IActionResult Details(int id)
        {
            var borrowing = _borrowRepo.GetById(id);
            if (borrowing == null) return NotFound();
            return View(borrowing);
        }

        public IActionResult Create()
        {
            // We need to let user select a Book and a Reader
            ViewBag.Books = _bookRepo.GetAll();
            ViewBag.Readers = _readerRepo.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Borrowing model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Books = _bookRepo.GetAll();
                ViewBag.Readers = _readerRepo.GetAll();
                return View(model);
            }

            _borrowRepo.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var borrowing = _borrowRepo.GetById(id);
            if (borrowing == null) return NotFound();

            ViewBag.Books = _bookRepo.GetAll();
            ViewBag.Readers = _readerRepo.GetAll();
            return View(borrowing);
        }

        [HttpPost]
        public IActionResult Edit(Borrowing borrowing)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Books = _bookRepo.GetAll();
                ViewBag.Readers = _readerRepo.GetAll();
                return View(borrowing);
            }

            _borrowRepo.Update(borrowing);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var borrowing = _borrowRepo.GetById(id);
            if (borrowing == null) return NotFound();
            return View(borrowing);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _borrowRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

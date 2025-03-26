using libraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace libraryManagementSystem
{
    public class BorrowingRepository
    {
        private static List<Borrowing> _borrowings = new List<Borrowing>
        {
            new Borrowing { Id = 1, BookId = 1, ReaderId = 1, BorrowDate = DateTime.Now.AddDays(-2) }
        };

        public IEnumerable<Borrowing> GetAll()
        {
            return _borrowings;
        }

        public Borrowing GetById(int id)
        {
            return _borrowings.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Borrowing borrowing)
        {
            if (_borrowings.Count > 0)
                borrowing.Id = _borrowings.Max(b => b.Id) + 1;
            else
                borrowing.Id = 1;

            borrowing.BorrowDate = DateTime.Now;
            _borrowings.Add(borrowing);
        }

        public void Update(Borrowing updated)
        {
            var existing = GetById(updated.Id);
            if (existing != null)
            {
                existing.BookId = updated.BookId;
                existing.ReaderId = updated.ReaderId;
                existing.BorrowDate = updated.BorrowDate;
                existing.ReturnDate = updated.ReturnDate;
            }
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                _borrowings.Remove(existing);
            }
        }
    }
}

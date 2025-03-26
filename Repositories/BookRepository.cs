using libraryManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace libraryManagementSystem
{
    public class BookRepository
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Name = "The Great Gatsby", Description = "A novel about the American dream.", Author = "F. Scott Fitzgerald" },
            new Book { Id = 2, Name = "Sample Book 2", Description = "Sample Description", Author = "Sample Author" }
        };

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public Book GetById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Book book)
        {
            if (_books.Count > 0)
                book.Id = _books.Max(b => b.Id) + 1;
            else
                book.Id = 1;
            _books.Add(book);
        }

        public void Update(Book updated)
        {
            var existing = GetById(updated.Id);
            if (existing != null)
            {
                existing.Name = updated.Name;
                existing.Description = updated.Description;
                existing.Author = updated.Author;
            }
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                _books.Remove(existing);
            }
        }
    }
}

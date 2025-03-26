using libraryManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace libraryManagementSystem
{
    public class ReaderRepository
    {
        private static List<Reader> _readers = new List<Reader>
        {
            new Reader { Id = 1, Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
            new Reader { Id = 2, Name = "Jane Doe", Email = "jane@example.com", PhoneNumber = "555-555-5555" }
        };

        public IEnumerable<Reader> GetAll()
        {
            return _readers;
        }

        public Reader GetById(int id)
        {
            return _readers.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Reader reader)
        {
            if (_readers.Count > 0)
                reader.Id = _readers.Max(r => r.Id) + 1;
            else
                reader.Id = 1;
            _readers.Add(reader);
        }

        public void Update(Reader updated)
        {
            var existing = GetById(updated.Id);
            if (existing != null)
            {
                existing.Name = updated.Name;
                existing.Email = updated.Email;
                existing.PhoneNumber = updated.PhoneNumber;
            }
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                _readers.Remove(existing);
            }
        }
    }
}

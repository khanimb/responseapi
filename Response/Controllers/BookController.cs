using Microsoft.AspNetCore.Mvc;
using Response;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt",
                Description = "A practical guide to software development."
            },
            new Book
            {
                Id = 2,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Description = "Best practices for writing clean and maintainable code."
            },
            new Book
            {
                Id = 3,
                Title = "Design Patterns",
                Author = "Erich Gamma",
                Description = "Classic book on object-oriented design patterns."
            },
            new Book
            {
                Id = 4,
                Title = "Refactoring",
                Author = "Martin Fowler",
                Description = "Improving existing code without changing behavior."
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            return Ok(Books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound(new { message = $"ID-si {id} olan kitab tapılmadı." });
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> Create([FromBody] Book newBook)
        {
            newBook.Id = Books.Any() ? Books.Max(b => b.Id) + 1 : 1;

            Books.Add(newBook);

            return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book updatedBook)
        {
            var existingBook = Books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound(new { message = $"ID-si {id} olan kitab tapılmadı." });
            }

            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Description = updatedBook.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound(new { message = $"ID-si {id} olan kitab tapılmadı." });
            }

            Books.Remove(book);
            return NoContent();
        }
    }
}
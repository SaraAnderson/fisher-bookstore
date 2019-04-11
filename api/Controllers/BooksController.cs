using System.Linq;
using Fisher.Bookstore.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreContext db;

        public BooksController(BookstoreContext db)
        {
            this.db = db;

            if (this.db.Books.Count() == 0)
            { 
                this.db.Books.Add(new Book()
                {
                    Id = 1, 
                    Title = "Design Patterns",
                    Author = "Erich Gamma",
                    ISBN = "978-0201633610",
                });
                this.db.Books.Add(new Book()
                {
                    Id = 2,
                    Title = "Continuous Delivery",
                    Author = "Jez Humble",
                    ISBN = "978-0321601919"
                });
                this.db.Books.Add(new Book()
                {
                    Id = 3,
                    Title = "The DevOps Handbook",
                    Author = "Gene Kim",
                    ISBN = "078-1942788003"
                });
            }
            this.db.SaveChanges();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Books);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id)
        {
            // try to find the correct book
            var book = db.Books.FirstOrDefault(b => b.Id == id);

            // if no book is found with the id key, return HTTP 404 Not Found
            if (book == null)
            {
                return NotFound();
            }

            // return the Book inside HTTP 200 OK
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("GetBook", new { id = book.Id}, book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return NoContent();
        }
    }
}
using ASS2_PRN3.Models;
using ASS2_PRN3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASS2_PRN3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private IRepository<Book> repo;
        public BookController(IRepository<Book> repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Book book = repo.Get(id);
            if(book == null)
            {
                return NotFound("There's no book found!");
            }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Post(Book book)
        {
            return Created("Created Success", repo.Add(book));
        }
        [HttpPut]
        public IActionResult Put(Book book)
        {
            Book b = repo.Get(book.BookId);
            if (b == null)
            {
                return NotFound("There's no book found!");
            }
            return Ok(repo.Update(book));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Book book = repo.Get(id);
            if (book == null)
            {
                return NotFound("There's no book found!");
            }
            return Ok(repo.Delete(book));
        }
    }
}

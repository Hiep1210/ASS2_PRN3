using ASS2_PRN3.Models;
using ASS2_PRN3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASS2_PRN3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IRepository<Author> repo;
        public AuthorController(AuthorRepository repo)
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
            Author book = repo.Get(id);
            if (book == null)
            {
                return NotFound("There's no author found!");
            }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Post(Author author)
        {
            return Created("Created Success", repo.Add(author));
        }
        [HttpPut]
        public IActionResult Put(Author author)
        {
            Author b = repo.Get(author.AuthorId);
            if (b == null)
            {
                return NotFound("There's no author found!");
            }
            return Ok(repo.Update(author));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Author book = repo.Get(id);
            if (book == null)
            {
                return NotFound("There's no author found!");
            }
            return Ok(repo.Delete(book));
        }
    }
}

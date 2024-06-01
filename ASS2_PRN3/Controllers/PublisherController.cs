using ASS2_PRN3.Models;
using ASS2_PRN3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASS2_PRN3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private IRepository<Publisher> repo;
        public PublisherController(IRepository<Publisher> repo)
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
            Publisher book = repo.Get(id);
            if (book == null)
            {
                return NotFound("There's no book found!");
            }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Post(Publisher pub)
        {
            return Created("Created Success", repo.Add(pub));
        }
        [HttpPut]
        public IActionResult Put(Publisher publisher)
        {
            Publisher b = repo.Get(publisher.PubId);
            if (b == null)
            {
                return NotFound("There's no book found!");
            }
            return Ok(repo.Update(publisher));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Publisher book = repo.Get(id);
            if (book == null)
            {
                return NotFound("There's no book found!");
            }
            return Ok(repo.Delete(book));
        }
    }
}

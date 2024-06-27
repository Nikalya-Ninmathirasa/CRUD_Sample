using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample_CRUD.Data;
using Sample_CRUD.Models;

namespace Sample_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatergoryController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CatergoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult Get()
        {
            var categories = _dbContext.Category.ToList();
            return Ok(categories);
        }

        // Get id 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("getById")]
        public ActionResult Get(int id)
        {
            var category = _dbContext.Category.FirstOrDefault(x=>x.Id==id);
            if (category == null)
            {
                return NotFound($"The catergory Not Found for id - {id} ");
            }
            return Ok(category);
        }


        //post
       [ProducesResponseType(StatusCodes.Status400BadRequest)]
       [ProducesResponseType(StatusCodes.Status200OK)]
       [ HttpPost]
       public ActionResult Create([FromBody]Category category)
        {
            _dbContext.Category.Add(category);
            _dbContext.SaveChanges();
            return Ok("Created successfully");
        }

        //update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        public ActionResult Update([FromBody] Category category)
        {
            _dbContext.Category.Update(category);
            _dbContext.SaveChanges();
            return NoContent();
        }


        // Delete
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]       
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Should be put an id");
            }
            var category = _dbContext.Category.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound($"The catergory Not Found for id - {id} ");
            }

            _dbContext.Category.Remove(category);
            _dbContext.SaveChanges();
            return NoContent();
        }

    }
}

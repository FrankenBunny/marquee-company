using marquee_backend.Data;
using marquee_backend.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 *  RentableCategoryController is responsible for CRUD operations on the category table.
 *  CREATE - Creates a new category, if the title does not already exist within the table.
 *  READ (SINGLE) - Retrieves a category based on the id.
 *  READ (MULTIPLE) - Retrieves all categories within the category table.
 *  UPDATE - Updates the categories based on the given id, requires a complete object to update, where the given id matches the id in the object.
 *  DELETE - Deletes the category based on the given id.
 *
 **/
namespace marquee_backend.Controllers.Inventory
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentableCategoryController : ControllerBase
    {
        private readonly MarqueeDatabaseContext _databaseContext;

        public RentableCategoryController (MarqueeDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        [HttpPost]
        public async Task<ActionResult> AddRentableCategory (RentableCategory newRentableCategory) 
        {
            newRentableCategory.Id = Guid.NewGuid();
            
            var taken_title = _databaseContext.RentableCategories.Where(item => item.Title == newRentableCategory.Title);

            if (taken_title != null)
              return BadRequest();

            _databaseContext.RentableCategories.Add(newRentableCategory);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRentableCategory), new {id = newRentableCategory.Id}, newRentableCategory);
        }


        [HttpGet("{rentableCategoryId}")]
        public async Task<ActionResult<RentableCategory>> GetRentableCategory (Guid rentableCategoryId)
        {
          var rentableCategories = await _databaseContext.RentableCategories.FindAsync(rentableCategoryId);

          if (rentableCategories == null)
            return NotFound();

          return rentableCategories;
        }


        [HttpGet]
        public async Task<ActionResult<List<RentableCategory>>> GetRentableCategory()
        {
            var rentableCategories = await _databaseContext.RentableCategories.ToListAsync();

            if (rentableCategories == null || !rentableCategories.Any())
            {
                return NotFound(); 
            }  
            
            return rentableCategories;
        }


        [HttpPut("{rentableCategoryId}", Name = "EditRentableCategory")]
        public async Task<IActionResult> EditRentableCategory (Guid rentableCategoryId, RentableCategory updatedRentableCategory)
        {
          if (rentableCategoryId != updatedRentableCategory.Id)
            return BadRequest();

          _databaseContext.Entry(updatedRentableCategory).State = EntityState.Modified;

          try
          {
            await _databaseContext.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            var rentableCategories = await _databaseContext.RentableCategories.FindAsync(rentableCategoryId);
            if (rentableCategories == null)
              return NotFound();
            else
            {
              throw;
            }
          }

          return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveRentableCategory (Guid rentableCategoryId)
        {
          var toBeRemoved = await _databaseContext.RentableCategories.FindAsync(rentableCategoryId);
          if (toBeRemoved == null)
            return NotFound();

          _databaseContext.RentableCategories.Remove(toBeRemoved);
          await _databaseContext.SaveChangesAsync();

          return NoContent();
        }
    }
}

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

        public RentableCategoryController(MarqueeDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<ActionResult> AddRentableCategory(RentableCategory newRentableCategory)
        {
            newRentableCategory.Id = Guid.NewGuid();

            var taken_title = await _databaseContext.RentableCategories.FirstOrDefaultAsync(item =>
                item.Title == newRentableCategory.Title
            );

            if (taken_title != null)
                return BadRequest("Title has already been taken: " + newRentableCategory.Title);

            _databaseContext.RentableCategories.Add(newRentableCategory);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetRentableCategory),
                new { rentableCategoryid = newRentableCategory.Id },
                newRentableCategory
            );
        }

        [HttpGet("{rentableCategoryId}")]
        public async Task<ActionResult<RentableCategory>> GetRentableCategory(
            Guid rentableCategoryId
        )
        {
            var rentableCategories = await _databaseContext.RentableCategories.FindAsync(
                rentableCategoryId
            );

            if (rentableCategories == null)
                return NotFound("There is no item in the table matching ID: " + rentableCategoryId);

            return rentableCategories;
        }

        [HttpGet]
        public async Task<ActionResult<List<RentableCategory>>> GetRentableCategories()
        {
            var rentableCategories = await _databaseContext.RentableCategories.ToListAsync();

            if (rentableCategories == null || !rentableCategories.Any())
            {
                return NotFound("Table is empty.");
            }

            return rentableCategories;
        }

        [HttpPut("{rentableCategoryId}")]
        public async Task<IActionResult> EditRentableCategory(
            Guid rentableCategoryId,
            RentableCategory updatedRentableCategory
        )
        {
            if (rentableCategoryId != updatedRentableCategory.Id)
                return BadRequest(
                    "ID's do not match. Given ID: "
                        + rentableCategoryId
                        + " Object ID: "
                        + updatedRentableCategory.Id
                );

            _databaseContext.Entry(updatedRentableCategory).State = EntityState.Modified;

            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var rentableCategories = await _databaseContext.RentableCategories.FindAsync(
                    rentableCategoryId
                );
                if (rentableCategories == null)
                    return NotFound("No item matches the ID: " + rentableCategoryId);
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRentableCategory(Guid rentableCategoryId)
        {
            var toBeRemoved = await _databaseContext.RentableCategories.FindAsync(
                rentableCategoryId
            );
            if (toBeRemoved == null)
                return NotFound("No item matches the ID: " + rentableCategoryId);

            _databaseContext.RentableCategories.Remove(toBeRemoved);
            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

using marquee_backend.Data;
using marquee_backend.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 *  RentableTagController is responsible for CRUD operations on the tag table.
 *  CREATE - Creates a new tag, if the title does not already exist within the table.
 *  READ (SINGLE) - Retrieves a tag based on the id.
 *  READ (MULTIPLE) - Retrieves all tags within the tag table.
 *  UPDATE - Updates the tags based on the given id, requires a complete object to update, where the given id matches the id in the object.
 *  DELETE - Deletes the tag based on the given id.
 *
 **/

namespace marquee_backend.Controllers.Inventory
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentableTagController : ControllerBase
    {
        private readonly MarqueeDatabaseContext _databaseContext;

        public RentableTagController(MarqueeDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<ActionResult> AddRentableTag(RentableTag newRentableTag)
        {
            newRentableTag.Id = Guid.NewGuid();

            var taken_title = _databaseContext.RentableTags.FirstOrDefaultAsync(item =>
                item.Title == newRentableTag.Title
            );

            if (taken_title != null)
                return BadRequest("Title has already been taken: " + newRentableTag.Title);

            _databaseContext.RentableTags.Add(newRentableTag);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetRentableTag),
                new { rentableTagId = newRentableTag.Id },
                newRentableTag
            );
        }

        [HttpGet("{rentableTagId}")]
        public async Task<ActionResult<RentableTag>> GetRentableTag(Guid rentableTagId)
        {
            var rentableTags = await _databaseContext.RentableTags.FindAsync(rentableTagId);

            if (rentableTags == null)
                return NotFound("No item matches the ID: " + rentableTagId);

            return rentableTags;
        }

        [HttpGet]
        public async Task<ActionResult<List<RentableTag>>> GetRentableTags()
        {
            var rentableTags = await _databaseContext.RentableTags.ToListAsync();

            if (rentableTags == null || !rentableTags.Any())
            {
                return NotFound();
            }

            return rentableTags;
        }

        [HttpPut("{rentableTagId}")]
        public async Task<IActionResult> EditRentableTag(
            Guid rentableTagId,
            RentableTag updatedRentableTag
        )
        {
            if (rentableTagId != updatedRentableTag.Id)
                return BadRequest(
                    "ID's do not match. Given ID: "
                        + rentableTagId
                        + " Object ID: "
                        + updatedRentableTag.Id
                );

            _databaseContext.Entry(updatedRentableTag).State = EntityState.Modified;

            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var rentableTags = await _databaseContext.RentableTags.FindAsync(rentableTagId);
                if (rentableTags == null)
                    return NotFound("No item matches the ID: " + rentableTagId);
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRentableTag(Guid rentableTagId)
        {
            var toBeRemoved = await _databaseContext.RentableTags.FindAsync(rentableTagId);
            if (toBeRemoved == null)
                return NotFound("No item matches the ID: " + rentableTagId);

            _databaseContext.RentableTags.Remove(toBeRemoved);
            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

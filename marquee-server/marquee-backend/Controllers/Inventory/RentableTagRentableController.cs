using marquee_backend.Data;
using marquee_backend.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 *  RentableTagRentableController is responsible for CRUD operations storing the many-to-many relations
 *  between rentables and tags in the related table.
 *  CREATE - Creates a new relation, if the relation does not already exist within the table.
 *  READ (SINGLE) - Retrieves a relation based on the id's of both entities in th relation.
 *  READ (MULTIPLE) - Retrieves all rentables based on the given tag id.
 *  READ (MULTIPLE) - Retrieves all tags based on the given rentable id.
 *  DELETE - Deletes the relation based on the given ids of both objects in the relation.
 *
 **/

namespace marquee_backend.Controllers.Inventory
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentableTagRentableController : ControllerBase
    {
        private readonly MarqueeDatabaseContext _databaseContext;

        public RentableTagRentableController(MarqueeDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<ActionResult> AddRentableTagRentable(
            RentableTagRentable newRentableTagRentable
        )
        {
            var already_existing = _databaseContext.RentableTagRentables.Where(item =>
                item.RentableTagId == newRentableTagRentable.RentableTagId
                && item.RentableId == newRentableTagRentable.RentableId
            );

            if (already_existing != null)
                return BadRequest();

            _databaseContext.RentableTagRentables.Add(newRentableTagRentable);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRentableTagRentable), newRentableTagRentable);
        }

        [HttpGet("tag/{rentableTagId}/rentable/{rentableId}")]
        public async Task<ActionResult<RentableTagRentable>> GetRentableTagRentable(
            Guid rentableTagId,
            Guid rentableId
        )
        {
            var relation = await _databaseContext.RentableTagRentables.FirstOrDefaultAsync(
                relation =>
                    relation.RentableTagId == rentableTagId && relation.RentableId == rentableId
            );

            if (relation == null)
            {
                return NotFound();
            }

            return relation;
        }

        [HttpGet]
        public async Task<ActionResult<List<RentableTagRentable>>> GetRentableTagRentables()
        {
            var rentableTagRentables = await _databaseContext.RentableTagRentables.ToListAsync();

            if (rentableTagRentables == null || !rentableTagRentables.Any())
            {
                return NotFound();
            }

            return rentableTagRentables;
        }

        [HttpGet("tag/{rentableTagId}")]
        public async Task<ActionResult<List<Rentable>>> GetRentablesByTagId(Guid rentableTagId)
        {
            var rentableTagRentableList = await _databaseContext
                .RentableTagRentables.Where(entry => entry.RentableTagId == rentableTagId)
                .ToListAsync();

            if (rentableTagRentableList == null || !rentableTagRentableList.Any())
                return NotFound();

            var rentableIds = rentableTagRentableList.Select(entry => entry.RentableId).ToList();
            var rentables = await _databaseContext
                .Rentables.Where(rentable => rentableIds.Contains(rentable.Id))
                .ToListAsync();

            return rentables;
        }

        [HttpGet("rentable/{rentableId}")]
        public async Task<ActionResult<List<RentableTag>>> GetTagsByRentableId(Guid rentableId)
        {
            var rentableTagRentableList = await _databaseContext
                .RentableTagRentables.Where(entry => entry.RentableId == rentableId)
                .ToListAsync();

            if (rentableTagRentableList == null || !rentableTagRentableList.Any())
                return NotFound();

            var rentableTagIds = rentableTagRentableList
                .Select(entry => entry.RentableTagId)
                .ToList();
            var rentableTags = await _databaseContext
                .RentableTags.Where(rentableTag => rentableTagIds.Contains(rentableTag.Id))
                .ToListAsync();

            return rentableTags;
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRentableTagRentable(Guid rentableTagRentableId)
        {
            var toBeRemoved = await _databaseContext.RentableTagRentables.FindAsync(
                rentableTagRentableId
            );
            if (toBeRemoved == null)
                return NotFound();

            _databaseContext.RentableTagRentables.Remove(toBeRemoved);
            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

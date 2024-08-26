using marquee_backend.Data;
using marquee_backend.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 *  RentableController is responsible for CRUD operations on the rentable table.
 *  CREATE - Creates a new rentable, if the title does not already exist within the table.
 *  READ (SINGLE) - Retrieves a rentable based on the id.
 *  READ (MULTIPLE) - Retrieves all rentables within the rentable table.
 *  READ (MULTIPLE) - Retrieves all rentables based on category id.
 *  UPDATE - Updates the rentables based on the given id, requires a complete object to update, where the given id matches the id in the object.
 *  DELETE - Deletes the rentable based on the given id.
 *
 **/

namespace marquee_backend.Controllers.Inventory
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentableController : ControllerBase
    {
        private readonly MarqueeDatabaseContext _databaseContext;

        public RentableController(MarqueeDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<ActionResult> AddRentable(Rentable newRentable)
        {
            newRentable.Id = Guid.NewGuid();

            var taken_title = _databaseContext.Rentables.Where(item =>
                item.Title == newRentable.Title
            );

            if (taken_title != null)
                return BadRequest();

            _databaseContext.Rentables.Add(newRentable);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRentable), new { id = newRentable.Id }, newRentable);
        }

        [HttpGet("{rentableId}")]
        public async Task<ActionResult<Rentable>> GetRentable(Guid rentableId)
        {
            var rentable = await _databaseContext.Rentables.FindAsync(rentableId);

            if (rentable == null)
                return NotFound();

            return rentable;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rentable>>> GetRentables()
        {
            var rentables = await _databaseContext.Rentables.ToListAsync();

            if (rentables == null || !rentables.Any())
            {
                return NotFound();
            }

            return rentables;
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<List<Rentable>>> GetRentables(Guid categoryId)
        {
            var rentables = await _databaseContext
                .Rentables.Where(rentable => rentable.Type == categoryId)
                .ToListAsync();

            if (rentables == null || !rentables.Any())
            {
                return NotFound();
            }

            return rentables;
        }

        [HttpPut("{rentableId}")]
        public async Task<IActionResult> EditRentable(Guid rentableId, Rentable updatedRentable)
        {
            if (rentableId != updatedRentable.Id)
                return BadRequest();

            _databaseContext.Entry(updatedRentable).State = EntityState.Modified;

            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var rentable = await _databaseContext.Rentables.FindAsync(rentableId);
                if (rentable == null)
                    return NotFound();
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRentable(Guid rentableId)
        {
            var toBeRemoved = await _databaseContext.Rentables.FindAsync(rentableId);
            if (toBeRemoved == null)
                return NotFound();

            _databaseContext.Rentables.Remove(toBeRemoved);
            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

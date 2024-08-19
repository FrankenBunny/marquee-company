using marquee_backend.Data;
using marquee_backend.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 *  PartController is responsible for CRUD operations on the Parts table.
 *  CREATE - Creates a new part, if the title does not already exist within the table.
 *  READ (SINGLE) - Retrieves a part based on the id.
 *  READ (MULTIPLE) - Retrieves all parts within the parts table.
 *  READ (MULTIPLE) - Retrieves all parts based on a rentable id.
 *  UPDATE - Updates the parts based on the given id, requires a complete object to update, where the given id matches the id in the object.
 *  DELETE - Deletes the part based on the given id.
 *
 **/
namespace marquee_backend.Controllers.Inventory
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartController : ControllerBase
    {
        private readonly MarqueeDatabaseContext _databaseContext;

        public PartController(MarqueeDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<ActionResult> AddPart(Part newPart)
        {
            newPart.Id = Guid.NewGuid();

            var taken_title = _databaseContext.Parts.Where(item => item.Title == newPart.Title);

            if (taken_title != null)
                return BadRequest();

            _databaseContext.Parts.Add(newPart);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPart), new { id = newPart.Id }, newPart);
        }

        [HttpGet("{partId}")]
        public async Task<ActionResult<Part>> GetPart(Guid partId)
        {
            var part = await _databaseContext.Parts.FindAsync(partId);

            if (part == null)
                return NotFound();

            return part;
        }

        [HttpGet]
        public async Task<ActionResult<List<Part>>> GetParts()
        {
            var parts = await _databaseContext.Parts.ToListAsync();

            if (parts == null || !parts.Any())
            {
                return NotFound();
            }

            return parts;
        }

        [HttpGet("partsByRentableId{rentableId}")]
        public async Task<ActionResult<List<Part>>> GetPartsByRentableId(Guid rentableId)
        {
            var parts = await _databaseContext
                .Parts.Where(part => part.RentableId == rentableId)
                .ToListAsync();

            if (parts == null || !parts.Any())
            {
                return NotFound();
            }

            return parts;
        }

        [HttpPut("{partId}")]
        public async Task<IActionResult> EditPart(Guid partId, Part updatedPart)
        {
            if (partId != updatedPart.Id)
                return BadRequest();

            _databaseContext.Entry(updatedPart).State = EntityState.Modified;

            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var part = await _databaseContext.Parts.FindAsync(partId);
                if (part == null)
                    return NotFound();
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePart(Guid partId)
        {
            var toBeRemoved = await _databaseContext.Parts.FindAsync(partId);
            if (toBeRemoved == null)
                return NotFound();

            _databaseContext.Parts.Remove(toBeRemoved);
            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

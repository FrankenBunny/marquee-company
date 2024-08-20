using marquee_backend.Data;
using marquee_backend.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 *  ItemController is responsible for CRUD operations on the Items table.
 *  CREATE - Creates a new item, if the title does not already exist within the table.
 *  READ (SINGLE) - Retrieves an item based on the id.
 *  READ (MULTIPLE) - Retrieves all items within the items table.
 *  UPDATE - Updates the items based on the given id, requires a complete object to update, where the given id matches the id in the object.
 *  DELETE - Deletes the item based on the given id.
 *
 **/
namespace marquee_backend.Controllers.Inventory
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly MarqueeDatabaseContext _databaseContext;

        public ItemController(MarqueeDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<ActionResult> AddItem(Item newItem)
        {
            newItem.Id = Guid.NewGuid();

            var taken_title = await _databaseContext.Items.FirstOrDefaultAsync(item =>
                item.Title == newItem.Title
            );

            if (taken_title != null)
                return BadRequest("Title has already been taken: " + newItem.Title);

            _databaseContext.Items.Add(newItem);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { itemId = newItem.Id }, newItem);
        }

        [HttpGet("{itemId}")]
        public async Task<ActionResult<Item>> GetItem(Guid itemId)
        {
            var item = await _databaseContext.Items.FindAsync(itemId);

            if (item == null)
                return NotFound("No item matches the ID: " + itemId);

            return item;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var items = await _databaseContext.Items.ToListAsync();

            if (items == null || !items.Any())
            {
                return NotFound();
            }

            return items;
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> EditItem(Guid itemId, Item updatedItem)
        {
            if (itemId != updatedItem.Id)
                return BadRequest(
                    "ID's do not match. Given ID: " + itemId + " Object ID: " + updatedItem.Id
                );

            _databaseContext.Entry(updatedItem).State = EntityState.Modified;

            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _databaseContext.Items.FindAsync(itemId);
                if (item == null)
                    return NotFound("No item matches the ID: " + itemId);
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveItem(Guid itemId)
        {
            var toBeRemoved = await _databaseContext.Items.FindAsync(itemId);
            if (toBeRemoved == null)
                return NotFound("No item matches the ID: " + itemId);

            _databaseContext.Items.Remove(toBeRemoved);
            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

using Swashbuckle.AspNetCore.Annotations;

namespace marquee_backend.Models.Inventory;

/**
 * The Item represents an item which can be utílized by many Rentables within the inventory system.
 * An Item is required to have an ID and Title, and can have a Note.
 **/
public partial class Item {
  [SwaggerSchema(ReadOnly = true)]
  public Guid Id { get; set; }
  public String Title { get; set; } = null!;
  public String? Note { get; set; }
}
using Swashbuckle.AspNetCore.Annotations;

namespace marquee_backend.Models.Inventory;

/**
 * The Part represents a part of a Rentable within the inventory system.
 * A Part is required to have an ID and Title, and can also have
 * a note.
 **/
public partial class Part {
  [SwaggerSchema(ReadOnly = true)]
  public Guid Id { get; set; }
  public String Title { get; set; } = null!;
  public String? Note { get; set; }
  public Guid RentableId { get; set; }
}
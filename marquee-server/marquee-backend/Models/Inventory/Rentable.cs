using Swashbuckle.AspNetCore.Annotations;

namespace marquee_backend.Models.Inventory;

/**
 * The Rentable represents a rentable item within the inventory system.
 * A Rentable is required to have an ID and Title, and can also have
 * a note and type.
 **/
public partial class Rentable {
  [SwaggerSchema(ReadOnly = true)]
  public Guid Id { get; set; }
  public String Title { get; set; } = null!;
  public String? Note { get; set; }
  public Guid? Type {get; set;}
}
using Swashbuckle.AspNetCore.Annotations;

namespace marquee_backend.Models.Inventory;

/**
 * The RentableTag
 **/
public partial class RentableTag {
  [SwaggerSchema(ReadOnly = true)]
  public Guid Id { get; set; }
  public String Title { get; set; } = null!;
  public String Description { get; set; } = null!;
}
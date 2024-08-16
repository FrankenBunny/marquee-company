using Swashbuckle.AspNetCore.Annotations;

namespace marquee_backend.Models.Inventory;

public class RentableTagRentable {
  [SwaggerSchema(ReadOnly = true)]
  public Guid RentableTagId { get; set; }
  public Guid RentableId { get; set; }
}
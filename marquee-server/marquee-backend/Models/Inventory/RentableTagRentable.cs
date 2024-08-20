using Swashbuckle.AspNetCore.Annotations;

namespace marquee_backend.Models.Inventory;

public class RentableTagRentable
{
    public Guid Id { get; set; }
    public Guid RentableTagId { get; set; }
    public Guid RentableId { get; set; }
}

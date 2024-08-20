using Swashbuckle.AspNetCore.Annotations;

namespace marquee_backend.Models.Inventory;

/**
 * The RentableCategory
 **/
public partial class RentableCategory
{
    public Guid Id { get; set; }
    public String Title { get; set; } = null!;
    public String Description { get; set; } = null!;
}

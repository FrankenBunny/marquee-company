namespace MarqueeBackend.Entities.Dtos.Requests;

public class UpdateRentableRequest
{
    public Guid RentableId { get; set; }
    public Guid? CategoryId { get; set; }
    public string RentableTitle { get; set; } = string.Empty;
    public string? RentableNote { get; set; }
}

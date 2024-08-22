namespace MarqueeBackend.Entities.Dtos.Requests;

public class CreateRentableRequest
{
    public string RentableTitle { get; set; } = string.Empty;
    public string? RentableNote { get; set; }
    public Guid? CategoryId { get; set; }
}

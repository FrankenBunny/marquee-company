namespace MarqueeBackend.Entities.Dtos.Response;

public class RentableResponse
{
    public Guid RentableId { get; set; }
    public string RentableTitle { get; set; } = string.Empty;
    public string? RentableNote { get; set; }
    public Guid? CategoryId { get; set; }
}

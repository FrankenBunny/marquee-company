namespace MarqueeBackend.Entities.Dtos.Requests;

public class CreatePartRequest
{
    public Guid RentableId { get; set; }
    public string PartTitle { get; set; } = string.Empty;
    public string? PartNote { get; set; }
}

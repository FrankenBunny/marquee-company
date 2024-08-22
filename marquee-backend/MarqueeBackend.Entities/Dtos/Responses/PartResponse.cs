namespace MarqueeBackend.Entities.Dtos.Response;

public class PartResponse
{
    public Guid RentableId { get; set; }
    public string PartTitle { get; set; } = string.Empty;
    public string PartNote { get; set; } = string.Empty;
}

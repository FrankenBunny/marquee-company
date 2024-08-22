namespace MarqueeBackend.Entities.Dtos.Requests;

public class UpdatePartRequest
{
    public Guid RentableId { get; set; }
    public string PartTitle { get; set; } = string.Empty;
    public string PartNote { get; set; } = string.Empty;
}

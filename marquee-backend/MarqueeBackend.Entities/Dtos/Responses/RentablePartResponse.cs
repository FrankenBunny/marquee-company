namespace dotnetFullstack.Entities.Dtos.Response;

public class RentablePartResponse
{
    public Guid RentableId { get; set; }
    public string PartTitle { get; set; } = string.Empty;
    public string PartNote { get; set; } = string.Empty;
}

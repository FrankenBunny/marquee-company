namespace dotnetFullstack.Entities.Dtos.Requests;

public class CreateRentablePartRequest
{
    public Guid RentableId { get; set; }
    public string PartTitle { get; set; } = string.Empty;
    public string PartNote { get; set; } = string.Empty;
}

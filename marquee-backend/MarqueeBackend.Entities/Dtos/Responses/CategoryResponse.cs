namespace MarqueeBackend.Entities.Dtos.Response;

public class CategoryResponse
{
    public Guid CategoryId { get; set; }
    public string CategoryTitle { get; set; } = string.Empty;
    public string? CategoryDescription { get; set; }
}

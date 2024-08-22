namespace MarqueeBackend.Entities.Dtos.Requests;

public class UpdateCategoryRequest
{
    public string CategoryTitle { get; set; } = string.Empty;
    public string? CategoryDescription { get; set; }
}

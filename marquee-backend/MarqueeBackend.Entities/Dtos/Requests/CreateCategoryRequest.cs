namespace MarqueeBackend.Entities.Dtos.Requests;

public class CreateCategoryRequest
{
    public string CategoryTitle { get; set; } = string.Empty;
    public string? CategoryDescription { get; set; }
}

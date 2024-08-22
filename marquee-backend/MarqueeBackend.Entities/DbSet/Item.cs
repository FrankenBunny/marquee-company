namespace MarqueeBackend.Entities.DbSet;

public class Item : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Note { get; set; }
}

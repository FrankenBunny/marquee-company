namespace MarqueeBackend.Entities.DbSet;

public class Rentable : BaseEntity
{
    public Rentable()
    {
        Parts = new HashSet<Part>();
    }

    public string Title { get; set; } = string.Empty;
    public string? Note { get; set; }
    public Guid? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Part> Parts { get; set; }
}

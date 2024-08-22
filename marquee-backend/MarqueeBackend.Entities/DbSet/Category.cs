namespace MarqueeBackend.Entities.DbSet;

public class Category : BaseEntity
{
    public Category()
    {
        Rentables = new HashSet<Rentable>();
    }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<Rentable> Rentables { get; set; }
}

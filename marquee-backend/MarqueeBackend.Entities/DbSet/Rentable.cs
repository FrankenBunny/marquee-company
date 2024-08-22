namespace dotnetFullstack.Entities.DbSet;

public class Rentable : BaseEntity
{

    public Rentable()
    {
        Parts = new HashSet<Part>();
    }

    public string Title { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;

    public virtual ICollection<Part> Parts { get; set; }
}
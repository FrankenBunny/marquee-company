namespace MarqueeBackend.Entities.DbSet;

public class Part : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Note { get; set; }
    public Guid RentableId { get; set; }

    public virtual Rentable? Rentable { get; set; }
}

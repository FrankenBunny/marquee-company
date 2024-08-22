namespace dotnetFullstack.Entities.DbSet;

public class BaseEntity {
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; }
    public int Status { get; set; }
}
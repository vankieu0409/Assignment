namespace Iot.Assignment.Domain.Entities;

public class University : FullEntityBase<Guid>
{
    public string  Name { get; set; }
    public Guid MajorsId { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Majors> MajorsCollection { get; set; }
}
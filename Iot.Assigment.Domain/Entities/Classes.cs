namespace Iot.Assignment.Domain.Entities;

public class Classes : FullEntityBase<Guid>
{
    public Guid MajorId { get; set; }
    public Guid SubjectId { get; set; }
    public Guid StudentId { get; set; }
    public string Name { get; set; }
    public string? Classroom { get; set; }
    public virtual ICollection<Student> StudentCollection { get; set; }
    public virtual ICollection<Subjects> SubjectCollection { get; set; }
    public virtual Majors Majors { get; set; }
}
namespace Iot.Assignment.Domain.Entities;

public class Subjects: FullEntityBase<Guid>
{
    public Guid StudentId { get; set; }
    public Guid ScoresId { get; set; }
    public string? Decription { get; set; }
    public string? Sylibus { get; set; }
    public virtual Scores Scores { get; set; }
    public virtual Student Students{ get; set; }
}
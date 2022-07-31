namespace Iot.Assignment.Domain.Entities;

public class Scores : EntityBase<Guid>
{
    public Guid SubjectId { get; set; }
    public string ScoreName { get; set; }
    public double? Point { get; set; }
    public virtual Subjects Subjects { get; set; }
}
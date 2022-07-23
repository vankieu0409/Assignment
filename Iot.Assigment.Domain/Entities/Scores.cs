namespace Iot.Assignment.Domain.Entities;

public class Scores : EntityBase<Guid>
{
    public Guid StudentId { get; set; }
    public Guid SubjectId { get; set; }
    public double? Lab { get; set; }
    public double? Quiz { get; set; }
    public double? Assignment { get; set; }
    public double Document { get; set; }
    public virtual Subjects Subjects { get; set; }
    public virtual Student Students { get; set; }
}
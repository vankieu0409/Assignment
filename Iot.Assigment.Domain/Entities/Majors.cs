namespace Iot.Assignment.Domain.Entities;

public class Majors : FullEntityBase<Guid>
{
    public Guid UniversityId { get; set; }
    public Guid ClasseId { get; set; }
    public string  Name { get; set; }
    public string?  Descreption { get; set; }
    public virtual University Universities { get; set; }
    public virtual ICollection<Classes> ClassesCollection { get; set; }
}
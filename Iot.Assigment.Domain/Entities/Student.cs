using System.ComponentModel.DataAnnotations;
using Iot.Assignment.Domain.Enums;
using Iot.Assignment.Domain.ValueObjects;

namespace Iot.Assignment.Domain.Entities;

public class Student: FullEntityBase<Guid>
{
    public Guid ClassId { get; set; }
    public Guid ScoreId { get; set; }

    public string FistName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public GendersType? Gender { get; set; }
    public AddressValueObject? Address { get; set; }
    public string? Email { get; set; }
    public string? NumberPhone { get; set; }
    public virtual ICollection<Classes> Classes { get; set; }
    public virtual Scores Scores { get; set; }

}
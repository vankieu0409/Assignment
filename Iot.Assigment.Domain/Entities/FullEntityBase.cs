using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iot.Assignment.Domain.Entities;

public abstract class FullEntityBase<TKey>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual TKey Id { get; protected set; }
    public DateTimeOffset CreatedTime { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTimeOffset ModifiedTime { get; set; }

    public Guid? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTimeOffset DeletedTime { get; set; }
}
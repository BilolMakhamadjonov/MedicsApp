using System.ComponentModel.DataAnnotations;

namespace Medics.Core.Comman;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
}

using Medics.Core.Comman;
using Medics.Core.Entities.Enum;

namespace Medics.Core.Entities;

public class PersonalCabinet : BaseEntity
{
    public long MySaved { get; set; }
    public AppointmentPayment Appointment { get; set; }
    public Guid AppointmentId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
}

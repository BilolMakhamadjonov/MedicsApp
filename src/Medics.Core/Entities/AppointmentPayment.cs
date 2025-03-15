using Medics.Core.Comman;
using Medics.Core.Entities.Enum;

namespace Medics.Core.Entities;

public class AppointmentPayment : BaseEntity
{
    public PaymentMethod PaymentMethod { get; set; } // enum 
    public decimal ConsultationPrice { get; set; }
    public decimal AdminFee { get; set; }
    public decimal TotalPrice { get; set; }
    public Appointment Appointment { get; set; }
    public Guid AppointmentId { get; set; }
}

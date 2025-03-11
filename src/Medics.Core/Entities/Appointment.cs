using Medics.Core.Abstraction;

namespace Medics.Core.Entities;

public class Appointment : BaseEntity
{
    public DateTime BookingDate { get; set; }
    public string Reason { get; set; } // kasalli sababi
    public User User { get; set; }
    public Guid UserId { get; set; }
    public Doctor Doctor {  get; set; }
    public Guid DoctorId { get; set; }
    public AppointmentPayment Payment { get; set; }
}

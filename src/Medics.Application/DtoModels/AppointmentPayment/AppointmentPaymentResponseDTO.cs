using Medics.Core.Entities.Enum;

namespace Medics.Application.DtoModels.AppointmentPayment;

public class AppointmentPaymentResponseDTO
{
    public Guid Id { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal ConsultationPrice { get; set; }
    public decimal AdminFee { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid AppointmentId { get; set; }
}

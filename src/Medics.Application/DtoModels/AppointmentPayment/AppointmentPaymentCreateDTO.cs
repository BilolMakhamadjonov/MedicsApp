using Medics.Core.Entities.Enum;

namespace Medics.Application.DtoModels.AppointmentPayment;

public class AppointmentPaymentCreateDTO
{
    public PaymentMethod PaymentMethod { get; set; }
    public decimal ConsultationPrice { get; set; }
    public decimal AdminFee { get; set; }
    public Guid AppointmentId { get; set; }
}

public class CreateAppointmentPaymentResponseDTO : BaseResponseDTO { }

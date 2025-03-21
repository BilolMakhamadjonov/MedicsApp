using Medics.Core.Entities.Enum;

namespace Medics.Application.DtoModels.AppointmentPayment;

public class AppointmentPaymentUpdateDTO
{
    public PaymentMethod? PaymentMethod { get; set; }
    public decimal? ConsultationPrice { get; set; }
    public decimal? AdminFee { get; set; }
}

public class UpdateAppointmentPaymentResponseDTO : BaseResponseDTO { }

using Medics.Core.Entities.Enum;

namespace Medics.Application.DtoModels.PharmacyPayment;

public class PharmacyPaymentUpdateDTO
{
    public PaymentMethod? PaymentMethod { get; set; }
    public decimal? SubTotal { get; set; }
    public decimal? Taxes { get; set; }
    public decimal? TotalPrice { get; set; }
}

public class UpdatePharmacyPaymentResponseDTO : BaseResponseDTO { }

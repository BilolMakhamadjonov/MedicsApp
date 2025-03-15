using Medics.Core.Entities.Enum;

namespace Medics.Application.DtoModels.PharmacyPayment;

public class PharmacyPaymentResponseDTO
{
    public Guid Id { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Taxes { get; set; }
    public decimal TotalPrice { get; set; }
}

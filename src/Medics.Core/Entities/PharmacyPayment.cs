using Medics.Core.Abstraction;
using Medics.Core.Entities.Enum;

namespace Medics.Core.Entities;

public class PharmacyPayment : BaseEntity
{
    public PaymentMethod PaymentMethod { get; set; }
    public decimal SubTotal { get; set; } // olingan dorilani umumiy summasi
    public decimal Taxes { get; set; } // soliqlar
    public decimal TotalPrice { get; set; }
}

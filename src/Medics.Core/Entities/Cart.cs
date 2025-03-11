using Medics.Core.Abstraction;

namespace Medics.Core.Entities;

public class Cart : BaseEntity // savat
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public PharmacyDetails PharmacyDetails { get; set; }
    public Guid PharmacyDetailsId { get; set; }
    public decimal Total { get; set; }
    public PharmacyPayment PharmacyPayment { get; set; }
    public Guid PharmacyPaymentId { get; set; }
}

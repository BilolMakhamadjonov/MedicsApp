using Medics.Core.Comman;
using Medics.Core.Comman;

namespace Medics.Core.Entities;

public class Cart : BaseEntity // savat
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public decimal Total { get; set; }
    public PharmacyPayment PharmacyPayment { get; set; }
    public Guid PharmacyPaymentId { get; set; }
}

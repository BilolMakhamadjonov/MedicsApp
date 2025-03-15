using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class PharmacyPaymentRepository : BaseRepository<PharmacyPayment>, IPharmacyPaymentRepository
{
    public PharmacyPaymentRepository(AppDbContext context) : base(context) { }

}

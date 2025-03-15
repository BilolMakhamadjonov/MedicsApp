using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class PharmacyDetailsRepository : BaseRepository<PharmacyDetails>, IPharmacyDetailsRepository
{
    public PharmacyDetailsRepository(AppDbContext context) : base(context) { }

}

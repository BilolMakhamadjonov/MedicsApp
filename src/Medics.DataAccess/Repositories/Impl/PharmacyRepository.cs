using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class PharmacyRepository : BaseRepository<Pharmacy>, IPharmacyRepository
{
    public PharmacyRepository(AppDbContext context) : base(context) { }
}

using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class DoctorDetailsRepository : BaseRepository<DoctorDetails>, IDoctorDetailsRepository
{
    public DoctorDetailsRepository(AppDbContext context) : base(context) { }
}

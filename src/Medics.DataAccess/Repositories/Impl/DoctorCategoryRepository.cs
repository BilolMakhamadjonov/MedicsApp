using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class DoctorCategoryRepository : BaseRepository<DoctorCategory>, IDoctorCategoryRepository
{
    public DoctorCategoryRepository(AppDbContext context) : base(context) { }
}

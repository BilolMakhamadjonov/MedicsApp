using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class AmbulanceRepository : BaseRepository<Ambulance>, IAmbulanceRepository
{
    public AmbulanceRepository(AppDbContext context) : base(context) { }
}

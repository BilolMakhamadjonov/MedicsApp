using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class GeolocationRepository : BaseRepository<Geolocation>, IGeolocationRepository
{
    public GeolocationRepository(AppDbContext context) : base(context) { }

}

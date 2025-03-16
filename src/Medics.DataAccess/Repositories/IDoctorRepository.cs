using Medics.Core.Entities;

namespace Medics.DataAccess.Repositories;

public interface IDoctorRepository : IBaseRepository<Doctor> 
{
    Task<List<Doctor>> GetAllWithIncludesAsync();
}
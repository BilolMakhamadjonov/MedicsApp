using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class PersonalCabinetRepository : BaseRepository<PersonalCabinet>, IPersonalCabinetRepository
{
    public PersonalCabinetRepository(AppDbContext context) : base(context) { }

}

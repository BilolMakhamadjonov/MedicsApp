using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class AppointmentRepository : BaseRepository<AppointmentPayment>, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext context) : base(context) { }
}

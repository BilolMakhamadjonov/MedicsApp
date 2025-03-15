using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
{
    public Appointment(AppDbContext context) : base(context) { }
}

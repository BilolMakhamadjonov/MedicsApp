using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class AppointmentPaymentRepo : BaseRepository<AppointmentPayment>, IAppointmentPaymentRepo
{
    public AppointmentPaymentRepo(AppDbContext context) : base(context) { }
}

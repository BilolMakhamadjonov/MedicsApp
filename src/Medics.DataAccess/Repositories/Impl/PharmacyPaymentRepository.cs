using Medics.Core.Entities;
using Medics.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.DataAccess.Repositories.Impl
{
    public class PharmacyPaymentRepository:BaseRepository<PharmacyPayment>,IPharmacyPaymentRepository
    {
        public PharmacyPaymentRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}

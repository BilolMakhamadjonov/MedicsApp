using Medics.Core.Entities;
using Medics.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.DataAccess.Repositories.Impl
{
    public class DoctorRepository:BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}

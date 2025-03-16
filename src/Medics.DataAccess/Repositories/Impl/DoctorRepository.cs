using Medics.Core.Entities;
using Medics.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.DataAccess.Repositories.Impl
{
    public class DoctorRepository:BaseRepository<Doctor>, IDoctorRepository
    {
        private readonly AppDbContext _appDbContext;
        public DoctorRepository(AppDbContext dbContext) : base(dbContext) 
        {
            _appDbContext = dbContext;
        }
        public async Task<List<Doctor>> GetAllWithIncludesAsync()
        {
            return await _appDbContext.Doctors
                .Include(d => d.DoctorCategory)
                .Include(d => d.User)
                .Include(d => d.DoctorDetails)
                .ToListAsync();
        }
    }
}

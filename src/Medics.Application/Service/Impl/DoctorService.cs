using Medics.Application.DtoModels.Doctor;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.Application.Service.Impl
{
    public class DoctorService:IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<DoctorResponseDTO>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAllWithIncludesAsync();

            return doctors.Select(d => new DoctorResponseDTO
            {
                Id = d.Id,
                FullName = d.User?.FullName ?? "",
                Category = d.DoctorCategory?.Name ?? "",
                AverageStars = d.DoctorDetails?.AverageStars ?? 4.7,
                Distance = "800m"
            }).ToList();
        }
    }
}

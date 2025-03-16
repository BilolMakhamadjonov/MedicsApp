using Medics.Application.DtoModels.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.Application.Service
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorResponseDTO>> GetAllDoctorsAsync();
    }
}

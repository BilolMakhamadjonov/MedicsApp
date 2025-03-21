using Medics.Application.DtoModels;
using Medics.Application.DtoModels.Doctor;

namespace Medics.Application.Service;

public interface IDoctorService
{
    Task<List<DoctorResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CreateDoctorResponseDTO> CreateAsync(DoctorCreateDTO createDoctorModel, CancellationToken cancellationToken = default);
    Task<UpdateDoctorResponseDTO> UpdateAsync(Guid id, DoctorUpdateDTO updateDoctorModel, CancellationToken cancellationToken = default);
    Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
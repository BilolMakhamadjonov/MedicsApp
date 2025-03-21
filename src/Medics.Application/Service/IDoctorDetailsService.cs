using Medics.Application.DtoModels;
using Medics.Application.DtoModels.DoctorDetails;

namespace Medics.Application.Service;

public interface IDoctorDetailsService
{
    Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UpdateDoctorDetailsResponseDTO> UpdateAsync(Guid id, DoctorDetailsUpdateDTO updateModel, CancellationToken cancellationToken = default);
    Task<CreateDoctorDetailsResponseDTO> CreateAsync(DoctorDetailsCreateDTO createModel, CancellationToken cancellationToken = default);
    Task<List<DoctorDetailsResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
}

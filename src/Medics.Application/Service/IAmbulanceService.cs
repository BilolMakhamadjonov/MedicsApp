using Medics.Application.DtoModels.Ambulance;
using Medics.Application.DtoModels;

namespace Medics.Application.Service;

public interface IAmbulanceService
{
    Task<List<AmbulanceResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<AmbulanceResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CreateAmbulanceResponseDTO> CreateAsync(AmbulanceCreateDTO model, CancellationToken cancellationToken = default);
    Task<UpdateAmbulanceResponseDTO> UpdateAsync(Guid id, AmbulanceUpdateDTO model, CancellationToken cancellationToken = default);
    Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
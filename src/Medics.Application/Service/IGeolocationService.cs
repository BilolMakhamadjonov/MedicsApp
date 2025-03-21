using Medics.Application.DtoModels;
using Medics.Application.DtoModels.Geolocation;

namespace Medics.Application.Service;

public interface IGeolocationService
{
    Task<List<GeolocationResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CreateGeolocationResponseDTO> CreateAsync(GeolocationCreateDTO createModel, CancellationToken cancellationToken = default);
    Task<UpdateGeolocationResponseDTO> UpdateAsync(Guid id, GeolocationUpdateDTO updateModel, CancellationToken cancellationToken = default);
    Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

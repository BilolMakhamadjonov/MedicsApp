using Medics.Application.DtoModels;
using Medics.Application.DtoModels.PersonalCabinet;

namespace Medics.Application.Service;

public interface IPersonalCabinetService
{
    Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UpdatePersonalCabinetResponseDTO> UpdateAsync(Guid id, PersonalCabinetUpdateDTO updateDto, CancellationToken cancellationToken = default);
    Task<CreatePersonalCabinetResponseDTO> CreateAsync(PersonalCabinetCreateDTO createDto, CancellationToken cancellationToken = default);
    Task<List<PersonalCabinetResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
}

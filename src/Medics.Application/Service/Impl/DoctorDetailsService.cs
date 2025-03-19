using AutoMapper;
using Medics.Application.DtoModels.DoctorDetails;
using Medics.Application.DtoModels;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class DoctorDetailsService : IDoctorDetailsService
{
    private readonly IMapper _mapper;
    private readonly IDoctorDetailsRepository _repository;

    public DoctorDetailsService(IDoctorDetailsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<DoctorDetailsResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync();
        return _mapper.Map<List<DoctorDetailsResponseDTO>>(result);
    }

    public async Task<DoctorDetailsResponseDTO> CreateAsync(DoctorDetailsCreateDTO createModel, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<DoctorDetails>(createModel);
        var created = await _repository.AddAsync(entity);
        return new DoctorDetailsResponseDTO { Id = created.Id };
    }

    public async Task<DoctorDetailsResponseDTO> UpdateAsync(Guid id, DoctorDetailsUpdateDTO updateModel, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) throw new Exception("Doctor details not found.");

        _mapper.Map(updateModel, entity);
        var updated = await _repository.UpdateAsync(entity);
        return new DoctorDetailsResponseDTO { Id = updated.Id };
    }

    public async Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return new BaseResponseDTO { Id = id, Success = false, Message = "Doctor details not found" };
        }

        await _repository.DeleteAsync(entity);
        return new BaseResponseDTO { Id = id, Success = true, Message = "Doctor details deleted successfully" };
    }
}
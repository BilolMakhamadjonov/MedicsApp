using AutoMapper;
using Medics.Application.DtoModels.Geolocation;
using Medics.Application.DtoModels;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class GeolocationService : IGeolocationService
{
    private readonly IMapper _mapper;
    private readonly IGeolocationRepository _repository;

    public GeolocationService(IGeolocationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GeolocationResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAllAsync();
        return _mapper.Map<List<GeolocationResponseDTO>>(result);
    }

    public async Task<CreateGeolocationResponseDTO> CreateAsync(GeolocationCreateDTO createModel, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Geolocation>(createModel);
        var created = await _repository.AddAsync(entity);
        return new CreateGeolocationResponseDTO { Id = created.Id };
    }

    public async Task<UpdateGeolocationResponseDTO> UpdateAsync(Guid id, GeolocationUpdateDTO updateModel, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) throw new Exception("Geolocation not found.");

        _mapper.Map(updateModel, entity);
        var updated = await _repository.UpdateAsync(entity);
        return new UpdateGeolocationResponseDTO { Id = updated.Id };
    }

    public async Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return new BaseResponseDTO { Id = id, Success = false, Message = "Geolocation not found" };
        }

        await _repository.DeleteAsync(entity);
        return new BaseResponseDTO { Id = id, Success = true, Message = "Geolocation deleted successfully" };
    }
}
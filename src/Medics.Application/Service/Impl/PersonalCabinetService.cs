using AutoMapper;
using Medics.Application.DtoModels.PersonalCabinet;
using Medics.Application.DtoModels;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class PersonalCabinetService : IPersonalCabinetService
{
    private readonly IPersonalCabinetRepository _repository;
    private readonly IMapper _mapper;

    public PersonalCabinetService(IPersonalCabinetRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<PersonalCabinetResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<List<PersonalCabinetResponseDTO>>(entities);
    }

    public async Task<CreatePersonalCabinetResponseDTO> CreateAsync(PersonalCabinetCreateDTO createDto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<PersonalCabinet>(createDto);
        await _repository.AddAsync(entity);
        return new CreatePersonalCabinetResponseDTO { Id = entity.Id };
    }

    public async Task<UpdatePersonalCabinetResponseDTO> UpdateAsync(Guid id, PersonalCabinetUpdateDTO updateDto, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) throw new Exception("Personal Cabinet not found.");

        _mapper.Map(updateDto, entity);
        await _repository.UpdateAsync(entity);

        return new UpdatePersonalCabinetResponseDTO { Id = entity.Id };
    }

    public async Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return new BaseResponseDTO { Id = id, Success = false, Message = "Not found" };

        await _repository.DeleteAsync(entity);
        return new BaseResponseDTO { Id = id, Success = true, Message = "Deleted successfully" };
    }
}
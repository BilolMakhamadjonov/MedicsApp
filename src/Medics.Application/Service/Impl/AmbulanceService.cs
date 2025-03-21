using AutoMapper;
using Medics.Application.DtoModels.Ambulance;
using Medics.Application.DtoModels;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class AmbulanceService : IAmbulanceService
{
    private readonly IMapper _mapper;
    private readonly IAmbulanceRepository _ambulanceRepository;

    public AmbulanceService(IAmbulanceRepository ambulanceRepository, IMapper mapper)
    {
        _ambulanceRepository = ambulanceRepository;
        _mapper = mapper;
    }

    public async Task<List<AmbulanceResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var ambulances = await _ambulanceRepository.GetAllAsync();
        return _mapper.Map<List<AmbulanceResponseDTO>>(ambulances);
    }

    public async Task<AmbulanceResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ambulance = await _ambulanceRepository.GetByIdAsync(id);
        return ambulance == null ? null : _mapper.Map<AmbulanceResponseDTO>(ambulance);
    }

    public async Task<CreateAmbulanceResponseDTO> CreateAsync(AmbulanceCreateDTO model, CancellationToken cancellationToken = default)
    {
        var ambulance = _mapper.Map<Ambulance>(model);
        await _ambulanceRepository.AddAsync(ambulance);
        return new CreateAmbulanceResponseDTO { Id = ambulance.Id };
    }

    public async Task<UpdateAmbulanceResponseDTO> UpdateAsync(Guid id, AmbulanceUpdateDTO model, CancellationToken cancellationToken = default)
    {
        var ambulance = await _ambulanceRepository.GetByIdAsync(id);
        if (ambulance == null) throw new Exception("Ambulance not found.");

        _mapper.Map(model, ambulance);
        await _ambulanceRepository.UpdateAsync(ambulance);
        return new UpdateAmbulanceResponseDTO { Id = ambulance.Id };
    }

    public async Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ambulance = await _ambulanceRepository.GetByIdAsync(id);
        if (ambulance == null) return new BaseResponseDTO { Id = id, Success = false, Message = "Ambulance not found" };

        await _ambulanceRepository.DeleteAsync(ambulance);
        return new BaseResponseDTO { Id = id, Success = true, Message = "Ambulance deleted successfully" };
    }
}
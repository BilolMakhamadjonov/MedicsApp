using AutoMapper;
using Medics.Application.DtoModels.PharmacyDetails;
using Medics.Application.DtoModels;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class PharmacyDetailsService : IPharmacyDetailsService
{
    private readonly IMapper _mapper;
    private readonly IPharmacyDetailsRepository _pharmacyDetailsRepository;

    public PharmacyDetailsService(IPharmacyDetailsRepository pharmacyDetailsRepository, IMapper mapper)
    {
        _pharmacyDetailsRepository = pharmacyDetailsRepository;
        _mapper = mapper;
    }

    public async Task<List<PharmacyDetailsResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var details = await _pharmacyDetailsRepository.GetAllAsync();
        return _mapper.Map<List<PharmacyDetailsResponseDTO>>(details);
    }

    public async Task<PharmacyDetailsResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var details = await _pharmacyDetailsRepository.GetByIdAsync(id);
        return details == null ? null : _mapper.Map<PharmacyDetailsResponseDTO>(details);
    }

    public async Task<CreatePharmacyDetailsResponseDTO> CreateAsync(PharmacyDetailsCreateDTO model, CancellationToken cancellationToken = default)
    {
        var details = _mapper.Map<PharmacyDetails>(model);
        await _pharmacyDetailsRepository.AddAsync(details);
        return new CreatePharmacyDetailsResponseDTO { Id = details.Id };
    }

    public async Task<UpdatePharmacyDetailsResponseDTO> UpdateAsync(Guid id, PharmacyDetailsUpdateDTO model, CancellationToken cancellationToken = default)
    {
        var details = await _pharmacyDetailsRepository.GetByIdAsync(id);
        if (details == null) throw new Exception("Pharmacy details not found.");

        _mapper.Map(model, details);
        await _pharmacyDetailsRepository.UpdateAsync(details);
        return new UpdatePharmacyDetailsResponseDTO { Id = details.Id };
    }

    public async Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var details = await _pharmacyDetailsRepository.GetByIdAsync(id);
        if (details == null) return new BaseResponseDTO { Id = id, Success = false, Message = "Pharmacy details not found" };

        await _pharmacyDetailsRepository.DeleteAsync(details);
        return new BaseResponseDTO { Id = id, Success = true, Message = "Pharmacy details deleted successfully" };
    }
}
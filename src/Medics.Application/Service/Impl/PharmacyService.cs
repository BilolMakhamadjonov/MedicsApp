using AutoMapper;
using Medics.Application.DtoModels;
using Medics.Application.DtoModels.Pharmacy;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class PharmacyService : IPharmacyService
{
    private readonly IMapper _mapper;
    private readonly IPharmacyRepository _pharmacyRepository;

    public PharmacyService(IPharmacyRepository pharmacyRepository, IMapper mapper)
    {
        _pharmacyRepository = pharmacyRepository;
        _mapper = mapper;
    }



    public async Task<List<PharmacyResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _pharmacyRepository.GetAllAsync();
        return _mapper.Map<List<PharmacyResponseDTO>>(result);
    }

    public async Task<CreatePharmacyResponseDTO> CreateAsync(PharmacyCreateDTO createPharmacyModel, CancellationToken cancellationToken = default)
    {
        var pharmacy = _mapper.Map<Pharmacy>(createPharmacyModel);
        return new CreatePharmacyResponseDTO
        {
            Id = (await _pharmacyRepository.AddAsync(pharmacy)) .Id
        };
    }

    public async Task<UpdatePharmacyResponseDTO> UpdateAsync(Guid id, PharmacyUpdateDTO updatePharmacyModel, CancellationToken cancellationToken = default)
    {
        var pharmacy = await _pharmacyRepository.GetByIdAsync(id);
        if (pharmacy == null) throw new Exception("Pharmacy not found.");

        _mapper.Map(updatePharmacyModel, pharmacy);

        return new UpdatePharmacyResponseDTO
        {
            Id = (await _pharmacyRepository.UpdateAsync(pharmacy)).Id
        };
    }

    //public async Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    //{
    //    bool success = await _pharmacyRepository.DeleteAsync(Guid id);
    //    return new BaseResponseDTO
    //    {
    //        Id = id,
    //        Success = success
    //    };
    //}
    public async Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var todoItem = await _pharmacyRepository.GetFirstAsync(ti => ti.Id == id);

        return new BaseResponseDTO
        {
            Id = (await _pharmacyRepository.DeleteAsync(todoItem)).Id
        };
    }
}

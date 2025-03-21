using AutoMapper;
using Medics.Application.DtoModels.Pharmacy;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl
{
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
            var pharmacies = await _pharmacyRepository.GetAllAsync();
            return _mapper.Map<List<PharmacyResponseDTO>>(pharmacies);
        }

        public async Task<PharmacyResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var pharmacy = await _pharmacyRepository.GetByIdAsync(id);
            if (pharmacy == null) throw new Exception("Pharmacy not found.");
            return _mapper.Map<PharmacyResponseDTO>(pharmacy);
        }

        public async Task<CreatePharmacyResponseDTO> CreateAsync(PharmacyCreateDTO model, CancellationToken cancellationToken = default)
        {
            var pharmacy = _mapper.Map<Pharmacy>(model);
            await _pharmacyRepository.AddAsync(pharmacy);
            return _mapper.Map<CreatePharmacyResponseDTO>(pharmacy);
        }

        public async Task<UpdatePharmacyResponseDTO> UpdateAsync(Guid id, PharmacyUpdateDTO model, CancellationToken cancellationToken = default)
        {
            var pharmacy = await _pharmacyRepository.GetByIdAsync(id);
            if (pharmacy == null) throw new Exception("Pharmacy not found.");

            _mapper.Map(model, pharmacy);
            await _pharmacyRepository.UpdateAsync(pharmacy);
            return _mapper.Map<UpdatePharmacyResponseDTO>(pharmacy);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var pharmacy = await _pharmacyRepository.GetByIdAsync(id);
            if (pharmacy == null) return false;

            await _pharmacyRepository.DeleteAsync(pharmacy);
            return true;
        }
    }
}

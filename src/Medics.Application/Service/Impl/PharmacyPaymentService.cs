using AutoMapper;
using Medics.Application.DtoModels.PharmacyPayment;
using Medics.Application.DtoModels;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class PharmacyPaymentService : IPharmacyPaymentService
{
    private readonly IMapper _mapper;
    private readonly IPharmacyPaymentRepository _pharmacyPaymentRepository;

    public PharmacyPaymentService(IPharmacyPaymentRepository pharmacyPaymentRepository, IMapper mapper)
    {
        _pharmacyPaymentRepository = pharmacyPaymentRepository;
        _mapper = mapper;
    }

    public async Task<List<PharmacyPaymentResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var payments = await _pharmacyPaymentRepository.GetAllAsync();
        return _mapper.Map<List<PharmacyPaymentResponseDTO>>(payments);
    }

    public async Task<PharmacyPaymentResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var payment = await _pharmacyPaymentRepository.GetByIdAsync(id);
        return payment == null ? null : _mapper.Map<PharmacyPaymentResponseDTO>(payment);
    }

    public async Task<CreatePharmacyPaymentResponseDTO> CreateAsync(PharmacyPaymentCreateDTO model, CancellationToken cancellationToken = default)
    {
        var payment = _mapper.Map<PharmacyPayment>(model);
        await _pharmacyPaymentRepository.AddAsync(payment);
        return new CreatePharmacyPaymentResponseDTO { Id = payment.Id };
    }

    public async Task<UpdatePharmacyPaymentResponseDTO> UpdateAsync(Guid id, PharmacyPaymentUpdateDTO model, CancellationToken cancellationToken = default)
    {
        var payment = await _pharmacyPaymentRepository.GetByIdAsync(id);
        if (payment == null) throw new Exception("Pharmacy payment not found.");

        _mapper.Map(model, payment);
        await _pharmacyPaymentRepository.UpdateAsync(payment);
        return new UpdatePharmacyPaymentResponseDTO { Id = payment.Id };
    }

    public async Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var payment = await _pharmacyPaymentRepository.GetByIdAsync(id);
        if (payment == null) return new BaseResponseDTO { Id = id, Success = false, Message = "Pharmacy payment not found" };

        await _pharmacyPaymentRepository.DeleteAsync(payment);
        return new BaseResponseDTO { Id = id, Success = true, Message = "Pharmacy payment deleted successfully" };
    }
}
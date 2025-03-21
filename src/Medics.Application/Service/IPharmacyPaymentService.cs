using Medics.Application.DtoModels;
using Medics.Application.DtoModels.PharmacyPayment;

namespace Medics.Application.Service;

public interface IPharmacyPaymentService
{
    Task<List<PharmacyPaymentResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PharmacyPaymentResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CreatePharmacyPaymentResponseDTO> CreateAsync(PharmacyPaymentCreateDTO model, CancellationToken cancellationToken = default);
    Task<UpdatePharmacyPaymentResponseDTO> UpdateAsync(Guid id, PharmacyPaymentUpdateDTO model, CancellationToken cancellationToken = default);
    Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

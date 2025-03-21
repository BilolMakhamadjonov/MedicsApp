using Medics.Application.DtoModels;
using Medics.Application.DtoModels.AppointmentPayment;

namespace Medics.Application.Service;

public interface IAppointmentPaymentService
{
    Task<List<AppointmentPaymentResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<AppointmentPaymentResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CreateAppointmentPaymentResponseDTO> CreateAsync(AppointmentPaymentCreateDTO model, CancellationToken cancellationToken = default);
    Task<UpdateAppointmentPaymentResponseDTO> UpdateAsync(Guid id, AppointmentPaymentUpdateDTO model, CancellationToken cancellationToken = default);
    Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

using AutoMapper;
using Medics.Application.DtoModels;
using Medics.Application.DtoModels.AppointmentPayment;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class AppointmentPaymentService : IAppointmentPaymentService
{
    private readonly IMapper _mapper;
    private readonly IAppointmentPaymentRepo _appointmentPaymentRepository;

    public AppointmentPaymentService(IAppointmentPaymentRepo appointmentPaymentRepository, IMapper mapper)
    {
        _appointmentPaymentRepository = appointmentPaymentRepository;
        _mapper = mapper;
    }

    public async Task<List<AppointmentPaymentResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var payments = await _appointmentPaymentRepository.GetAllAsync();
        return _mapper.Map<List<AppointmentPaymentResponseDTO>>(payments);
    }

    public async Task<AppointmentPaymentResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var payment = await _appointmentPaymentRepository.GetByIdAsync(id);
        return payment == null ? null : _mapper.Map<AppointmentPaymentResponseDTO>(payment);
    }

    public async Task<CreateAppointmentPaymentResponseDTO> CreateAsync(AppointmentPaymentCreateDTO model, CancellationToken cancellationToken = default)
    {
        var payment = _mapper.Map<AppointmentPayment>(model);
        await _appointmentPaymentRepository.AddAsync(payment);
        return new CreateAppointmentPaymentResponseDTO { Id = payment.Id };
    }

    public async Task<UpdateAppointmentPaymentResponseDTO> UpdateAsync(Guid id, AppointmentPaymentUpdateDTO model, CancellationToken cancellationToken = default)
    {
        var payment = await _appointmentPaymentRepository.GetByIdAsync(id);
        if (payment == null) throw new Exception("Appointment payment not found.");

        _mapper.Map(model, payment);
        await _appointmentPaymentRepository.UpdateAsync(payment);
        return new UpdateAppointmentPaymentResponseDTO { Id = payment.Id };
    }

    public async Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var payment = await _appointmentPaymentRepository.GetByIdAsync(id);
        if (payment == null) return new BaseResponseDTO { Id = id, Success = false, Message = "Appointment payment not found" };

        await _appointmentPaymentRepository.DeleteAsync(payment);
        return new BaseResponseDTO { Id = id, Success = true, Message = "Appointment payment deleted successfully" };
    }
}

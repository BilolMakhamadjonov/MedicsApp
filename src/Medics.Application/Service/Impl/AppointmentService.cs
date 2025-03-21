using AutoMapper;
using Medics.Application.DtoModels.Appointment;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _repository;
    private readonly IMapper _mapper;

    public AppointmentService(IAppointmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<AppointmentResponseDTO>> GetAllAppointmentsAsync()
    {
        var appointments = await _repository.GetAllAsync();
        return _mapper.Map<List<AppointmentResponseDTO>>(appointments);
    }

    public async Task<AppointmentResponseDTO> GetAppointmentByIdAsync(Guid id)
    {
        var appointment = await _repository.GetByIdAsync(id);
        if (appointment == null) throw new Exception("Appointment not found");
        return _mapper.Map<AppointmentResponseDTO>(appointment);
    }

    public async Task<CreateAppointmentResponseDTO> CreateAppointmentAsync(AppointmentCreateDTO dto)
    {
        var appointment = _mapper.Map<Appointment>(dto);
        await _repository.AddAsync(appointment);
        return _mapper.Map<CreateAppointmentResponseDTO>(appointment);
    }

    public async Task<UpdateAppointmentResponseDTO> UpdateAppointmentAsync(Guid id, AppointmentUpdateDTO dto)
    {
        var appointment = await _repository.GetByIdAsync(id);
        if (appointment == null) throw new Exception("Appointment not found");

        _mapper.Map(dto, appointment);
        await _repository.UpdateAsync(appointment);
        return _mapper.Map<UpdateAppointmentResponseDTO>(appointment);
    }

    public async Task<bool> DeleteAppointmentAsync(Guid id)
    {
        var appointment = await _repository.GetByIdAsync(id);
        if (appointment == null) throw new Exception("Appointment not found");

        await _repository.DeleteAsync(appointment);
        return true;
    }
}
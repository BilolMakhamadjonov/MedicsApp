using Medics.Application.DtoModels.Appointment;

namespace Medics.Application.Service;

public interface IAppointmentService
{
    Task<List<AppointmentResponseDTO>> GetAllAppointmentsAsync();
    Task<AppointmentResponseDTO> GetAppointmentByIdAsync(Guid id);
    Task<AppointmentResponseDTO> CreateAppointmentAsync(AppointmentCreateDTO dto);
    Task<AppointmentResponseDTO> UpdateAppointmentAsync(Guid id, AppointmentUpdateDTO dto);
    Task<bool> DeleteAppointmentAsync(Guid id);
}
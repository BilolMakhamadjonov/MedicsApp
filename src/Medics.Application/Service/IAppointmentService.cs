using Medics.Application.DtoModels.Appointment;

namespace Medics.Application.Service;

public interface IAppointmentService
{
    Task<List<AppointmentResponseDTO>> GetAllAppointmentsAsync();
    Task<AppointmentResponseDTO> GetAppointmentByIdAsync(Guid id);
    Task<CreateAppointmentResponseDTO> CreateAppointmentAsync(AppointmentCreateDTO dto);
    Task<UpdateAppointmentResponseDTO> UpdateAppointmentAsync(Guid id, AppointmentUpdateDTO dto);
    Task<bool> DeleteAppointmentAsync(Guid id);
}
﻿namespace Medics.Application.DtoModels.Appointment;

public class AppointmentResponseDTO
{
    public Guid Id { get; set; }
    public DateTime BookingDate { get; set; }
    public string Reason { get; set; }
    public Guid UserId { get; set; }
    public Guid DoctorId { get; set; }
}

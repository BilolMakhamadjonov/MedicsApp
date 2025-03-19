namespace Medics.Application.DtoModels.Doctor;


public class DoctorResponseDTO
{
    public Guid Id { get; set; }
    public Guid DoctorCategoryId { get; set; }
    public string DoctorCategoryName { get; set; } = string.Empty; // Mutaxassislik nomi
    public Guid UserId { get; set; }
}

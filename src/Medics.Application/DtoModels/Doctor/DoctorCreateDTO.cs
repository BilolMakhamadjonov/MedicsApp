namespace Medics.Application.DtoModels.Doctor;

public class DoctorCreateDTO
{
    public Guid DoctorCategoryId { get; set; }
    public Guid UserId { get; set; }
}

public class CreateDoctorResponseDTO : BaseResponseDTO { }

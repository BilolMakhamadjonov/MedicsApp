namespace Medics.Application.DtoModels.DoctorDetails;

public class DoctorDetailsUpdateDTO
{
    public string? UserName { get; set; }
    public string? AvarageStars { get; set; }
    public string? About { get; set; }
    public DateTime? StartWorking { get; set; }
    public DateTime? EndWorking { get; set; }
}

public class UpdateDoctorDetailsResponseDTO : BaseResponseDTO { }

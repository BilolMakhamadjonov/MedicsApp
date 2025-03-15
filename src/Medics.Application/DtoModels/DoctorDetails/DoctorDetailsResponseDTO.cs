namespace Medics.Application.DtoModels.DoctorDetails;

public class DoctorDetailsResponseDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string AvarageStars { get; set; }
    public string About { get; set; }
    public DateTime StartWorking { get; set; }
    public DateTime EndWorking { get; set; }
    public Guid ChatId { get; set; }
}
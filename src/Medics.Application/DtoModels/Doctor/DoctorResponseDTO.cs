namespace Medics.Application.DtoModels.Doctor;


public class DoctorResponseDTO
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Category { get; set; }
    public double AverageStars { get; set; } = 4.7;
    public string Distance { get; set; } = "800m";
}

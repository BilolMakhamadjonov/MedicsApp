namespace Medics.Application.DtoModels.PharmacyDetails;

public class PharmacyDetailsUpdateDTO
{
    public int? DrugCount { get; set; }
    public string? Description { get; set; }
    public double? TotalPrice { get; set; }
}

public class UpdatePharmacyDetailsResponseDTO : BaseResponseDTO { }

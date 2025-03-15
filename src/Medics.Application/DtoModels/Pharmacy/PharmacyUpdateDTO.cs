namespace Medics.Application.DtoModels.Pharmacy;

public class PharmacyUpdateDTO
{
    public string? DrugName { get; set; }
    public decimal? Price { get; set; }
    public string? Volume { get; set; }
}

public class UpdatePharmacyResponseDTO : BaseResponseDTO { }
namespace Medics.Application.DtoModels.Pharmacy;


public class PharmacyCreateDTO
{
    public string DrugName { get; set; }
    public decimal Price { get; set; }
    public string Volume { get; set; }
}

public class CreatePharmacyResponseDTO : BaseResponseDTO { }
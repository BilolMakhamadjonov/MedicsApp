namespace Medics.Application.DtoModels.Pharmacy;

public class PharmacyResponseDTO
{
    public Guid Id { get; set; }
    public string DrugName { get; set; }
    public decimal Price { get; set; }
    public string Volume { get; set; }
}

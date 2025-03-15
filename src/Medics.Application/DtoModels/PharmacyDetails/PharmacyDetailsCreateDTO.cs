namespace Medics.Application.DtoModels.PharmacyDetails;

public class PharmacyDetailsCreateDTO
{
    public int DrugCount { get; set; }
    public Guid PharmacyId { get; set; }
    public string Description { get; set; }
    public double TotalPrice { get; set; }
    public Guid CartId { get; set; }
}

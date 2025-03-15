using Medics.Core.Comman;

namespace Medics.Core.Entities;

public class PharmacyDetails : BaseEntity
{
    public int DrugCount { get; set; }
    public Pharmacy Pharmacy { get; set; }
    public Guid PharmacyId { get; set; }
    public string Description { get; set; }
    public double TotalPrice { get; set; }
    public Cart Cart { get; set; }
    public Guid CartId { get; set; }
}

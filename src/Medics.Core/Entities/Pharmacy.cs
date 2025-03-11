using Medics.Core.Abstraction;

namespace Medics.Core.Entities;

public class Pharmacy : BaseEntity
{
    public string DrugName { get; set; }
    public decimal Price { get; set; }
    public string Volume { get; set; } // hajmi dorini
    public ICollection<PharmacyDetails> PharmacyDetails { get; set; }
}

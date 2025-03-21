using Medics.Core.Entities.Enum;

namespace Medics.Application.DtoModels.PersonalCabinet;


public class PersonalCabinetUpdateDTO
{
    public long? MySaved { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
}

public class UpdatePersonalCabinetResponseDTO : BaseResponseDTO { }

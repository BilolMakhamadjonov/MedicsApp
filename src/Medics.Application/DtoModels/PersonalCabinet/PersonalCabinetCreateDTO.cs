using Medics.Core.Entities.Enum;

namespace Medics.Application.DtoModels.PersonalCabinet;

public class PersonalCabinetCreateDTO
{
    public long MySaved { get; set; }
    public Guid AppointmentId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public Guid UserId { get; set; }
}

public class CreatePersonalCabinetResponseDTO : BaseResponseDTO { }

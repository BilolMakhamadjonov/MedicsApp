using Medics.Core.Entities.Enum;

namespace Medics.Application.DtoModels.PersonalCabinet;

public class PersonalCabinetResponseDTO
{
    public Guid Id { get; set; }
    public long MySaved { get; set; }
    public Guid AppointmentId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public Guid UserId { get; set; }
}
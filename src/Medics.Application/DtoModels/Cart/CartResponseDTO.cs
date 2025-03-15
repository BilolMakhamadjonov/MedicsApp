namespace Medics.Application.DtoModels.Cart;

public class CartResponseDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public decimal Total { get; set; }
    public Guid PharmacyPaymentId { get; set; }
}

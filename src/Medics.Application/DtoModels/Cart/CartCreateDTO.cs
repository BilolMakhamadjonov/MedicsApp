namespace Medics.Application.DtoModels.Cart;

public class CartCreateDTO
{
    public Guid UserId { get; set; }
    public decimal Total { get; set; }
    public Guid PharmacyPaymentId { get; set; }
}
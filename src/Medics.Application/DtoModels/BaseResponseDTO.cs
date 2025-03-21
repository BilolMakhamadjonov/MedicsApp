namespace Medics.Application.DtoModels;

public class BaseResponseDTO
{
    public Guid Id { get; set; }

    /// <summary>
    /// /////
    /// </summary>
    public bool Success { get; set; } // Operatsiyaning muvaffaqiyatli bajarilganligini bildiradi
    public string? Message { get; set; } // Qo'shimcha xabar (xato yoki muvaffaqiyat)

    public static implicit operator bool(BaseResponseDTO response) => response.Success;
    //public static implicit operator bool(BaseResponseDTO v)
    //{
    //    throw new NotImplementedException();
    //}
}
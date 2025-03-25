namespace Medics.Core.Comman;

public record Error(string Code, string Message)
{
    public static readonly Error None = new Error("No error", "xato yoq");

    public static Error NullValue = new("Error.NullValue", "Kerakli qiymat kiritilmadi.");
    public static Error DatabaseError = new("Error.DatabaseError", "Ma'lumotlar bazasida xatolik yuz berdi.");
    public static Error BadRequest = new("Error.BadRequest", "So‘rov noto‘g‘ri.");
    public static Error NotFound = new("Error.NotFound", "So‘ralgan ma'lumot topilmadi.");
    public static Error Unauthorized = new("Error.Unauthorized", "Foydalanuvchi avtorizatsiyadan o‘tmagan.");
    public static Error Forbidden = new("Error.Forbidden", "Ushbu amalni bajarish taqiqlangan.");
    public static Error Conflict = new("Error.Conflict", "Ma'lumotlar to‘qnashuvi yuz berdi.");
    public static Error InternalServerError = new("Error.InternalServerError", "Ichki server xatosi.");
    public static Error LoginFailed = new("Error.LoginFailed", "Email yoki parol noto‘g‘ri.");
    public static Error TechnicalWorks = new("Error.TechnicalWorks", "Hozirda texnik ishlar olib borilmoqda.");
    public static Error InvalidOperation = new("Error.InvalidOperation", "Bu amal bajarilishi mumkin emas.");
    public static Error TimeSlotOverlap = new("Error.TimeSlotOverlap", "Tanlangan vaqt boshqa uchrashuv bilan mos kelib qoldi.");
    public static Error ScheduleHasAppointments = new("Error.ScheduleHasAppointments", "Jadvalda allaqachon uchrashuvlar mavjud.");
    public static Error TimeSlotNotAvailable = new("Error.TimeSlotNotAvailable", "Tanlangan vaqt band.");

    // Tranzaksiya bilan bog‘liq xatoliklar
    public static Error TransactionNotFound = new("Error.TransactionNotFound", "Tranzaksiya topilmadi.");
    public static Error InvalidTransactionType = new("Error.InvalidTransactionType", "Tranzaksiya turi noto‘g‘ri.");
    public static Error TransactionFailed = new("Error.TransactionFailed", "Tranzaksiya amalga oshmadi.");
    public static Error DuplicateTransaction = new("Error.DuplicateTransaction", "Takroriy tranzaksiya aniqlandi.");
    public static Error TransactionTimeout = new("Error.TransactionTimeout", "Tranzaksiya vaqti tugadi.");
    public static Error InvalidTransactionStatus = new("Error.InvalidTransactionStatus", "Tranzaksiya holati noto‘g‘ri.");
    public static Error TransactionLimitExceeded = new("Error.TransactionLimitExceeded", "Tranzaksiya limiti oshib ketdi.");
    public static Error InvalidDateRange = new("Error.InvalidDateRange", "Berilgan sana oraliqlari noto‘g‘ri.");
    public static Error TransactionProcessing = new("Error.TransactionProcessing", "Tranzaksiya jarayonda.");
    public static Error InvalidTransactionId = new("Error.InvalidTransactionId", "Tranzaksiya ID noto‘g‘ri.");
    public static Error InvalidTransaction = new("Error.InvalidTransaction", "Noto‘g‘ri tranzaksiya.");
    public static Error InsufficientBalance = new("Error.InsufficientBalance", "Hisobda mablag‘ yetarli emas.");
    public static Error WithdrawalFailed = new("Error.WithdrawalFailed", "Pul yechish muvaffaqiyatsiz tugadi.");
    public static Error SameCardTransfer = new("Error.SameCardTransfer", "Bir kartadan o‘sha kartaga pul o‘tkazish mumkin emas.");
    public static Error InvalidInput = new("Error.InvalidInput", "Kiritilgan ma'lumotlar noto‘g‘ri.");
}
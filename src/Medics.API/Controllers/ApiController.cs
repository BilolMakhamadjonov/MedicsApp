using Microsoft.AspNetCore.Mvc;

namespace Medics.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiController : ControllerBase { }
///ApiController ga umumiy autentifikatsiya, loglash, yoki response formatini
///qo‘shilsa, barcha controllerlar avtomatik foydalanadi.
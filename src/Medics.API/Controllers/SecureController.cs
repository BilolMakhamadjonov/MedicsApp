using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medics.API.Controllers;

[Route("api/secure")]
[ApiController]
[Authorize] // 🔥 Faqat tokeni borlar kirishi mumkin
public class SecureController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSecureData()
    {
        return Ok(new { message = "Siz JWT token bilan muvaffaqiyatli kirishingiz mumkin!" });
    }
}
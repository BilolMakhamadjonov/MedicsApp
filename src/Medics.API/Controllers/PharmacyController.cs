using Medics.Application.DtoModels;
using Medics.Application.DtoModels.Pharmacy;
using Medics.Application.Service;
using Medics.Core.Comman;
using Microsoft.AspNetCore.Mvc;

namespace Medics.API.Controllers;

public class PharmacyController : ApiController
{
    private readonly IPharmacyService _pharmacyService;

    public PharmacyController(IPharmacyService pharmacyService)
    {
        _pharmacyService = pharmacyService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResult<List<PharmacyResponseDTO>>>> GetAll()
    {
        var result = await _pharmacyService.GetAllAsync();
        var response = ApiResult<List<PharmacyResponseDTO>>.Success(result);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(PharmacyCreateDTO createModel)
    {
        var result = await _pharmacyService.CreateAsync(createModel);

        if (result == null) return BadRequest(ApiResult<CreatePharmacyResponseDTO>.Failure(Error.NullValue));

        return Ok(ApiResult<CreatePharmacyResponseDTO>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, PharmacyUpdateDTO updateModel)
    {
        return Ok(ApiResult<UpdatePharmacyResponseDTO>.Success(
            await _pharmacyService.UpdateAsync(id, updateModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        bool isDeleted = await _pharmacyService.DeleteAsync(id);

        if (!isDeleted)
            return BadRequest(ApiResult<BaseResponseDTO>.Failure(new Error("DeleteFailed", "O‘chirish muvaffaqiyatsiz bo‘ldi")));

        return Ok(ApiResult<BaseResponseDTO>.Success(new BaseResponseDTO { Message = "O‘chirish muvaffaqiyatli amalga oshirildi!" }));
    }
}

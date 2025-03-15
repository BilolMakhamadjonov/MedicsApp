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

        if (result == null) return BadRequest(ApiResult<CreatePharmacyResponseDTO>.Failure());

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
        return Ok(ApiResult<BaseResponseDTO>.Success(await _pharmacyService.DeleteAsync(id)));
    }
}

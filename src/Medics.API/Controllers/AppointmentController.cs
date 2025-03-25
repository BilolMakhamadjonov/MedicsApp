using Medics.Application.DtoModels.Appointment;
using Medics.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Medics.API.Controllers;

public class AppointmentController : ApiController
{
    private readonly IAppointmentService _service;

    public AppointmentController(IAppointmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAppointmentsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetAppointmentByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AppointmentCreateDTO dto)
    {
        var result = await _service.CreateAppointmentAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] AppointmentUpdateDTO dto)
    {
        var result = await _service.UpdateAppointmentAsync(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAppointmentAsync(id);
        return NoContent();
    }
}

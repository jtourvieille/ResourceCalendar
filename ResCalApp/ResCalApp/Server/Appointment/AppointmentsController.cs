using Microsoft.AspNetCore.Mvc;

namespace ResCalApp.Server.Appointment;

using Shared.Models;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public Task<IEnumerable<Appointment>> GetAsync(string calendarId)
    {
        return _appointmentService.GetAsync(calendarId);
    }

    [HttpPost]
    public async Task AddAsync(Appointment appointment)
    {
        await _appointmentService.AddAsync(appointment);
    }

    [HttpPut]
    public async Task PutAsync(Appointment appointment)
    {
        await _appointmentService.EditAsync(appointment);
    }

    [HttpDelete]
    public async Task DeleteAsync(int appointmentId)
    {
        await _appointmentService.DeleteAsync(appointmentId);
    }
}
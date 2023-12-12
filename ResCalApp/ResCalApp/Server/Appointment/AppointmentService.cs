namespace ResCalApp.Server.Appointment;

using Data;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

public class AppointmentService : IAppointmentService
{
    private readonly AppointmentDbContext _appointmentDbContext;

    public AppointmentService(AppointmentDbContext appointmentDbContext)
    {
        _appointmentDbContext = appointmentDbContext;
    }

    public async Task<IEnumerable<Appointment>> GetAsync(string calendarId)
    {
        var appointments = await _appointmentDbContext.Appointments
            .Where(a => a.CalendarId == calendarId)
            .ToListAsync();
        
        appointments.ForEach(a=>
            {
                a.Start = TimeZoneInfo.ConvertTimeFromUtc(a.Start,
                        TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time"));

                a.End = TimeZoneInfo.ConvertTimeFromUtc(a.End,
                    TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time"));
            });

        return appointments;
    }

    public async Task AddAsync(Appointment appointment)
    {
        appointment.Start = TimeZoneInfo.ConvertTimeToUtc(appointment.Start);
        appointment.End = TimeZoneInfo.ConvertTimeToUtc(appointment.End);
        await _appointmentDbContext.Appointments.AddAsync(appointment);
        await _appointmentDbContext.SaveChangesAsync();
    }

    public async Task EditAsync(Appointment appointment)
    {
        appointment.Start = TimeZoneInfo.ConvertTimeToUtc(appointment.Start);
        appointment.End = TimeZoneInfo.ConvertTimeToUtc(appointment.End);

        var app = await _appointmentDbContext.Appointments.FirstAsync(a => a.Id == appointment.Id);

        app.End = appointment.End;
        app.Start = appointment.Start;
        app.Text = appointment.Text;
        
        await _appointmentDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int appointmentId)
    {
        var app = await _appointmentDbContext.Appointments.FirstAsync(a => a.Id == appointmentId);
        _appointmentDbContext.Appointments.Remove(app);
        await _appointmentDbContext.SaveChangesAsync();
    }
}
namespace ResCalApp.Server.Appointment;

using Shared.Models;

public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> GetAsync(string calendarId);

    Task AddAsync(Appointment appointment);

    Task EditAsync(Appointment appointment);

    Task DeleteAsync(int appointmentId);
}
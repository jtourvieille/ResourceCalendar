namespace ResCalApp.Server.Appointment;

using Shared.Models;

public class AppointmentService : IAppointmentService
{
    public async Task<IEnumerable<Appointment>> GetAsync(string calendarId)
    {
        await Task.Yield();

        return new List<Appointment>
        {
            new Appointment { Id = 1, CalendarId = "A5D9C74B-DAFF-42E7-8BE5-4385DCA11F50", Start = DateTime.Today.AddDays(-2), End = DateTime.Today.AddDays(-2), Text = "Birthday" },
            new Appointment { Id = 2, CalendarId = "A5D9C74B-DAFF-42E7-8BE5-4385DCA11F51", Start = DateTime.Today.AddDays(-11), End = DateTime.Today.AddDays(-10), Text = "Day off" },
            new Appointment { Id = 3, CalendarId = "A5D9C74B-DAFF-42E7-8BE5-4385DCA11F52", Start = DateTime.Today.AddDays(-10), End = DateTime.Today.AddDays(-8), Text = "Work from home" },
            new Appointment { Id = 4, CalendarId = "A5D9C74B-DAFF-42E7-8BE5-4385DCA11F53", Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(12), Text = "Online meeting" },
            new Appointment { Id = 5, CalendarId = "A5D9C74B-DAFF-42E7-8BE5-4385DCA11F54", Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(13), Text = "Skype call" },
            new Appointment { Id = 6, CalendarId = "A5D9C74B-DAFF-42E7-8BE5-4385DCA11F55", Start = DateTime.Today.AddHours(14), End = DateTime.Today.AddHours(14).AddMinutes(30), Text = "Dentist appointment" },
            new Appointment { Id = 7, CalendarId = "A5D9C74B-DAFF-42E7-8BE5-4385DCA11F56", Start = DateTime.Today.AddDays(1), End = DateTime.Today.AddDays(12), Text = "Vacation" },
        };
    }

    public Task AddAsync(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public Task EditAsync(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int appointmentId)
    {
        throw new NotImplementedException();
    }
}
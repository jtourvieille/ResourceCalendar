namespace ResCalApp.Shared.Models;

public class Appointment
{
    public int Id { get; set; }
    public string CalendarId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Text { get; set; }
}
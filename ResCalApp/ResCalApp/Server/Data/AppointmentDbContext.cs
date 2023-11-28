using Microsoft.EntityFrameworkCore;

namespace ResCalApp.Server.Data;

using Shared.Models;

public class AppointmentDbContext : DbContext
{
    public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
    {
    }

    public DbSet<Appointment> Appointments { get; set; }
}
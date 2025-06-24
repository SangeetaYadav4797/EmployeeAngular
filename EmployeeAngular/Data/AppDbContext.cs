
using EmployeeAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAngular.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}

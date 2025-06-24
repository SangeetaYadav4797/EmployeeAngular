using EmployeeAngular.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("stats")]
        public ActionResult<DashboardStats> GetStats()
        {
            var today = DateTime.Today;

            var stats = new DashboardStats
            {
                TotalDoctors = _context.Doctors.Count(),
                TotalPatients = _context.Patients.Count(),
                AppointmentsToday = _context.Appointments
                    .Count(a => a.AppointmentDate.Date == today)
            };

            return Ok(stats);
        }
    }
}

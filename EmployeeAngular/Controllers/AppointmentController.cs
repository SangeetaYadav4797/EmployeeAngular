using EmployeeAngular.Data;
using EmployeeAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppointmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Appointments.ToList());

        [HttpPost]
        public IActionResult Add([FromBody] Appointment appt)
        {
            _context.Appointments.Add(appt);
            _context.SaveChanges();
            return Ok(appt);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Appointment appt)
        {
            var existing = _context.Appointments.Find(id);
            if (existing == null) return NotFound();

            existing.PatientName = appt.PatientName;
            existing.DoctorName = appt.DoctorName;
            existing.AppointmentDate = appt.AppointmentDate;
            existing.Reason = appt.Reason;
            existing.Status = appt.Status;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.Appointments.Find(id);
            if (existing == null) return NotFound();

            _context.Appointments.Remove(existing);
            _context.SaveChanges();
            return Ok();
        }
    }
}


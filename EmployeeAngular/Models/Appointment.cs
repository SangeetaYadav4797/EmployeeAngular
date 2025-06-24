using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAngular.Models
{
    [Table("Appointments")]
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; } = "Scheduled";
    }
}

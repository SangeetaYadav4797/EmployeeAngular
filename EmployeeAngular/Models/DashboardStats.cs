using Microsoft.EntityFrameworkCore;

[Keyless]
public class DashboardStats
{
    public int TotalDoctors { get; set; }
    public int TotalPatients { get; set; }
    public int AppointmentsToday { get; set; }
}

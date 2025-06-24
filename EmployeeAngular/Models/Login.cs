using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeAngular.Models

{
    [Table("Login")]
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

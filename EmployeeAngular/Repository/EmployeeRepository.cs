using EmployeeAngular.Data;

using Microsoft.EntityFrameworkCore;

namespace EmployeeAngular.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext db;
        public EmployeeRepository(AppDbContext dbContext) 
        {
        this.db = dbContext;
        }
        public async Task<List<Employees>> GetAllEmployees()
        {
            return await db.Employees.ToListAsync();

        }
        //public async Task SaveEmployee(Employees emp)
        //{
        //    await db.Employees.AddAsync(emp);
        //    await db.SaveChangesAsync();
        //}
        public async Task SaveEmployee(Employees emp)
        {
            if (emp.Id == 0)
            {
                db.Employees.Add(emp);
            }
            else
            {
               db.Employees.Update(emp);
            }
            await db.SaveChangesAsync();
        }

        public async Task updateEmployee(int id, Employees obj)
        {
            var employee = await db.Employees.FindAsync(id);
            if(employee==null)
            {
                throw new Exception("Employee not Found");
            }
            employee.Name = obj.Name;
            employee.Email = obj.Email;
            employee.Mobile = obj.Mobile;
            employee.Age = obj.Age;
            employee.Salary = obj.Salary;
            employee.Status = obj.Status;

            await db.SaveChangesAsync();
        }
        public async Task deleteEmployee(int id)
        {
            var employee = await db.Employees.FindAsync(id);
            if(employee==null)
            {
                throw new Exception("Employee  Found");
            }
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
        }

    }
}

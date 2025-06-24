
using EmployeeAngular.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository emp;
        public EmployeeController(EmployeeRepository employeeRepository) 
        {
        this.emp = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> EmployeeList()
        {
            var allEmployee = await emp.GetAllEmployees();
            return Ok(allEmployee);
        }
        //[HttpPost]
        //public async Task<ActionResult> AddEmployee(Employee vm)
        //{
        //    await  emp.SaveEmployee(vm); 
        //        { 
        //   return Ok(vm);

        //    }
        //}
        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employees vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await emp.SaveEmployee(vm);
            return Ok(vm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updateEmployee(int id, [FromBody]Employees vm)
        {
            await emp.updateEmployee(id, vm);
            return Ok(vm);
        }
        [HttpDelete ("{id}")]
        public async Task<ActionResult>deleteEmployee(int id)
        {
            await emp.deleteEmployee(id);
            return Ok();
        }
    }
}

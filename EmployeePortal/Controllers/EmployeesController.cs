using EmployeePortal.Data;
using EmployeePortal.Models;
using EmployeePortal.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    public class EmployeesController : Controller
    {
        public readonly MVCDemoDbContext mvcDemoDbContext;
        public EmployeesController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext=mvcDemoDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Department = addEmployeeRequest.Department


            };
            await mvcDemoDbContext.Employees.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
    }
}

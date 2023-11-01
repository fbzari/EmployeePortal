using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    public class EmployeesController1 : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}

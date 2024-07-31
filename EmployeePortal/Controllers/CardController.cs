using EmployeePortal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Controllers
{
    [Route("Card")]
    public class CardController : Controller
    {
        public readonly MVCDemoDbContext mvcDemoDbContext;
        public CardController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        [Route("Show")]
        public async Task<ActionResult> cards()
        {
            var employees = await mvcDemoDbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<ActionResult> cardsDelete(Guid id)
        {
            var employee = await mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {
                mvcDemoDbContext.Employees.Remove(employee);
                await mvcDemoDbContext.SaveChangesAsync();
            }
            return RedirectToAction("cards");
        }
    }
}

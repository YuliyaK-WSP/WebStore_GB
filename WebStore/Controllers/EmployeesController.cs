using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;


namespace WebStore.Controllers
{
    //[Route("Staff/{action=Index}/{Id?}")]
    public class EmployeesController : Controller
    {
        private readonly ICollection<Employee> __Employees;
        public EmployeesController()
        {
            __Employees = TestData.Employees;
        }
        public IActionResult Index()
        {
            return View(__Employees);
        }
        public IActionResult Details(int Id)
        {
            var employee = __Employees.FirstOrDefault(e => e.Id == Id);
            if(employee is null)
            {
                return NotFound();
            }
            return View(employee);
        }
    }
}

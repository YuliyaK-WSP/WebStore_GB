using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;
using WebStore.ViewModels;

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
        //public IActionResult Create() => View();

        public IActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var employee = __Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
            {
                return NotFound();
            }
            var model = new EmployeeEditViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                Profession = employee.Profession,
                Department = employee.Department,
            };

            return View(model);
        }
        public IActionResult Edit(EmployeeEditViewModel Model)
        {
            //Обработка модели...

            return RedirectToAction("Index");
        }
    }
}

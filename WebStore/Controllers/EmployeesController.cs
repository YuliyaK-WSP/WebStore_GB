using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    //[Route("Staff/{action=Index}/{Id?}")]
    public class EmployeesController : Controller
    {
        
        private readonly IEmployeesData __EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData)
        {
           
            __EmployeesData = EmployeesData;
        }
        public IActionResult Index()
        {
            return View(__EmployeesData.GetAll());
        }
        public IActionResult Details(int Id)
        {
            //var employee = __Employees.FirstOrDefault(e => e.Id == Id);
            var employee = __EmployeesData.GetById(Id);
            if (employee is null)
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
            //var employee = __Employees.FirstOrDefault(e => e.Id == id);
            var employee = __EmployeesData.GetById(id);
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
        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel Model)
        {
            var employee = new Employee
            {
                Id = Model.Id,
                LastName = Model.LastName,
                FirstName = Model.FirstName,
                Patronymic = Model.Patronymic,
                Age = Model.Age,
                Profession = Model.Profession,
                Department = Model.Department,
            };
            if (__EmployeesData.Edit(employee))
                return NotFound();

            return RedirectToAction("Index");
        }
    }
}

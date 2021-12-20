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
        
        private readonly IEmployeesData _EmployeesData;
        private readonly ILogger<EmployeesController> _Logger;
        public EmployeesController(IEmployeesData EmployeesData, ILogger<EmployeesController> Logger)
        {

            _EmployeesData = EmployeesData;
            _Logger = Logger;
        }
        public IActionResult Index()
        {
            return View(_EmployeesData.GetAll());
        }
        public IActionResult Details(int Id)
        {
            //var employee = __Employees.FirstOrDefault(e => e.Id == Id);
            var employee = _EmployeesData.GetById(Id);
            if (employee is null)
            {
                return NotFound();
            }
            return View(employee);
        }
        public IActionResult Create() => View("Edit",new EmployeeViewModel());

        public IActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest();

            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            var model = new EmployeeViewModel
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
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_EmployeesData.Delete(id))
                return NotFound();

            _Logger.LogInformation("Сотрудник с id:{0} удалён", id);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            //var employee = __Employees.FirstOrDefault(e => e.Id == id);
            if (id is null)
                return View(new EmployeeViewModel());

            //var employee = __Employees.FirstOrDefault(e => e.Id == id);
            var employee = _EmployeesData.GetById((int)id);
            if (employee is null)
            {
                _Logger.LogWarning("При редактировании сотрудника с id:{0} он не был найден", id);
                return NotFound();
            }
            
            var model = new EmployeeViewModel
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
        public IActionResult Edit(EmployeeViewModel Model)
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
            
            if (Model.Id == 0)
            {
                if(Model.LastName != null)
                {
                    _EmployeesData.Add(employee);
                    _Logger.LogInformation("Создан новый сотрудник {0}", employee);
                    
                }
                else
                {
                    _Logger.LogInformation("проверка данных не прошла");
                    //Messagebox();


                }
                
            }
            else if (!_EmployeesData.Edit(employee))
            {
                _Logger.LogInformation("Информация о сотруднике {0} изменена", employee);
                return NotFound();
            }
            

            return RedirectToAction("Index");
        }
        //public void Messagebox()
        //{
        //    var builder = WebApplication.CreateBuilder();
        //    var app = builder.Build();
        //    app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));
        //    app.Run();
        //}
    }
    
}

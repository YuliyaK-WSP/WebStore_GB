using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Employee> __Employees = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 23, Profession = "Инженер - Разрабочик", Department = 56 },
            new Employee { Id = 2, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 27, Profession = "Инженер - Разработчик", Department = 56 },
            new Employee { Id = 3, LastName = "Сидоров", FirstName = "Сидр", Patronymic = "Сидорович", Age = 18, Profession = "Аналитик", Department = 46 },
            new Employee { Id = 4, LastName = "Васильев", FirstName = "Василий", Patronymic = "Васильевич", Age = 46, Profession = "Системный Администратор", Department = 56 },
            new Employee { Id = 5, LastName = "Сергеев", FirstName = "Сергей", Patronymic = "Алексеевич", Age = 35, Profession = "Аналитик", Department = 46 },

        };
        private static readonly List<EmployeeView> __Details = new()
        {
            new EmployeeView { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 23, Profession = "Инженер - Разрабочик", Department = 56,  Description = "Хроший сотрудник один" },
            new EmployeeView { Id = 2, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 27, Profession = "Инженер - Разработчик", Department = 56,  Description = "Хроший сотрудник два" },
            new EmployeeView { Id = 3, LastName = "Сидоров", FirstName = "Сидр", Patronymic = "Сидорович", Age = 18, Profession = "Аналитик", Department = 46,  Description = "Хроший сотрудник три" },
            new EmployeeView { Id = 4, LastName = "Васильев", FirstName = "Василий", Patronymic = "Васильевич", Age = 46, Profession = "Системный Администратор", Department = 56,  Description = "Хроший сотрудник четыре" },
            new EmployeeView { Id = 5, LastName = "Сергеев", FirstName = "Сергей", Patronymic = "Алексеевич", Age = 35, Profession = "Аналитик", Department = 46,  Description = "Хроший сотрудник пять" },

        };
        public IActionResult Index()
        {
           // return Content("Данные из первого контроллера");
            return View();
        }
        public string ConfiguredAction(string Id, string Value1)
        {
            return $"Hello World! {Id} - {Value1}";
        }
        public IActionResult Employees()
        {
            return View(__Employees);
        }
        public IActionResult Details(int id)
        {
             List<EmployeeView> __Det = new List<EmployeeView>();
            //Получаем сотрудника по Id
            foreach(EmployeeView det in __Details)
            {
                if(det.Id == id)
                {
                    __Det.Add(det);
                }
            }
            return View(__Det);
            
        }

    }
}

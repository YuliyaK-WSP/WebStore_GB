using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Mapping;
using WebStore.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {

        //private static readonly List<EmployeeView> __Details = new()
        //{
        //    new EmployeeView { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 23, Profession = "Инженер - Разрабочик", Department = 56,  Description = "Хроший сотрудник один" },
        //    new EmployeeView { Id = 2, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 27, Profession = "Инженер - Разработчик", Department = 56,  Description = "Хроший сотрудник два" },
        //    new EmployeeView { Id = 3, LastName = "Сидоров", FirstName = "Сидр", Patronymic = "Сидорович", Age = 18, Profession = "Аналитик", Department = 46,  Description = "Хроший сотрудник три" },
        //    new EmployeeView { Id = 4, LastName = "Васильев", FirstName = "Василий", Patronymic = "Васильевич", Age = 46, Profession = "Системный Администратор", Department = 56,  Description = "Хроший сотрудник четыре" },
        //    new EmployeeView { Id = 5, LastName = "Сергеев", FirstName = "Сергей", Patronymic = "Алексеевич", Age = 35, Profession = "Аналитик", Department = 46,  Description = "Хроший сотрудник пять" },

        //};
        public IActionResult Index([FromServices] IProductData ProductData)
        {
            var products = ProductData.GetProducts()
                   .OrderBy(p => p.Order)
                   .Take(6)
                   .ToView();
            ViewBag.Products = products;

            //ControllerContext.HttpContext.Request.RouteValues

            //return Content("Данные из первого контроллера");
            return View();
        }
        public string ConfiguredAction(string Id, string Value1)
        {
            return $"Hello World! {Id} - {Value1}";
        }

        public void Throw(string Message) => throw new ApplicationException(Message);

        public IActionResult Error404() => View();

    }
}

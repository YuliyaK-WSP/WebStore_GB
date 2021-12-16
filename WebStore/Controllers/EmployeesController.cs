﻿using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private static readonly List<Employee> __Employees = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 23, Profession = "Инженер - Разрабочик", Department = 56 },
            new Employee { Id = 2, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 27, Profession = "Инженер - Разработчик", Department = 56 },
            new Employee { Id = 3, LastName = "Сидоров", FirstName = "Сидр", Patronymic = "Сидорович", Age = 18, Profession = "Аналитик", Department = 46 },
            new Employee { Id = 4, LastName = "Васильев", FirstName = "Василий", Patronymic = "Васильевич", Age = 46, Profession = "Системный Администратор", Department = 56 },
            new Employee { Id = 5, LastName = "Сергеев", FirstName = "Сергей", Patronymic = "Алексеевич", Age = 35, Profession = "Аналитик", Department = 46 },

        };
        public IActionResult Index()
        {
            return View(__Employees);
        }
    }
}

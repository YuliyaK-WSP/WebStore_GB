using WebStore.Data;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly ICollection<Employee> __Employees;
        private int __MaxFreeId;
        public InMemoryEmployeesData()
        {
            __Employees = TestData.Employees;
            __MaxFreeId = __Employees.DefaultIfEmpty().Max(e => e?.Id ?? 0) + 1;
        }
        public int Add(Employee employee)
        {
            if(employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            if (__Employees.Contains(employee)) 
                return employee.Id;
            employee.Id = __MaxFreeId++;
            __Employees.Add(employee);
            return employee.Id;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null)
                return false;
            __Employees.Remove(employee);
            return true;
        }

        public bool Edit(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            if (__Employees.Contains(employee))
                return true;
            var db_employee = GetById(employee.Id);
            if (db_employee is null)
                return false;
            db_employee.FirstName = employee.FirstName;
            db_employee.LastName = employee.LastName;
            db_employee.Patronymic = employee.Patronymic;
            db_employee.Age = employee.Age;
            db_employee.Profession = employee.Profession;
            db_employee.Department = employee.Department;
            // Когда будет БД нужно вызвать SaveChanges!
            return true;
        }

        public IEnumerable<Employee> GetAll()
        {
            return __Employees;
        }

        public Employee? GetById(int id) => __Employees.FirstOrDefault(employee => employee.Id == id);
    }
}

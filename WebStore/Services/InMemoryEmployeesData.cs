using WebStore.Data;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly ILogger<InMemoryEmployeesData> _Logger;
        private readonly ICollection<Employee> __Employees;
        private int __MaxFreeId;
        public InMemoryEmployeesData(ILogger<InMemoryEmployeesData> Logger) // ILogger - это интерфейс! <InMemoryEmployeesData> - это название заголовков в журнале
        {
            _Logger = Logger;
            __Employees = TestData.Employees;
            __MaxFreeId = __Employees.DefaultIfEmpty().Max(e => e?.Id ?? 0) + 1;
        }

        public IEnumerable<Employee> GetAll() => __Employees;

        public Employee? GetById(int id) => __Employees.FirstOrDefault(employee => employee.Id == id);

        public int Add(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            if (__Employees.Contains(employee)) // При наличии БД - это писать не надо!!!
                return employee.Id;

            employee.Id = __MaxFreeId++;
            __Employees.Add(employee);

            return employee.Id;
        }

        public bool Edit(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            if (__Employees.Contains(employee))// При наличии БД - это писать не надо!!!
                return true;

            var db_employee = GetById(employee.Id);
            if (db_employee is null)
            {
                _Logger.LogWarning("Попытка редактирования отсутствующего сотрудника с Id:{0}", employee.Id); // при вызове методов логгера важно использовать шаблоны строк, а не интерполяцию!
                return false;
            }

            db_employee.FirstName = employee.FirstName;
            db_employee.LastName = employee.LastName;
            db_employee.Patronymic = employee.Patronymic;
            db_employee.Age = employee.Age;

            // Когда будет БД, не забыть вызвать SaveChanges()

            _Logger.LogInformation("Информация о сотруднике id:{0} была изменена", employee.Id);

            return true;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null)
            {
                _Logger.LogWarning("Попытка удаления отсутствующего сотрудника с Id:{0}", id); // при вызове методов логгера важно использовать шаблоны строк, а не интерполяцию!
                return false;
            }

            __Employees.Remove(employee);

            _Logger.LogInformation("Сотрудник с id:{0} был успешно удалён", employee.Id);
            return true;
        }
    }
}

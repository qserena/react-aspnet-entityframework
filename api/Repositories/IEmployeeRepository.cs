using api.Models;

namespace api.Repositories
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);
        Employee GetEmployeeById(int id);
        List<Employee> GetAllEmployees();
        void UpdateEmployee(Employee employee);
    }
}

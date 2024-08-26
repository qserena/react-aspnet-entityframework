using api.Models;
using api.Data;

namespace api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee employee) 
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            
            _context.Employees.Add(employee); 
            _context.SaveChanges(); 
        } 
      
        public void DeleteEmployee(int id) { 
            var employee = _context.Employees.Find(id); 
            if (employee == null) 
            { 
                throw new ArgumentNullException(nameof(employee)); 
            } 
            _context.Employees.Remove(employee); 
            _context.SaveChanges(); 
        }

        public Employee GetEmployeeById(int id) 
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Employees.FirstOrDefault(e => e.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public List<Employee> GetAllEmployees() 
        {             
            return _context.Employees.ToList();
        }

        public void UpdateEmployee(Employee employee) 
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Update(employee); 
            _context.SaveChanges(); 
        }
    }
}

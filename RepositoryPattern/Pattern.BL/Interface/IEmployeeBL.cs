using Pattern.Models;
using Pattern.VM;
using System.Collections.Generic;

namespace Pattern.BL
{
    public interface IEmployeeBL
    {
        bool CheckEmployeeExist(string email);
        void CreateEmployee(EmployeeVM employeeVM);
        void DeleteEmployee(Employee user);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(long id);
        void UpdateEmployee(Employee user);
    }
}
using Pattern.Models;
using System.Collections.Generic;

namespace Pattern.Repo
{
    public interface IEmployeeRepo
    {
        bool CheckEmployeeExist(string email);
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(long id);
        void UpdateEmployee(Employee employee);
    }
}
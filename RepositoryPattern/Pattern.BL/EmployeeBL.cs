using Pattern.Models;
using Pattern.Repo;
using Pattern.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.BL
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeBL(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public void CreateEmployee(EmployeeVM employeeVM)
        {
            Employee employee = new Employee();
            employee.FirstName = employeeVM.FirstName;
            employee.LastName = employeeVM.LastName;
            employee.Email = employeeVM.Email;
            employee.Age = employeeVM.Age;
            this.employeeRepo.CreateEmployee(employee);
        }

        public void UpdateEmployee(Employee user)
        {
            this.employeeRepo.UpdateEmployee(user);
        }

        public void DeleteEmployee(Employee user)
        {
            this.employeeRepo.DeleteEmployee(user);
        }

        public List<Employee> GetAllEmployees()
        {
            return this.employeeRepo.GetAllEmployees();
        }

        public Employee GetEmployeeById(long id)
        {
            return this.employeeRepo.GetEmployeeById(id);
        }

        public bool CheckEmployeeExist(string email)
        {
            return this.employeeRepo.CheckEmployeeExist(email);
        }
    }
}

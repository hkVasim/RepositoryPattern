using Pattern.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pattern.Repo
{
    public class EmployeeRepo : RepositoryBase<Employee>, IEmployeeRepo
    {
        private readonly ApplicationContext applicationContext;

        public EmployeeRepo(ApplicationContext applicationContext)
            : base(applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public void CreateEmployee(Employee employee)
        {
            this.Create(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            this.Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            this.Delete(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return this.FindAll();
        }

        public Employee GetEmployeeById(long id)
        {
            return this.FindByCondition(item => item.EmployeeId == id).FirstOrDefault();
        }

        public bool CheckEmployeeExist(string email)
        {
            var result = this.FindByCondition(item => item.Email == email).Count();
            return result > 0 ? true : false;
        }
    }
}
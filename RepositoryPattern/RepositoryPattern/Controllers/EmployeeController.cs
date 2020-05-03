using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pattern.BL;
using Pattern.Models;
using Pattern.VM;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }

        /// <summary>
        /// Get All Employee.
        /// </summary>
        /// <returns>List of Employee.</returns>
        [HttpGet]
        [Route("GetAllEmployees")]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return this.employeeBL.GetAllEmployees();
        }

        /// <summary>
        /// Get Empployee by Id.
        /// </summary>
        /// <param name="id">Emlpoyee Id.</param>
        /// <returns>Emlpoyee.</returns>
        [HttpGet]
        [Route("GetEmployeeById")]
        public ActionResult<Employee> GetEmployee(long id)
        {
            var employee = this.employeeBL.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        /// <summary>
        /// Update Employee.
        /// </summary>
        /// <param name="employee">employee.</param>
        /// <returns>Update Employee.</returns>
        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult PutEmployee(Employee employee)
        {
            try
            {
                var result = this.employeeBL.GetEmployeeById(employee.EmployeeId);
                if (result != null)
                {
                    this.employeeBL.UpdateEmployee(employee);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Add Employee.
        /// </summary>
        /// <param name="employeeModel">employeeModel.</param>
        /// <returns>Employee.</returns>
        [HttpPost]
        [Route("AddEmployee")]
        public ActionResult<Employee> PostEmployee([FromBody] EmployeeVM employeeModel)
        {
            this.employeeBL.CreateEmployee(employeeModel);
            return this.Ok();
        }

        /// <summary>
        /// Delete Employee by Id.
        /// </summary>
        /// <param name="id">Employee Id.</param>
        /// <returns>Delete Record.</returns>
        [HttpDelete]
        [Route("DeleteEmployee")]
        public ActionResult<Employee> DeleteEmployee(long id)
        {
            var user = this.employeeBL.GetEmployeeById(id);
            if (user == null)
            {
                return NotFound();
            }

            this.employeeBL.DeleteEmployee(user);
            return user;
        }
    }
}
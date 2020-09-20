using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    /// <summary> Сотрудники </summary>
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> GetAllEmployees() => Employee.Employees;
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = Employee.OneEmployee(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }
    }
}

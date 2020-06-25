using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : ApiController
    {
        public IEnumerable<Department> GetAllDepartments() => Department.Departments;
        public IHttpActionResult GetDepartment(int id)
        {
            var dep = Department.OneDepartment(id);
            if (dep == null)
                return NotFound();
            return Ok(dep);
        }
    }
}

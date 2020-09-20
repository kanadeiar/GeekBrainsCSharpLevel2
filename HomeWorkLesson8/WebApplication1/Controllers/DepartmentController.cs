using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    /// <summary> Отделы </summary>
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Сотрдники с отделами
    /// </summary>
    public class EmployeeViewController : ApiController
    {
        public IEnumerable<EmployeeView> GetAllEmployeeViews() => EmployeeView.EmployeeViews;
        public IHttpActionResult GetEmployeeView(int id)
        {
            var employeeView = EmployeeView.OneEmployeeView(id);
            if (employeeView == null)
                return NotFound();
            return Ok(employeeView);
        }
    }
}

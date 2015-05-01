using KuasCore.Models;
using KuasCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEmployeeService EmployeeService { get; set; }

        [HttpGet]
        public IList<Employee> GetAllEmployees()
        {
            return EmployeeService.GetAllEmployees();
        }

        [HttpGet]
        [ActionName("byId")]
        public Employee GetEmployeeById(string id)
        {
            var employee = EmployeeService.GetEmployeeById(id);

            if (employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return employee;
        }

        [HttpGet]
        [ActionName("byname")]
        public IList<Employee> GetEmployeeByName(string id)
        {
            var employees = EmployeeService.GetEmployeeByName(id);

            if (employees == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return employees;
        }
    }
}

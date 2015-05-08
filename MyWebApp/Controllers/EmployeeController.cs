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
        public ICourseService CourseService { get; set; }



        [HttpGet]
        public IList<Course> GetAllCourses()
        {
            return CourseService.GetAllCourses();
        }

        [HttpGet]
        [ActionName("byId")]
        public Course GetCourseById(string id)
        {
            var employee = CourseService.GetCourseById(id);

            if (employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return employee;
        }

        [HttpGet]
        [ActionName("byname")]
        public IList<Course> GetCourseByName(string id)
        {
            var employees = CourseService.GetCourseByName(id);

            if (employees == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return employees;
        }
    }
}

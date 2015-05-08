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
    public class CourseController : ApiController
    {
        public ICourseService CourseService { get; set; }

        [HttpPost]
        public Course AddCourse(Course course)
        {
            CheckCourseIsNotNullThrowException(course);

            try
            {
                CourseService.AddCourse(course);
                return CourseService.GetCourseById(course.CourseID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Course UpdateCourse(Course course)
        {
            CheckCourseIsNullThrowException(course);

            try
            {
                CourseService.UpdateCourse(course);
                return CourseService.GetCourseById(course.CourseID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteCourse(Course course)
        {
            try
            {
                CourseService.DeleteCourse(course);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

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


        /// <summary>
        ///     檢查員工資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        private void CheckCourseIsNullThrowException(Course course)
        {
            Course dbEmployee = CourseService.GetCourseById(course.CourseID);

            if (dbEmployee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查員工資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        private void CheckCourseIsNotNullThrowException(Course course)
        {
            Course dbEmployee = CourseService.GetCourseById(course.CourseID);

            if (dbEmployee != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }
    }
}

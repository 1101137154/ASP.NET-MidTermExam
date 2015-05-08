
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{
    public class CourseDao : GenericDao<Course>, ICourseDao
    {

        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course course)
        {
            string command = @"INSERT INTO Course (CourseID, CourseName, CourseDescription) VALUES (@Id, @Name, @Desc);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = course.CourseID;
            parameters.Add("Name", DbType.String).Value = course.CourseName;
            parameters.Add("Desc", DbType.String).Value = course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateCourse(Course course)
        {
            string command = @"UPDATE Course SET CourseName = @Name, CourseDescription = @Desc WHERE CourseID = @Id;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = course.CourseID;
            parameters.Add("Name", DbType.String).Value = course.CourseName;
            parameters.Add("Desc", DbType.String).Value = course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteCourse(Course course)
        {
            string command = @"DELETE FROM Course WHERE CourseID = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = course.CourseID;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Course> GetAllCourses()
        {
            string command = @"SELECT * FROM Course ORDER BY CourseID ASC";
            IList<Course> courses = ExecuteQueryWithRowMapper(command);
            return courses;
        }

        public Course GetCourseById(string id)
        {
            string command = @"SELECT * FROM Course WHERE CourseID = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = id;

            IList<Course> courses = ExecuteQueryWithRowMapper(command, parameters);
            if (courses.Count > 0)
            {
                return courses[0];
            }

            return null;
        }


        public IList<Course> GetCourseByName(string name)
        {
            string command = @"SELECT * FROM Course WHERE CourseName LIKE @name";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("name", DbType.String).Value = name;

            IList<Course> courses = ExecuteQueryWithRowMapper(command, parameters);
            if (courses.Count > 0)
            {
                return courses;
            }

            return null;
        }
    }
}

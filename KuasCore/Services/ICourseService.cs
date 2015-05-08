using KuasCore.Dao;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services
{

    /// <summary>
    ///     員工資料維護的 Service.
    /// </summary>
    public interface ICourseService
    {

        /// <summary>
        ///     新增員工資料.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        void AddCourse(Course course);

        /// <summary>
        ///     修改員工資料.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        void UpdateCourse(Course course);

        /// <summary>
        ///     刪除員工資料.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        void DeleteCourse(Course course);

        /// <summary>
        ///     取得所有員工資料.
        /// </summary>
        /// <returns>
        ///     所有員工資料.
        /// </returns>
        IList<Course> GetAllCourses();

        /// <summary>
        ///     依據 ID 取得員工資料.
        /// </summary>
        /// <param name="id">
        ///     員工 Id.
        /// </param>
        /// <returns>
        ///     該員工資料.
        /// </returns>
        Course GetCourseById(string id);

        IList<Course> GetCourseByName(string name);
    }
}

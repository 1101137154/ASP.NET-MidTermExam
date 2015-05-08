using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services
{
    [TestClass]
    public class EmployeeServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyCourseNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseService EmployeeService { get; set; }

        [TestMethod]
        public void TestEmployeeService_AddEmployee()
        {
            Course empolyee = new Course();
            empolyee.CourseID = "UnitTests";
            empolyee.CourseName = "單元測試";
            empolyee.CourseDescription = "desc";
            EmployeeService.AddCourse(empolyee);

            Course dbEmpolyee = EmployeeService.GetCourseById(empolyee.CourseID);
            Assert.IsNotNull(dbEmpolyee);
            Assert.AreEqual(empolyee.CourseID, dbEmpolyee.CourseID);

            Console.WriteLine("員工編號為 = " + dbEmpolyee.CourseID);
            Console.WriteLine("員工姓名為 = " + dbEmpolyee.CourseName);
            Console.WriteLine("員工DESC為 = " + dbEmpolyee.CourseDescription);

            EmployeeService.DeleteCourse(dbEmpolyee);
            dbEmpolyee = EmployeeService.GetCourseById(empolyee.CourseID);
            Assert.IsNull(dbEmpolyee);
        }

        [TestMethod]
        public void TestEmployeeService_UpdateEmployee()
        {
            // 取得資料
            Course empolyee = EmployeeService.GetCourseById("dennis_yen");
            Assert.IsNotNull(empolyee);

            // 更新資料
            empolyee.CourseName = "單元測試";
            EmployeeService.UpdateCourse(empolyee);

            // 再次取得資料
            Course dbEmpolyee = EmployeeService.GetCourseById(empolyee.CourseID);
            Assert.IsNotNull(dbEmpolyee);
            Assert.AreEqual(empolyee.CourseName, dbEmpolyee.CourseName);

            Console.WriteLine("員工編號為 = " + dbEmpolyee.CourseID);
            Console.WriteLine("員工姓名為 = " + dbEmpolyee.CourseName);
            Console.WriteLine("員工DESC為 = " + dbEmpolyee.CourseDescription);

            Console.WriteLine("================================");

            // 將資料改回來
            empolyee.CourseName = "嚴志和";
            EmployeeService.UpdateCourse(empolyee);

            // 再次取得資料
            dbEmpolyee = EmployeeService.GetCourseById(empolyee.CourseID);
            Assert.IsNotNull(dbEmpolyee);
            Assert.AreEqual(empolyee.CourseName, dbEmpolyee.CourseName);

            Console.WriteLine("員工編號為 = " + dbEmpolyee.CourseID);
            Console.WriteLine("員工姓名為 = " + dbEmpolyee.CourseName);
            Console.WriteLine("員工DESC為 = " + dbEmpolyee.CourseDescription);
        }


        [TestMethod]
        public void TestEmployeeService_DeleteEmployee()
        {
            Course newEmpolyee = new Course();
            newEmpolyee.CourseID = "UnitTests";
            newEmpolyee.CourseName = "單元測試";
            newEmpolyee.CourseDescription = "desc";
            EmployeeService.AddCourse(newEmpolyee);

            Course dbEmpolyee = EmployeeService.GetCourseById(newEmpolyee.CourseID);
            Assert.IsNotNull(dbEmpolyee);

            EmployeeService.DeleteCourse(dbEmpolyee);
            dbEmpolyee = EmployeeService.GetCourseById(newEmpolyee.CourseID);
            Assert.IsNull(dbEmpolyee);
        }

        [TestMethod]
        public void TestEmployeeService_GetEmployeeById()
        {
            Course empolyee = EmployeeService.GetCourseById("kuas001");
            Assert.IsNotNull(empolyee);

            Console.WriteLine("員工編號為 = " + empolyee.CourseID);
            Console.WriteLine("員工姓名為 = " + empolyee.CourseName);
            Console.WriteLine("員工DESC為 = " + empolyee.CourseDescription);
        }

    }
}

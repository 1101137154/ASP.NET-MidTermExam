using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCoreTests.Dao
{

    [TestClass]
    public class EmployeeDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        #region 單元測試 Spring 必寫的內容 
        
        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    // assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseDao EmployeeDao { get; set; }


        [TestMethod]
        public void TestEmployeeDao_AddEmployee()
        {
            Course employee = new Course();
            employee.CourseID = "UnitTests";
            employee.CourseName = "單元測試";
            employee.CourseDescription = "desc";
            EmployeeDao.AddCourse(employee);

            Course dbEmployee = EmployeeDao.GetCourseById(employee.CourseID);
            Assert.IsNotNull(dbEmployee);
            Assert.AreEqual(employee.CourseID, dbEmployee.CourseID);

            Console.WriteLine("員工編號為 = " + dbEmployee.CourseID);
            Console.WriteLine("員工姓名為 = " + dbEmployee.CourseName);
            Console.WriteLine("員工DESC為 = " + dbEmployee.CourseDescription);

            EmployeeDao.DeleteCourse(dbEmployee);
            dbEmployee = EmployeeDao.GetCourseById(employee.CourseID);
            Assert.IsNull(dbEmployee);
        }

        [TestMethod]
        public void TestEmployeeDao_UpdateEmployee()
        {
            // 取得資料
            Course employee = EmployeeDao.GetCourseById("dennis_yen");
            Assert.IsNotNull(employee);
            
            // 更新資料
            employee.CourseName = "單元測試";
            EmployeeDao.UpdateCourse(employee);

            // 再次取得資料
            Course dbEmployee = EmployeeDao.GetCourseById(employee.CourseID);
            Assert.IsNotNull(dbEmployee);
            Assert.AreEqual(employee.CourseName, dbEmployee.CourseName);

            Console.WriteLine("員工編號為 = " + dbEmployee.CourseID);
            Console.WriteLine("員工姓名為 = " + dbEmployee.CourseName);
            Console.WriteLine("員工DESC為 = " + dbEmployee.CourseDescription);

            Console.WriteLine("================================");

            // 將資料改回來
            employee.CourseName = "嚴志和";
            EmployeeDao.UpdateCourse(employee);

            // 再次取得資料
            dbEmployee = EmployeeDao.GetCourseById(employee.CourseID);
            Assert.IsNotNull(dbEmployee);
            Assert.AreEqual(employee.CourseName, dbEmployee.CourseName);

            Console.WriteLine("員工編號為 = " + dbEmployee.CourseID);
            Console.WriteLine("員工姓名為 = " + dbEmployee.CourseName);
            Console.WriteLine("員工DESC為 = " + dbEmployee.CourseDescription);
        }


        [TestMethod]
        public void TestEmployeeDao_DeleteEmployee()
        {
            Course newEmployee = new Course();
            newEmployee.CourseID = "UnitTests";
            newEmployee.CourseName = "單元測試";
            newEmployee.CourseDescription = "desc";
            EmployeeDao.AddCourse(newEmployee);

            Course dbEmployee = EmployeeDao.GetCourseById(newEmployee.CourseID);
            Assert.IsNotNull(dbEmployee);

            EmployeeDao.DeleteCourse(dbEmployee);
            dbEmployee = EmployeeDao.GetCourseById(newEmployee.CourseID);
            Assert.IsNull(dbEmployee);
        }

        [TestMethod]
        public void TestEmployeeDao_GetEmployeeById()
        {
            Course employee = EmployeeDao.GetCourseById("dennis_yen");
            Assert.IsNotNull(employee);
            Console.WriteLine("員工編號為 = " + employee.CourseID);
            Console.WriteLine("員工姓名為 = " + employee.CourseName);
            Console.WriteLine("員工DESC為 = " + employee.CourseDescription);
        }

    }
}

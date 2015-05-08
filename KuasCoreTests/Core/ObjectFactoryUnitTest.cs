using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using KuasCore.Models;
using KuasCore.Services.Impl;
using Core;
using Spring.Context;
using Spring.Context.Support;
using KuasCore.Services;

namespace KuasCoreTests.Core
{
    [TestClass]
    public class ObjectFactoryUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        [TestMethod]
        public void TestObjectFactory_GetApplicationContext()
        {

            // 利用 Spring Object Name 來依賴尋找找出我們要的 Spring Object.
            IApplicationContext applicationContext = ObjectFactory.GetApplicationContext();
            ICourseService employeeService = (ICourseService)applicationContext["employeeService"];

            Course empolyee = employeeService.GetCourseById("dennis_yen");
            Assert.IsNotNull(empolyee);

            Console.WriteLine("員工編號為 = " + empolyee.CourseID);
            Console.WriteLine("員工姓名為 = " + empolyee.CourseName);
            Console.WriteLine("員工DESC為 = " + empolyee.CourseDescription);

        }

        [TestMethod]
        public void TestObjectFactory_GetObject()
        {

            // 利用 Spring Object Name 來依賴尋找找出我們要的 Spring Object.
            ICourseService employeeService = (ICourseService)ObjectFactory.GetObject("employeeService");

            Course empolyee = employeeService.GetCourseById("dennis_yen");
            Assert.IsNotNull(empolyee);

            Console.WriteLine("員工編號為 = " + empolyee.CourseID);
            Console.WriteLine("員工姓名為 = " + empolyee.CourseName);
            Console.WriteLine("員工DESC為 = " + empolyee.CourseDescription);
        }

    }
}

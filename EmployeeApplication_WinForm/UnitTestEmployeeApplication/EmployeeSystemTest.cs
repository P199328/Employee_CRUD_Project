using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeApplication_WinForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace UnitTestEmployeeApplication
{
    [TestClass]
    public class EmployeeCRUDUnitTest
    {
        EmployeeData emp = new EmployeeData();
        EmployeeModel employeeModel = new EmployeeModel();
        [TestMethod()]
        public void TestRestWebApi()
        {

            var response = RestApicall.GetAll();
           
            Assert.IsNotNull(response);
           
        }


        [TestMethod()]
        public void GetById()
        {

            var response = RestApicall.GetById("2304054");
            Assert.IsNotNull(response);


        }
        [TestMethod()]
        public  void AddEmployee()
        {
           
            var response =  RestApicall.AddEmployee("Nitin", "Nitink@test.com", "male", "active");
            Assert.IsNotNull(response);
        }
        [TestMethod()]
        public void UpdateEmployee()
        {

            var response = RestApicall.UpdateEmployee("2304054","Nitin", "Nitink@test.com", "male", "active");
            Assert.IsNotNull(response);
        }
        [TestMethod()]
        public void DeleteEmployeeById()
        {

            var response = RestApicall.DeleteEmployee("2304054");
            Assert.IsNotNull(response);


        }

    }
}

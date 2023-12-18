using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagment.Test
{
    public class EmployeeFactoryTests : IDisposable
    {
        private EmployeeFactory _employeeFactory;
        public EmployeeFactoryTests()
        {
            _employeeFactory = new EmployeeFactory();
        }
        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        //NAMEOFTESTEDMETHOD_ACTIONEXECUTED_EXPECTEDBEHAVIOR
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            //Arrange
            //var employeeFactory = new EmployeeFactory();

            //Act
            var employee= (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");

            //Assert
            Assert.Equal(2500,employee.Salary);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
        {
            //Arrange
            //var employeeFactory = new EmployeeFactory();

            //Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");

            //Assert
            Assert.True(employee.Salary >= 2500 && employee.Salary <= 3500);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_Alternative()
        {
            //Arrange
            //var employeeFactory = new EmployeeFactory();

            //Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");

            //Assert
            Assert.True(employee.Salary >= 2500);
            Assert.True(employee.Salary <= 3500);
        }


        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWithInRange()
        {
            //Arrange
            //var employeeFactory = new EmployeeFactory();

            //Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");

            //Assert
            Assert.InRange(employee.Salary,2500,3500); 
        }

        [Fact(Skip = "Skipping this one for demo reasons.")]
        [Trait("Category","EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500_PrecisionExample()
        {
            //Arrange
            //var employeeFactory = new EmployeeFactory();

            //Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");
            employee.Salary = 2500.123m;
            //Assert
            Assert.Equal(2500, employee.Salary, 0);
        }

        [Fact]
        [Trait("Category","EmployeeFactory_CreateEmployee_ReturnType")]
        public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
        {
            //Arrange
            //var employeeFactory = new EmployeeFactory();

            //Act
            var employee = _employeeFactory.CreateEmployee("Kevin", "Dockx","Marvin", true);

            //Assert
            Assert.IsType<ExternalEmployee>(employee);
            //Assert.IsAssignableFrom<Employee>(employee);
        }

        public void Dispose()
        {
           //clean up the setup code, if required
        }

        [Fact]
        public void SlowTest1()
        {
            Thread.Sleep(5000);
            Assert.True(true);
        }  
    }
}

using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagment.Test
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameIsConcatenated()
        {
            //Arrange
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

            //Act
            employee.FirstName = "Lucia";
            employee.LastName = "SHELTON";

            //Assert
            Assert.Equal("Lucia Shelton", employee.FullName, ignoreCase: true);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameStartsWithFirstName()
        {
            //Arrange
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

            //Act
            employee.FirstName = "Lucia";
            employee.LastName = "SHELTON";

            //Assert
            Assert.StartsWith(employee.FirstName,employee.FullName);
        }

        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameEndsWithFirstName()
        {
            //Arrange
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

            //Act
            employee.FirstName = "Lucia";
            employee.LastName = "SHELTON";

            //Assert
            Assert.EndsWith(employee.LastName, employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameContainsPartOfConcatenation()
        {
            //Arrange
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

            //Act
            employee.FirstName = "Lucia";
            employee.LastName = "SHELTON";

            //Assert
            Assert.Contains("ia SH", employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameSoundsLikeConcatenation()
        {
            //Arrange
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

            //Act
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";

            //Assert
            Assert.Matches("Lu(c|s|z)ia Shel(t|d)on", employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameNotEmpty()
        {
            //Arrange
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

            //Act
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";

            //Assert
            Assert.NotEmpty(employee.FullName);
        }
    }
}

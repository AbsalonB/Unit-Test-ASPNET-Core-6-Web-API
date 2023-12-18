using EmployeeManagement.DataAccess.Entities;
using EmployeeManagment.Test.Fixtures;
using EmployeeManagment.Test.TestData;

namespace EmployeeManagment.Test
{
    [Collection("EmployeeServiceCollection")]
    public class DataDrivenEmployeeServiceTests //: IClassFixture<EmployeeServiceFixture>
    {
        private readonly EmployeeServiceFixture _employeeServiceFixture;

        public DataDrivenEmployeeServiceTests(EmployeeServiceFixture employeeServiceFixture)
        {
            _employeeServiceFixture = employeeServiceFixture;
        }

        [Theory]
        [InlineData("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")]
        [InlineData("37e03ca7-c730-4351-834c-b66f280cdb01")]
        public void CreateInternalEmployee_InternalEmployeeCreated_MusthaveAttendedSecondObligatoryCourse(Guid courseId)
        {
            //Arrange
      
            //Act
            var internalEmployee = _employeeServiceFixture
                .EmployeeService.CreateInternalEmployee("Brooklyn", "Cannon");

            //Assert
            Assert.Contains(internalEmployee.AttendedCourses, course => course.Id == courseId);
        }

        [Fact]
        public async Task GivenRaise_MinimumRaiseGive_EmployeeMinimumRaiseGiveMustBeTrue()
        {
            //Arrange
            var internalEmployee = new InternalEmployee("Brooklyn", "Cannon", 5, 3000, false, 1);

            //Act
            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, 100);

            //Assert
            Assert.True(internalEmployee.MinimumRaiseGiven);
        }

        [Fact]
        public async Task GivenRaise_MoreThanminimumRaise_EmployeeMinimumRaiseGiveMustBeTrue()
        {
            //Arrange
            var internalEmployee = new InternalEmployee("Brooklyn", "Cannon", 5, 3000, false, 1);

            //Act
            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, 200);

            //Assert
            Assert.False(internalEmployee.MinimumRaiseGiven);
        }

        //public static IEnumerable<object[]> ExampleTestDataForGiveRaise_WithProperty 
        //{ 
        //    get
        //    {
        //        return new List<object[]>
        //        {
        //            new object[]{100,true},
        //            new object[]{200,false}
        //        };
        //    }
        //}

        public static IEnumerable<object[]> ExampleTestDataForGiveRaise_WithMethod(int testDataInstancesToProvide)
        { 
            var testData = new List<object[]>
            {
                new object[]{100,true},
                new object[]{200,false}
            };

            return testData.Take(testDataInstancesToProvide);
        }

        [Theory]
        //[MemberData(nameof(ExampleTestDataForGiveRaise_WithProperty))]
        [MemberData(nameof(ExampleTestDataForGiveRaise_WithMethod),1, MemberType = typeof(DataDrivenEmployeeServiceTests))]
        public async Task GivenRaise_MoreThanminimumRaise_EmployeeMinimumRaiseGiveMatchesValue
            (int raiseGiven, bool expectedValueForMinimumRaiseGive)
        {
            //Arrange
            var internalEmployee = new InternalEmployee("Brooklyn", "Cannon", 5, 3000, false, 1);

            //Act
            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, raiseGiven);

            //Assert
            Assert.Equal(expectedValueForMinimumRaiseGive, internalEmployee.MinimumRaiseGiven);
        }

        [Theory]
        [ClassData(typeof(EmployeeServiceTestData))]
        public async Task GivenRaise_MoreThanminimumRaise_EmployeeMinimumRaiseGiveMatchesValue_WithClassAttribute
      (int raiseGiven, bool expectedValueForMinimumRaiseGive)
        {
            //Arrange
            var internalEmployee = new InternalEmployee("Brooklyn", "Cannon", 5, 3000, false, 1);

            //Act
            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, raiseGiven);

            //Assert
            Assert.Equal(expectedValueForMinimumRaiseGive, internalEmployee.MinimumRaiseGiven);
        }

        [Theory]
        [ClassData(typeof(StronglyTypedEmployeeServiceTestData))]
        public async Task GivenRaise_MoreThanminimumRaise_EmployeeMinimumRaiseGiveMatchesValue_WithStrongTypeTestData
  (int raiseGiven, bool expectedValueForMinimumRaiseGive)
        {
            //Arrange
            var internalEmployee = new InternalEmployee("Brooklyn", "Cannon", 5, 3000, false, 1);

            //Act
            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, raiseGiven);

            //Assert
            Assert.Equal(expectedValueForMinimumRaiseGive, internalEmployee.MinimumRaiseGiven);
        }

        public static TheoryData<int,bool> StronglyTypedExampleTestDataForGiveRaise_WithProperty
        {
            get
            {
                return new TheoryData<int, bool>()
                {
                    { 100, true },
                    { 200, false },
                };
            }
        }

        [Theory]
        [MemberData(nameof(StronglyTypedExampleTestDataForGiveRaise_WithProperty))]
        public async Task GivenRaise_MoreThanminimumRaise_EmployeeMinimumRaiseGiveMatchesValue_PassFromMethod
 (int raiseGiven, bool expectedValueForMinimumRaiseGive)
        {
            //Arrange
            var internalEmployee = new InternalEmployee("Brooklyn", "Cannon", 5, 3000, false, 1);

            //Act
            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, raiseGiven);

            //Assert
            Assert.Equal(expectedValueForMinimumRaiseGive, internalEmployee.MinimumRaiseGiven);
        }

        [Theory]
        [ClassData(typeof(StronglyTypedEmployeeServiceTestData_FromFile))]
        public async Task GivenRaise_MoreThanminimumRaise_EmployeeMinimumRaiseGiveMatchesValue_PassFromFile
 (int raiseGiven, bool expectedValueForMinimumRaiseGive)
        {
            //Arrange
            var internalEmployee = new InternalEmployee("Brooklyn", "Cannon", 5, 3000, false, 1);

            //Act
            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, raiseGiven);

            //Assert
            Assert.Equal(expectedValueForMinimumRaiseGive, internalEmployee.MinimumRaiseGiven);
        }
    }
}

using EmployeeManagement.Business;
using EmployeeManagement.Business.EventArguments;
using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Test;
using EmployeeManagment.Test.Fixtures;
using Xunit.Abstractions;

namespace EmployeeManagment.Test
{
    [Collection("EmployeeServiceCollection")]
    public class EmployeeServiceTests //: IClassFixture<EmployeeServiceFixture>
    {
        private readonly EmployeeServiceFixture _employeeServiceFixture;
        private readonly ITestOutputHelper _testoutputHelper;

        public EmployeeServiceTests(EmployeeServiceFixture employeeServiceFixture, ITestOutputHelper testOutputHelper)
        {
            _employeeServiceFixture = employeeServiceFixture;
            _testoutputHelper = testOutputHelper;
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MusthaveAttendedFirstObligatoryCourse_WithObject()
        {
            //Arrange
            //var employeeManagmentTestDataRepository = new EmployeeManagementTestDataRepository();

            //var employeeService =
            //    new EmployeeService(employeeManagmentTestDataRepository, new EmployeeFactory());

            var obligatoryCourse = _employeeServiceFixture
                .EmployeeManagementTestDataRepository
                .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            //Act
            var internalEmployee = _employeeServiceFixture
                .EmployeeService
                .CreateInternalEmployee("Brooklyn", "Cannon");

            _testoutputHelper.WriteLine($"Employee after Act: "+ $"{internalEmployee.FirstName} {internalEmployee.LastName}");

            //Assert
            Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MusthaveAttendedFirstObligatoryCourse_WithPredicate()
        {
            //Arrange
            //var employeeManagmentTestDataRepository = new EmployeeManagementTestDataRepository();

            //var employeeService =
            //    new EmployeeService(employeeManagmentTestDataRepository, new EmployeeFactory());


            //Act
            var internalEmployee = _employeeServiceFixture
                .EmployeeService
                .CreateInternalEmployee("Brooklyn", "Cannon");

            //Assert
            Assert.Contains(internalEmployee.AttendedCourses, course => course.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MusthaveAttendedSecondObligatoryCourse_WithPredicate()
        {
            //Arrange
            //var employeeManagmentTestDataRepository = new EmployeeManagementTestDataRepository();

            //var employeeService =
            //    new EmployeeService(employeeManagmentTestDataRepository, new EmployeeFactory());


            //Act
            var internalEmployee = _employeeServiceFixture
                .EmployeeService.CreateInternalEmployee("Brooklyn", "Cannon");

            //Assert
            Assert.Contains(internalEmployee.AttendedCourses, course => course.Id == Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_AttendedCoursesMustMatchObligatoryCourses()
        {
            //Arrange
            //var employeeManagmentTestDataRepository = new EmployeeManagementTestDataRepository();

            //var employeeService =
            //    new EmployeeService(employeeManagmentTestDataRepository, new EmployeeFactory());

            var obligatoryCourses = _employeeServiceFixture.EmployeeManagementTestDataRepository
                .GetCourses(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01")
                , Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));
            //Act
            var internalEmployee = _employeeServiceFixture
                .EmployeeService.CreateInternalEmployee("Brooklyn", "Cannon");

            //Assert
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_AttendedCoursesMustNotBeNew()
        {
            //Arrange
            //var employeeManagmentTestDataRepository = new EmployeeManagementTestDataRepository();

            //var employeeService =
            //    new EmployeeService(employeeManagmentTestDataRepository, new EmployeeFactory());

            //Act
            var internalEmployee = _employeeServiceFixture
                .EmployeeService.CreateInternalEmployee("Brooklyn", "Cannon");

            //Assert
            //foreach (var course in internalEmployee.AttendedCourses)
            //{
            //    Assert.False(course.IsNew);
            //}
            Assert.All(internalEmployee.AttendedCourses, course => Assert.False(course.IsNew));
        }

        [Fact]
        public async Task CreateInternalEmployee_InternalEmployeeCreated_AttendedCoursesMustMatchObligatoryCourse_Async()
        {
            //Arrange
            //var employeeManagmentTestDataRepository = new EmployeeManagementTestDataRepository();

            //var employeeService =
            //    new EmployeeService(employeeManagmentTestDataRepository, new EmployeeFactory());
            var obligatoryCourses = await _employeeServiceFixture.EmployeeManagementTestDataRepository
              .GetCoursesAsync(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01")
              , Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));
            //Act
            var internalEmployee = await _employeeServiceFixture
                .EmployeeService.CreateInternalEmployeeAsync("Brooklyn", "Cannon");

            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
        }
        [Fact]
        public async Task GivenRaise_RaiseBelowMinimumGive_EmployeeInvalidRaiseExceptionMustBeThrown()
        {
            //Arrange
            //var employeeManagmentTestDataRepository = new EmployeeManagementTestDataRepository();

            //var employeeService =
            //    new EmployeeService(employeeManagmentTestDataRepository, new EmployeeFactory());

            var internalEmployee = new InternalEmployee("Brooklyn", "Cannon", 5, 3000, false, 1);

            //Act
            await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
                async () =>
                await _employeeServiceFixture
                .EmployeeService.GiveRaiseAsync(internalEmployee, 50)
            );
        }

        //[Fact]
        //public void GivenRaise_RaiseBelowMinimumGive_EmployeeInvalidRaiseExceptionMustBeThrown_Mistake()
        //{
        //    //Arrange
        //    var employeeManagmentTestDataRepository = new EmployeeManagementTestDataRepository();

        //    var employeeService =
        //        new EmployeeService(employeeManagmentTestDataRepository, new EmployeeFactory());

        //    var internalEmployee = new InternalEmployee("Brooklyn", "Cannon", 5, 3000, false, 1);

        //    //Act
        //    Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
        //        async () =>
        //        await employeeService.GiveRaiseAsync(internalEmployee, 50)
        //    );
        //}

        [Fact]
        public async Task NotifyOfAbsence_OnEmployeeIsAbsent_OnEmployeeIsAbsentMustBeTriggered()
        {
            //Arrange
            //var employeeManagmentTestDataRepository = new EmployeeManagementTestDataRepository();

            //var employeeService =
            //    new EmployeeService(employeeManagmentTestDataRepository, new EmployeeFactory());

            var internalEmployee = new InternalEmployee("Brooklyn", "Cannon", 5, 3000, false, 1);

            //Act & Assert
            Assert.Raises<EmployeeIsAbsentEventArgs>(
                handler => _employeeServiceFixture.EmployeeService.EmployeeIsAbsent += handler,
                handler => _employeeServiceFixture.EmployeeService.EmployeeIsAbsent -= handler,
                () => _employeeServiceFixture.EmployeeService.NotifyOfAbsence(internalEmployee)
                );
        }
    }
}

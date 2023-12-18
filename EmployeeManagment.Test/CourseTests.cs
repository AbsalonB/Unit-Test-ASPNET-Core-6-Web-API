using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagment.Test
{
    public class CourseTests
    {
        [Fact]
        public void CourseConstructor_ConstructCourse_IsNewMustBeTrue()
        {
            //Arrange


            //Act
            var course = new Course("Disaster Managment 101");

            //Assert
            Assert.True(course.IsNew);
        }
    }
}

using UnitTestMasters_Session3AssignmentLib.DataAccess.Entities;
using Xunit;

namespace UnitTestMasters_Session3AssignmentLib.NamingUnitTestAndApplyingAAATest.Tests
{
    public class EmployeeFactoryTests
    {
        [Fact()]
        public void CreateEmployee_Internal_ReturnsCreatedRecord()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Internal";
            var sut = new EmployeeFactory();

            // Act
            var result = sut.CreateEmployee(firstName, lastName);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<InternalEmployee>(result);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Internal", result.LastName);
        }

        [Fact()]
        public void CreateEmployee_Internal_ReturnsFirstNameCannotBeNull()
        {
            // Arrange
            string lastName = "Internal";
            var sut = new EmployeeFactory();

            // Act
            var exception = Assert.Throws<ArgumentException>(() => sut.CreateEmployee(firstName: null, lastName));

            // Assert
            Assert.Contains("'firstName' cannot be null or empty", exception.Message);
        }


        [Fact()]
        public void CreateEmployee_External_ReturnsCreatedRecord()
        {
            // Arrange
            string firstName = "John";
            string lastName = "External";
            string company = "Test Company";
            var sut = new EmployeeFactory();

            // Act
            var result = sut.CreateEmployee(firstName, lastName, company, isExternal: true);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ExternalEmployee>(result);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("External", result.LastName);
        }


        [Fact()]
        public void CreateEmployee_External_ReturnsCompanyCannotBeNull()
        {
            // Arrange
            string firstName = "John";
            string lastName = "External";
            var sut = new EmployeeFactory();

            // Act
            var exception = Assert.Throws<ArgumentException>(() => sut.CreateEmployee(firstName, lastName, company: null, isExternal: true));

            // Assert
            Assert.Contains("'company' cannot be null or empty when the employee is external", exception.Message);
        }
    }
}
using EmployeeService.Model;
using EmployeeService.Repository;
using Xunit;

namespace EmployeeService.Services.Tests
{
    public class EmployeeServiceTests
    {
        private EmployeeRepository _repository;
        public EmployeeServiceTests()
        {
            _repository = new EmployeeRepository();
        }

        [Fact()]
        public void CreateEmployeeTest()
        {
            // Arrange
            var employee = InitEmployee();

            // Act
            var result = _repository.CreateEmployee(employee);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(decimal.Zero, result);
        }

        [Fact()]
        public void GetEmployeeByIdTest()
        {
            // Arrange
            int employeeId = 1;

            // Act
            var result = _repository.GetEmployeeById(employeeId);

            // Assert
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.FirstName));
            Assert.False(string.IsNullOrEmpty(result.MiddleName));
            Assert.False(string.IsNullOrEmpty(result.LastName));
        }

        [Fact()]
        public void GetEmployeesTest()
        {
            // Act
            var result = _repository.GetEmployees();

            // Assert
            Assert.True(result.Any());
            Assert.False(string.IsNullOrEmpty(result.First().FirstName));
            Assert.False(string.IsNullOrEmpty(result.First().MiddleName));
            Assert.False(string.IsNullOrEmpty(result.First().LastName));
        }

        private Employee InitEmployee()
        {
            return new Employee
            {
                EmployeeId = 1,
                EmployeeTypeId = 1,
                FirstName = "TestFirst",
                LastName = "TestLast",
                MiddleName = "TestMiddle",
                DateOfBirth = new DateTime(1990, 1, 1),
                CreateDate = DateTime.Now,

                EmployeeAddress = new EmployeeAddress
                {
                    AddressId = 1,
                    EmployeeId = 1,
                    ContactId = 1,
                    HomeAddress = "Add1",
                    OfficeAddress = "Office1"
                },

                EmployeeType = new EmployeeType
                {

                    EmployeeTypeId = 1,
                    EmployeeTypeName = "Staff"
                },

                EmployeeSalary = new EmployeeSalary
                {
                    SalaryId = 1,
                    EmployeeId = 1,
                    GrossSalary = 10000
                }
            };
        }
    }
}
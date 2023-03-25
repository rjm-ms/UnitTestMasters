using Moq;

namespace UnitTestMasters_Session6Assignment
{
    public class OutputBaseTest
    {
        //[MethodUnderTest]_[Scenario] _[ExpectedResult]​
        [Fact]
        public void CalculateSSSContribution()
        {
            //Question: Calculate sss contribution of employeeid 1 with expected 25000

            // Answer:
            //-----------------------------------------//
            // Arrange
            var _mockSalaryService = new Mock<SalaryService>();
            var _mockEmployeeRepository = new Mock<EmployeeRepository>();
            var employee = _mockEmployeeRepository.Object.GetEmployee(employeeId: 1);
            
            // Act
            var result = _mockSalaryService.Object.CalculateContribution(1, employee.Salary);

            // Assert
            Assert.Equal(1, employee.Id);
            Assert.Equal(25000, result);
        }


        public class EmployeeRepository
        {
            public Employee? GetEmployee(int employeeId)
            {
                return Db.Employees.FirstOrDefault(x => x.Id == employeeId);
            }
        }

        public class Db
        {
            public static Employee[] Employees = new Employee[] {
            new Employee()
            {
                Id = 1,
                FirstName = "Juan",
                LastName = "Dela Cruz",
                Email = "juan.delacruz@softvision.com",
                Salary = 25000.00
            } };
        }

        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public double Salary { get; set; } 
        }

        public class SalaryService
        {

            public double CalculateContribution(double contribution, double salary)
            {
                return salary * contribution;

            }


            public double CalculateSalaryAfterAllContribution(double ssscontribution, double taxcontribution, double salary)
            {
                double sssDeduction = this.CalculateContribution(ssscontribution, salary);
                double taxDeduction = this.CalculateContribution(ssscontribution, salary);
                return (salary - taxcontribution) - ssscontribution;
            }
        }

        public class EmailService
        {
            public bool SendEmail(string to, string subject, string body)
            {
                var mailserver = new MailServer();
                var sent = mailserver.Send(to, subject, body);
                return sent;
            }
        }

        public class MailServer
        {
            internal bool Send(string to, string subject, string body)
            {
                if (subject == "Test Email" && !string.IsNullOrEmpty(to) && !string.IsNullOrEmpty(body))
                {
                    return true;
                }

                throw new Exception("Something is wrong");
            }
        }
    }
}
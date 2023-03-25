using Moq;

namespace UnitTestMasters_Session6Assignment
{
    public class StateBasedTest
    {
         
        [Fact]
        public void WhenCreateEmployeeIsCalled_ItShouldVerifyTheLatestAddedFirstName()
        {
            //Question: Create a state based test

            // Answer:
            //-----------------------------------------//
            // Arrange
            var _mockEmployeeRepository = new Mock<EmployeeRepository>();
            var newEmployee = new Employee
            {
                Id = 2,
                FirstName = "Peter",
                LastName = "Parkur",
                Email = "peter.parkur@softvision.com",
                Salary = 27000.00
            };
            var employees = _mockEmployeeRepository.Object.GetEmployees();

            // Act
            employees.Add(newEmployee);

            // Assert
            Assert.True(employees.Count == 2);
            Assert.Equal(employees[1].Id, newEmployee.Id);
        }

        public class EmployeeRepository
        {
            public Employee? GetEmployee(int employeeId)
            {
                return Db.Employees.FirstOrDefault(x => x.Id == employeeId);
            }

            public List<Employee> GetEmployees()
            {
                return Db.Employees.ToList();
            }

        }

        public class Db
        {
            public static List<Employee> Employees = new List<Employee> {
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
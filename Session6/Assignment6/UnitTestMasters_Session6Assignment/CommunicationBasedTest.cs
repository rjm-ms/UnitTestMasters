using Moq;

namespace UnitTestMasters_Session6Assignment
{
    public class CommunicationBasedTest
    {
        [Fact]
        public void WhenSendEmailIsCalled__ItShouldVerifyOnce()
        {
            //Question: Call send email and verify called it once

            // Answer:
            //-----------------------------------------//
            // Arrange
            string to = "test@email.com";
            string subject = "WhenSendEmailIsCalled__ItShouldVerifyOnce"; 
            string body = "Call send email and verify called it once";
            var _mockEmailService = new Mock<IEmailService>();

            // Act
            _mockEmailService.Object.SendEmail(to, subject, body);

            // Assert
            _mockEmailService.Verify(m => m.SendEmail(to, subject, body), Times.Once());
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

       
        public interface IEmailService
        {
            bool SendEmail(string to, string subject, string body); 
        }
        public class EmailService : IEmailService 
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
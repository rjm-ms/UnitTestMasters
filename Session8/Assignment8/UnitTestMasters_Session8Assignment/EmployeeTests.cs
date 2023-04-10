using Moq;

namespace UnitTestMasters_Session8Assignment
{

    // EmployeeServiceTests.cs
    public class EmployeeServiceTests
    {
        [Fact]
        public void AddEmployee_ShouldInsertEmployeeAndSendEmail()
        {
            //make sure you mock the emailService and use concrete for employee repository
            // Arrange
            var employee = new Employee
            {
                Name = "John Doe",
                Email = "johndoe@example.com"
            };

            string subject = "New Employee Added";
            string body = $"Dear {employee.Name}, a new employee record has been added for you.";

            var _mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var _mockEmailService = new Mock<IEmailService>();
            var sut = new EmployeeService(_mockEmployeeRepo.Object, _mockEmailService.Object);

            _mockEmployeeRepo.Setup(x => x.AddEmployee(employee));
            _mockEmailService.Setup(x => x.SendEmail(employee.Email, subject, body));
            _mockEmployeeRepo.Setup(x => x.GetEmployeeByEmail(employee.Email)).Returns(employee);

            // Act
            sut.AddEmployee(employee);

            // Assert 
            _mockEmployeeRepo.Verify(s => s.AddEmployee(employee), Times.Once);
            _mockEmailService.Verify(s => s.SendEmail(employee.Email, subject, body), Times.Once);
            Assert.NotNull(_mockEmployeeRepo.Object.GetEmployeeByEmail(employee.Email));
            Assert.Equal(employee.Email, _mockEmployeeRepo.Object.GetEmployeeByEmail(employee.Email).Email);
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    // EmployeeRepository.cs
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        Employee GetEmployeeByEmail(string email);
    }
 
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return _employees.FirstOrDefault(e => e.Email == email);
        }
    }

    // EmailService.cs
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            // Send email
            // ...
        }
    }

    // EmployeeService.cs
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmailService _emailService;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmailService emailService)
        {
            _employeeRepository = employeeRepository;
            _emailService = emailService;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);

            // Send email notification
            string subject = "New Employee Added";
            string body = $"Dear {employee.Name}, a new employee record has been added for you.";
            _emailService.SendEmail(employee.Email, subject, body);
        }
    }
}



